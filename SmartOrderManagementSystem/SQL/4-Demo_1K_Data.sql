USE SmartOrderDB;
GO

DECLARE @StartDate DATETIME = '2025-09-01 07:30:00';
DECLARE @EndDate DATETIME = '2026-07-08 17:30:00';
DECLARE @TotalSeconds INT = DATEDIFF(SECOND, @StartDate, @EndDate);

DECLARE @Counter INT = 1;
-- Change this number to generate more or fewer sample orders
DECLARE @MaxOrders INT = 10000; 

-- Calculate the average interval between orders to distribute them across the timeframe
DECLARE @AverageIntervalSeconds INT = @TotalSeconds / @MaxOrders;

-- Variables to manage chronological dates and the daily waiting number reset
DECLARE @CurrentDate DATETIME = @StartDate;
DECLARE @LastOrderDate DATE = NULL;
DECLARE @DailyWaitingNumber INT = 0;

-- Temporary table to hold items chosen for the current order
IF OBJECT_ID('tempdb..#TempItems') IS NOT NULL DROP TABLE #TempItems;
CREATE TABLE #TempItems (
    ProductID INT,
    Quantity INT,
    UnitPrice DECIMAL(10,2)
);

BEGIN TRANSACTION;
BEGIN TRY
    WHILE @Counter <= @MaxOrders
    BEGIN
        -- 1. Advance the running date by a randomized interval
        DECLARE @RandomStep INT = (ABS(CHECKSUM(NEWID())) % (@AverageIntervalSeconds * 2)) + 1;
        SET @CurrentDate = DATEADD(SECOND, @RandomStep, @CurrentDate);
        
        -- Fallback safety check to prevent exceeding @EndDate
        IF @CurrentDate > @EndDate 
            SET @CurrentDate = @EndDate;

        -- Extract the date portion to check for a new day
        DECLARE @CurrentOrderDate DATE = CAST(@CurrentDate AS DATE);

        -- If the date has changed (or it is the first order), reset the waiting number to 1
        IF @LastOrderDate IS NULL OR @CurrentOrderDate <> @LastOrderDate
        BEGIN
            SET @DailyWaitingNumber = 1;
            SET @LastOrderDate = @CurrentOrderDate;
        END
        ELSE
        BEGIN
            -- Otherwise, increment the waiting number for the same day
            SET @DailyWaitingNumber = @DailyWaitingNumber + 1;
        END

        DECLARE @CustomerID INT;
        SELECT TOP 1 @CustomerID = CustomerID FROM Customers ORDER BY NEWID();

        DECLARE @UserID INT;
        -- Select staff users (RoleID = 2) for standard orders
        SELECT TOP 1 @UserID = UserID FROM Users WHERE RoleID = 2 ORDER BY NEWID();
        IF @UserID IS NULL 
            SELECT TOP 1 @UserID = UserID FROM Users ORDER BY NEWID(); -- Fallback

        -- Distribute statuses: ~85% Completed, ~10% Cancelled, ~5% Pending
        DECLARE @OrderStatus NVARCHAR(15);
        DECLARE @StatusRand INT = ABS(CHECKSUM(NEWID())) % 100;
        IF @StatusRand < 85
            SET @OrderStatus = N'Completed';
        ELSE IF @StatusRand < 95
            SET @OrderStatus = N'Cancelled';
        ELSE
            SET @OrderStatus = N'Pending';

        DECLARE @Notes NVARCHAR(255) = CASE ABS(CHECKSUM(NEWID())) % 6
                                            WHEN 0 THEN N'Less ice'
                                            WHEN 1 THEN N'Takeaway'
                                            WHEN 2 THEN N'No sugar'
                                            WHEN 3 THEN N'Extra sweet'
                                            ELSE NULL
                                       END;

        -- 2. Select 1 to 4 random products for this order
        DELETE FROM #TempItems;
        DECLARE @NumItems INT = (ABS(CHECKSUM(NEWID())) % 4) + 1; 
        
        INSERT INTO #TempItems (ProductID, Quantity, UnitPrice)
        SELECT TOP (@NumItems) ProductID, (ABS(CHECKSUM(NEWID())) % 3) + 1, Price
        FROM Products
        ORDER BY NEWID();

        -- Calculate the exact sum for the Order Total
        DECLARE @TotalAmount DECIMAL(10,2);
        SELECT @TotalAmount = SUM(Quantity * UnitPrice) FROM #TempItems;

        -- 3. Insert the Order record with the reset daily waiting number
        DECLARE @OrderID INT;
        INSERT INTO Orders (WaitingNumber, CustomerID, UserID, OrderStatus, OrderDate, TotalAmount, Notes)
        VALUES (@DailyWaitingNumber, @CustomerID, @UserID, @OrderStatus, @CurrentDate, @TotalAmount, @Notes);
        
        SET @OrderID = SCOPE_IDENTITY();

        -- 4. Insert corresponding OrderItems
        INSERT INTO OrderItems (OrderID, ProductID, Quantity, UnitPrice)
        SELECT @OrderID, ProductID, Quantity, UnitPrice
        FROM #TempItems;

        -- 5. Write the initial log
        INSERT INTO OrderLogs (OrderID, Action, ActionDate)
        VALUES (@OrderID, N'Order Created', @CurrentDate);

        -- 6. For Completed orders, create Invoice, Payment, and Payment log
        IF @OrderStatus = N'Completed'
        BEGIN
            -- Invoice generated slightly after order (10 to 120 seconds)
            DECLARE @InvoiceDate DATETIME = DATEADD(SECOND, ABS(CHECKSUM(NEWID())) % 110 + 10, @CurrentDate);
            DECLARE @InvoiceID INT;

            INSERT INTO Invoices (OrderID, InvoiceDate)
            VALUES (@OrderID, @InvoiceDate);

            SET @InvoiceID = SCOPE_IDENTITY();

            -- Payment generated slightly after invoice (5 to 60 seconds)
            DECLARE @PaymentDate DATETIME = DATEADD(SECOND, ABS(CHECKSUM(NEWID())) % 55 + 5, @InvoiceDate);

            INSERT INTO Payments (InvoiceID, Amount, PaymentDate)
            VALUES (@InvoiceID, @TotalAmount, @PaymentDate);

            INSERT INTO OrderLogs (OrderID, Action, ActionDate)
            VALUES (@OrderID, N'Payment Received', @PaymentDate);
        END
        ELSE IF @OrderStatus = N'Cancelled'
        BEGIN
            -- Cancel log occurring shortly after creation
            DECLARE @CancelDate DATETIME = DATEADD(MINUTE, ABS(CHECKSUM(NEWID())) % 15 + 1, @CurrentDate);
            INSERT INTO OrderLogs (OrderID, Action, ActionDate)
            VALUES (@OrderID, N'Order Cancelled', @CancelDate);
        END

        SET @Counter = @Counter + 1;
    END

    COMMIT TRANSACTION;
    PRINT 'Transaction data generated successfully with daily waiting number resets.';
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT 'An error occurred. Transaction rolled back.';
    THROW;
END CATCH;

IF OBJECT_ID('tempdb..#TempItems') IS NOT NULL DROP TABLE #TempItems;
GO