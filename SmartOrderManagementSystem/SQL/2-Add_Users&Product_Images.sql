USE SmartOrderDB;
GO

BEGIN TRANSACTION;

BEGIN TRY
    -- 1. Populate Roles Table
    INSERT INTO Roles (RoleName)
    VALUES 
    (N'Admin'),
    (N'Staff');

    -- 2. Populate Categories Table
    INSERT INTO Categories (CategoryName)
    VALUES 
    (N'Coffee'),
	(N'Tea'),
    (N'Drink'),
    (N'Dessert'),
	(N'Ice-Cream');


    -- 3. Populate Users Table (Requires RoleID)
    -- RoleID 1 = Administrator, 2 = Manager
    INSERT INTO Users (Username, Password, FullName, Sex, Email, Phone, RoleID)
    VALUES 
    (N'JH-AD-Houng', N'123', N'Lay Kimhoung', 'Male', N'adminhoung@cafe.com', N'0123456789', 1),
	(N'JH-AD-Both', N'321', N'Horn Sereyboth', 'Male', N'adminboth@cafe.com', N'0987654321', 1),
    (N'JH-ST-Rith', N'456', N'Prak Channarith', 'Male', N'rith@cafe.com', N'0123456780', 2),
    (N'JH-ST-Nita', N'654', N'Mom Sonita', 'Female', N'nita@cafe.com', N'0865746789', 2),
	(N'JH-ST-Nath', N'789', N'Naing Vannath', 'Male', N'nath@cafe.com', N'0578642846', 2),
	(N'JH-ST-Nith', N'987', N'Hak Phanith', 'Male', N'nith@cafe.com', N'0687542861', 2);


    -- 5. Populate Products Table (Requires CategoryID and loads Image Files)
    -- CategoryID 1 = Coffee, 2 = Tea, 3 = Drink, 4 = Dessert, 5 = Ice-Cream
	-- Coffee 1
    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Iced Coffee with Condensed Milk', 1.25, 1, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Iced Coffee with Condensed Milk.jpg', SINGLE_BLOB) AS ImageFile;

	INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Iced Black Coffee', 1.00, 1, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Iced Black Coffee.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Salted Cream Iced Coffee', 2.00, 1, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Salted Cream Iced Coffee.jpg', SINGLE_BLOB) AS ImageFile;

	INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Egg Coffee', 2.50, 1, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Egg Coffee.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Coffee Tmorpel', 1.50, 1, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Coffee Tmorpel.jpg', SINGLE_BLOB) AS ImageFile;

	INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Avocado Coffee Smoothie', 2.50, 1, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Avocado Coffee Smoothie.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Pandan Latte', 2.50, 1, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Pandan Latte.jpg', SINGLE_BLOB) AS ImageFile;

	INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Iced Americano with Coconut Water', 2.50, 1, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Iced Americano with Coconut Water.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Durian Coffee Smoothie', 3.50, 1, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Durian Coffee Smoothie.jpg', SINGLE_BLOB) AS ImageFile;

	INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Iced Latte', 1.50, 1, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Iced Latte.jpg', SINGLE_BLOB) AS ImageFile;

	-- Tea 2
    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Iced Green Tea Latte', 1.50, 2, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Iced Green Tea Latte.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Hot Tea', 0.25, 2, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Hot Tea.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Te Krouch Chhmar', 1.00, 2, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Te Krouch Chhmar.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Passion Fruit Green Tea', 1.50, 2, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Passion Fruit Green Tea.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Jasmine Milk Tea with Pearls', 1.75, 2, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Jasmine Milk Tea with Pearls.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Honey Chrysanthemum Tea', 2.00, 2, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Honey Chrysanthemum Tea.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Oolong Cheese Tea', 2.50, 2, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Oolong Cheese Tea.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Te Slok Toi', 1.00, 2, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Te Slok Toi.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Winter Melon Tea', 1.25, 2, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Winter Melon Tea.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Ginger Honey Tea', 1.50, 2, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Ginger Honey Tea.jpg', SINGLE_BLOB) AS ImageFile;

	-- Drink 3
    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Tuk Ampov', 0.50, 3, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Tuk Ampov.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Tuk Dong', 1.25, 3, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Tuk Dong.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Orange Juice', 1.00, 3, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Fresh Orange Juice.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Avocado Smoothie', 1.50, 3, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Avocado Smoothie.jpg', SINGLE_BLOB) AS ImageFile;

	INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Passion Milk Shake', 1.50, 3, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Passion Fruit Milk Shake.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Soursop Smoothie', 2.50, 3, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Soursop Smoothie.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Tuk Tracheak Kranh', 1.00, 3, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Pennywort Juice.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Mango Smoothie', 1.00, 3, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Mango Smoothie.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Soy Milk', 0.75, 3, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Soy Milk.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Magic Water', 0.25, 3, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Magic Water.jpg', SINGLE_BLOB) AS ImageFile;

	-- Dessert 4
    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Pumpkin Custard', 1.25, 4, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Pumpkin Custard.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Banana in Coconut Milk', 0.50, 4, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Banana in Coconut Milk.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Sticky Rice with Mango', 1.75, 4, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Sticky Rice with Mango.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Num Chak Chan', 1.00, 4, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Num Chak Chan.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Mixed Jelly', 1.00, 4, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Mixed Jelly Dessert.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Num Ak Cassava', 1.00, 4, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Num Ak Cassava.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Sweet Corn Porridge', 0.50, 4, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Sweet Corn Porridge.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Rice Balls in Ginger Syrup', 1.00, 4, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Rice Balls in Ginger Syrup.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Num Chak Chul', 0.50, 4, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Num Chak Chul.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Taro with Coconut Cream', 1.00, 4, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Taro with Coconut Cream.jpg', SINGLE_BLOB) AS ImageFile;

	-- Ice-Cream 5
    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Nigga Ice Cream', 2.00, 5, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Nigga Ice Cream.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Coconut Ice Cream', 1.00, 5, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Coconut Ice Cream.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Durian Ice Cream', 2.50, 5, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Durian Ice Cream.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Kampot Pepper Vanilla Ice Cream', 2.50, 5, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Kampot Pepper Vanilla Ice Cream.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Jackfruit Ice Cream', 1.50, 5, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Jackfruit Ice Cream.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Mango Lime Sorbet', 1.75, 5, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Mango Lime Sorbet.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Taro Ice Cream', 1.50, 5, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Taro Ice Cream.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Palm Sugar Caramel Ice Cream', 2.00, 5, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Palm Sugar Caramel Ice Cream.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Sweet Corn Ice Cream', 1.25, 5, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Sweet Corn Ice Cream.jpg', SINGLE_BLOB) AS ImageFile;

    INSERT INTO Products (ProductName, Price, CategoryID, ProductImage)
    SELECT N'Milo Dinosaur Ice Cream', 1.75, 5, BulkColumn 
    FROM OPENROWSET(BULK N'D:SmartOrderManagementSystem\Images\Milo Dinosaur Ice Cream.jpg', SINGLE_BLOB) AS ImageFile;


    COMMIT TRANSACTION;
    PRINT 'Data populated successfully.';

END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT 'An error occurred. Transaction rolled back.';
    THROW;
END CATCH;
GO