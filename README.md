# ☕ Smart Order Management System

![C#](https://img.shields.io/badge/C%23-Language-239120?style=for-the-badge&logo=csharp&logoColor=white)
![.NET Framework](https://img.shields.io/badge/.NET_Framework-4.8-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-Database-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![WinForms](https://img.shields.io/badge/Windows_Forms-Desktop_App-0078D6?style=for-the-badge&logo=windows&logoColor=white)


> A desktop-based Smart Order Management System built with **C# WinForms
> (.NET Framework 4.8)** and **Microsoft SQL Server** for a **Year 2
> Semester 2** university project.

------------------------------------------------------------------------

## 📚 Table of Contents

-   [Project Overview](#-project-overview)
-   [Features](#-features)
-   [Technology Stack](#-technology-stack)
-   [System Workflow](#-system-workflow)
-   [Installation & Setup](#-installation--setup)
-   [Database Setup](#-database-setup)
-   [Product Images Setup](#-product-images-setup)
-   [Generate Demo Data](#-generate-demo-data)
-   [Database Connection](#-database-connection)
-   [UI Preview](#-ui-preview)
-   [Contributors](#-contributors)
-   [License](#-license)

------------------------------------------------------------------------

## 📌 Project Overview

Smart Order Management System is a desktop-based **Self-Service Ordering System** developed using **C# WinForms (.NET Framework 4.8)** and **Microsoft SQL Server**.

The system is designed for coffee shops, cafés, beverage stores, and other businesses that want to simplify the ordering process while improving customer experience.

Unlike a traditional Point of Sale (POS) system where staff manually create every customer order, this system allows customers to browse products and place orders by themselves using a dedicated customer interface.

Each staff member logs into the system before starting work, allowing the system to record which employee is responsible for handling customer orders during that shift.

Customers are **not required to create an account or log in**. They simply enter their name and an optional phone number before placing an order.

Once an order is confirmed:

- The order is saved into SQL Server.
- A waiting number is generated automatically.
- A QR Code is generated.
- A PDF invoice is generated.
- Every connected staff dashboard immediately receives the order in real time.

This allows multiple computers to work together through the same SQL Server database, providing an efficient and modern ordering experience similar to self-order kiosks used in restaurants and cafés.

### Login Roles

-   👨‍💼 Admin
-   👨‍🔧 Staff

> Customers do not log into the system. Staff register customers and
> create orders on their behalf.

------------------------------------------------------------------------

## ✨ Features

### 👨‍💼 Admin

- Secure administrator login
- Dashboard overview
- Manage admin & staff accounts
- View customer records
- View order history
- View order report
- Revenue analytics
- Top/Least selling products analytics
- Export reports to PDF
- Export reports to Excel

---

### 👨‍🔧 Staff

- Secure staff login
- Open Customer Ordering Screen
- Monitor incoming customer orders
- Real-time order dashboard
- View waiting queue
- View recent order
- View order details
- Track payment status
- Complete customer orders
- Call waiting numbers

---

### 👤 Customer

No login or registration required.

Customers can:

- Enter name
- Optional phone number
- Browse products
- Browse by category
- Add products to cart
- Modify cart quantity
- Review order summary
- Select payment method
- Confirm order
- Receive waiting number
- Generate QR Code
- Generate PDF invoice

---

### ⚡ Smart Ordering Features

- Self-ordering customer interface
- Real-time synchronization between multiple computers
- Automatic waiting number generation
- Automatic QR Code generation
- Automatic PDF invoice generation
- Instant order notification on staff dashboard
- SQL Server centralized database

------------------------------------------------------------------------

## 🛠 Technology Stack

| Technology | Main Purpose |
|------------|--------------|
| **C#** | Primary programming language used to develop the application |
| **.NET Framework (4.8)** | Desktop application framework for building the graphical user interface |
| **Microsoft SQL Server** | Stores and manages application data |
| **System.Data.SqlClient** | Connects the application to SQL Server |
| **ReaLTaiizor** | Provides modern WinForms UI controls and styling |
| **QRCoder** | Generates QR codes for customer orders |
| **iTextSharp (5.5.13.5)** | Creates and exports invoice PDFs |
| **EPPlus (4.5.3.3)** | Exports reports to Microsoft Excel |
| **Visual Studio 2022/2026** | IDE used for development and debugging |
| **SQL Server Management Studio (SSMS)** | Used to create, manage, and execute SQL scripts |
------------------------------------------------------------------------
## 🔄 System Workflow

``` text
Store Opens
      │
      ▼
Staff Login
      │
      ▼
Staff Dashboard
      │
      ▼
Click "Customer"
      │
      ▼
Customer Ordering Screen
      │
      ▼
Customer Enters Name
(Optional Phone Number)
      │
      ▼
Browse Product Categories
      │
      ▼
Select Products
      │
      ▼
Add Items To Cart
      │
      ▼
Review Order
      │
      ▼
Select Payment Method
      │
      ▼
Confirm Order
      │
      ▼
────────────────────────────────────
 Order Saved into SQL Server
────────────────────────────────────
      │
      ├────────────► Staff Dashboard Updates Instantly
      │
      ▼
Waiting Number Generated
      │
      ▼
QR Code Generated
      │
      ▼
Invoice PDF Generated
      │
      ▼
Customer Waits
      │
      ▼
Staff Prepare Order
      │
      ▼
Staff Calls Waiting Number
      │
      ▼
Customer Receives Order
      │
      ▼
Order Completed
```

------------------------------------------------------------------------

# 🚀 Installation & Setup

Follow the steps below to set up the Smart Order Management System on your local machine.

### 1. Clone the Repository

Open Git Bash or Command Prompt and clone the repository:

```bash
git clone https://github.com/Laykimhoung/smart-order-management-system.git
```

Or download the project as a ZIP file from GitHub and extract it.

---

### 2. Open the Project

Open the solution file (`SmartOrderManagementSystem.sln`) using **Visual Studio 2022/2026**.

---

### 3. Restore NuGet Packages

When opening the project for the first time, Visual Studio may display missing package errors.

To restore all required packages:

### Method 1 (Recommended)

Right-click the **Solution** in **Solution Explorer**, then select:

```
Restore NuGet Packages
```

### Method 2

Go to:

```
Tools
→ NuGet Package Manager
→ Manage NuGet Packages for Solution...
```

Restore or install any missing packages.

The project uses the following NuGet packages:

- ReaLTaiizor
- QRCoder
- EPPlus
- iTextSharp
- System.Data.SqlClient

> **Note:** If any dependency is still missing after restoring, install it manually through the NuGet Package Manager before running the application.

---

### 4. Configure the Database

Follow the instructions in the **Database Setup** section below.

---

### 5. Configure the Database Connection

Follow the instructions in the **Database Connection** section below.

---

### 6. Run the Application

After completing all setup steps, press:

```
F5
```

or click **Start** in Visual Studio.

The application should now connect to SQL Server and run successfully.

---

## 🗄 Database Setup

This project uses **Microsoft SQL Server**.

Before running the application, you must create the database using the provided SQL scripts.

### Step 1

Open **SQL Server Management Studio (SSMS)** and connect to your SQL Server instance.

---

### Step 2

The project already includes all required sql code inside the **SQL** folder.

```
SmartOrderManagementSystem
│
├── SQL
│   ├── 1-Create_Database.sql
│   ├── 2-Add_Users&Product_Images.sql
│   ├── 3-Insert_Customers.sql
│   ├── 4-Demo_1K_Data.sql

```

Execute the following SQL files **ONE BY ONE** in the exact order shown below.

| Order | SQL File | Description |
|------:|----------|-------------|
| **1** | `1-Create_Database.sql` | Creates the **SmartOrderDB** database, all tables, relationships, stored procedures, and required objects. |
| **2** | `2-Add_Users&Product_Images.sql` | Inserts the default administrator accounts and updates all product image paths. |
| **3** | `3-Insert_Customers.sql` | Inserts sample customer records into the database. |
| **4** | `4-Demo_1K_Data.sql` | Generates demo orders, invoices, payments, waiting numbers, and report data for testing. |

> **Important:** Do not execute the SQL files in a different order, otherwise the database may not be created correctly.

Once all four scripts have been executed successfully, your database setup is complete.

---

## 🖼 Product Images Setup

The project already includes all required product images inside the **Images** folder.

```
SmartOrderManagementSystem
│
├── Images
│   ├── Coffee
│   ├── Milk Tea
│   ├── Smoothie
│   ├── Soda
│   └── ...
```

Before executing the SQL file below:

```
2-Add_Users&Product_Images.sql
```

you **must update the image paths** so they match the location of the project on your computer.

The SQL file contains the default image path:

```text
D:\SmartOrderManagementSystem\Images\
```

If your project is stored somewhere else, replace this path with the correct location.

### Example

Default path:

```text
D:\SmartOrderManagementSystem\Images\
```

Replace with:

```text
C:\Projects\SmartOrderManagementSystem\Images\
```

or

```text
E:\College Projects\SmartOrderManagementSystem\Images\
```

### 💡 Quick Tip

Instead of replacing every image path manually, you can use **Find and Replace** in SQL Server Management Studio.

Press:

```
Ctrl + H
```

Then:

**Find what**

```text
D:\SmartOrderManagementSystem\Images\
```

**Replace with**

```text
Your own project path\Images\
```

Click **Replace All** to update every image path instantly.

> **Important:** Update the image paths **before executing** `2-Add_Users&Product_Images.sql`. If you execute the script without changing the paths, product images will not appear correctly inside the application.

---

## 📊 Generate Demo Data

The file:

```
4-Demo_1K_Data.sql
```

allows you to generate realistic demo data for testing the application.

Before executing the script, you may customize the following variables:

```sql
DECLARE @StartDate DATETIME = '2025-09-01 07:30:00';
DECLARE @EndDate DATETIME = '2026-07-08 17:30:00';

DECLARE @TotalSeconds INT = DATEDIFF(SECOND, @StartDate, @EndDate);

DECLARE @Counter INT = 1;

/* Change this value to generate more or fewer sample orders */
DECLARE @MaxOrders INT = 10000;
```

### Configuration

| Variable | Description |
|-----------|-------------|
| **@StartDate** | The earliest date used when generating demo orders. |
| **@EndDate** | The latest date used when generating demo orders. |
| **@MaxOrders** | Specifies how many sample orders will be generated. |

### Example

Generate **100** sample orders:

```sql
DECLARE @MaxOrders = 100;
```

Generate **500** sample orders:

```sql
DECLARE @MaxOrders = 500;
```

 **Create date time** for sample orders:

```sql
DECLARE @StartDate DATETIME = '2025-01-01 08:00:00';
DECLARE @EndDate DATETIME = '2026-12-22 23:30:00';
```

This script is useful for testing:

- Dashboard statistics
- Revenue reports
- Sales analytics
- Customer history
- Waiting numbers
- PDF invoices
- Export reports

without manually entering data.

---

## 🔗 Database Connection

After creating the database, you must configure the application's SQL Server connection.

Open the following file:

```
Database/
└── DatabaseConnection.cs
```

Locate the connection string:

```csharp
@"Server=PROTECT-ME;
Database=SmartOrderDB;
User Id=sa;
Password=sa;
TrustServerCertificate=True;";
```

Replace the following values with your own SQL Server configuration:

- **Server Name**
- **SQL Username**
- **SQL Password**

### Example (Windows Authentication)

```csharp
@"Server=localhost;
Database=SmartOrderDB;
Integrated Security=True;
TrustServerCertificate=True;";
```

### Example (SQL Server Authentication)

```csharp
@"Server=DESKTOP-XXXX;
Database=SmartOrderDB;
User Id=sa;
Password=1234;
TrustServerCertificate=True;";
```

> **Tip:** Your server name may be `localhost`, `SQLEXPRESS`, your computer name, or another SQL Server instance depending on your installation.

Save the file after updating the connection string.

------------------------------------------------------------------------

## 🖥 UI Preview

The following screenshots demonstrate the user interfaces of the system.

### 🔐 Login Screen

<img width="1440" height="810" alt="1" src="https://github.com/user-attachments/assets/e8a2cd18-f51b-4eb4-af65-d6f7007e605d" />


---

### 👨‍💼 Admin Dashboard

<img width="1440" height="810" alt="4" src="https://github.com/user-attachments/assets/68c834b2-cf75-4938-8cbe-448e689bf3be" />
<img width="1440" height="810" alt="5" src="https://github.com/user-attachments/assets/b01b3056-e046-4233-b47c-f28159a75546" />


---

### 👨‍🔧 Staff Dashboard

<img width="1440" height="810" alt="3" src="https://github.com/user-attachments/assets/75b9d4cc-d4c8-4e69-9130-dd4f9f16eeeb" />


---

### 👤 Customer Ordering Screen

<img width="1440" height="810" alt="2" src="https://github.com/user-attachments/assets/d5b72966-173b-4c8f-94f7-2f42a74f657f" />


---

## 👥 Contributors

  Developed by:

**Year 2 Semester 2 University Team Project**

Members:

### 👨‍💻  Lay Kimhoung 
- Team Lead
- Admin Form
### 👩‍💻 Mom Sonita
- Staff Form
### 👨‍💻 Naing Vannath
- Customer Form
### 👨‍💻 Prak Channarith
- Login Form
### 👨‍💻 Horn SereyBoth
- Database
### 👨‍💻 Hak Phanith
- Tester


------------------------------------------------------------------------

## 📄 License

This project is developed for **educational purposes only** as a Year 2
Semester 2 university project.
