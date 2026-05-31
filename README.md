# ☕ Smart Order ManagementSystem

**Smart Order Management System** built using **C# WinForms (.NET Framework 4.8)** and **SQL Server** for a university project **(Year 2 Semester 2)**.

The system is designed to manage customer drink/coffee orders with **role-based access**, **order tracking**, **QR generation**, **invoice PDF export**, and **report management (PDF/Excel)**.

---

## 📌 Project Overview

Smart Order Management System is a desktop-based ordering management system designed for a coffee/drink business.

The system supports multiple user roles:

- **Admin**
- **Staff**
- **Customer**

The workflow includes:

```text
Login
↓
Customer places order
↓
Waiting number generated
↓
Order details + QR code shown
↓
Invoice PDF generated
↓
Staff/Admin manage records and reports
```

---
## 🛠️ Tech Stack

### Language

- C#

### Framework

- WinForms (.NET Framework 4.8)

### Database

- Microsoft SQL Server

### Libraries

- ReaLTaiizor → Modern UI Components
- QRCoder → QR Code Generation
- iTextSharp (5.5.13.5) → PDF Invoice Generation
- EPPlus (4.5.3.3) → Excel Export
- System.Data.SqlClient → SQL Server Connection

---
## 🚀 Installation & Setup

### 1. Clone Repository

```bash
git clone https://github.com/Laykimhoung/smart-order-management-system.git
```

### 2. Open Project

Open in:

```text
Visual Studio
```

### 3. Restore NuGet Packages

Open:

```text
Tools → NuGet Package Manager → Restore Packages
```

### 4. Setup Database

Run:

```text
SQL/SmartOrderDB.sql
```

inside SQL Server.

### 5. Run Project

Press:

```text
Start / F5
```


## ✨ Features

### 👨‍💼 Admin

- Dashboard overview
- Manage users
- View reports
- View order history
- Export reports to PDF/Excel

### 👨‍🔧 Staff

- View customer records
- View customer orders
- View order details

### 👤 Customer

- Place orders
- Browse products by category
- View order details
- View QR code
- Generate invoice PDF

---

## 🔄 System Workflow

```text
Login
↓
Role-Based Dashboard
↓
Customer Creates Order
↓
Waiting Number Generated
↓
QR Code Generated
↓
Invoice PDF Generated
↓
Admin/Staff View Reports & History
```
---

## 📸 Screenshots

### Admin Dashboard

(Waiting Until Project Done)

### Customer Order Page

(Waiting Until Project Done)

### Reports Page

(Waiting Until Project Done)

---

## ⚒️ Contributors

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
### 👨‍💻 Hak Phanith
- Login Form
### 👨‍💻 Horn SereyBoth
- Database
### 👨‍💻 Prak Channarith
- Tester


---

## 📄 License

This project is for **educational purposes only**.
