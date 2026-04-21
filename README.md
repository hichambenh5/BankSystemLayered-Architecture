# 🏦 Bank Management System

A full-featured banking system built using **C#**, **SQL Server**, and **Windows Forms**, following a **Layered Architecture** approach (Presentation, Business Logic, Data Access).

---

## 🚀 Features

* 🔐 **Authentication System**

  * Secure login with role-based access control

* 👥 **Customer Management**

  * Add, update, and manage customer data

* 💳 **Account Management**

  * Create and manage different account types
  * Link accounts to customers

* 💸 **Financial Transactions**

  * Deposit
  * Withdraw
  * Transfer between accounts

* 🧠 **Business Logic Layer**

  * Separation of concerns
  * Clean and maintainable structure

* 🛡️ **Data Integrity**

  * SQL Transactions (Commit / Rollback)
  * Stored Procedures & Triggers

* ⚙️ **Permissions System**

  * Bitwise-based role and permission handling

---

## 🏗️ Architecture

The project follows a **Layered Architecture**:

```
Presentation Layer (Windows Forms)
        ↓
Business Logic Layer
        ↓
Data Access Layer (ADO.NET)
        ↓
SQL Server Database
```

---

## 🛠️ Tech Stack

* **Language:** C#
* **Framework:** .NET (Windows Forms)
* **Database:** SQL Server (T-SQL)
* **Data Access:** ADO.NET

---

## ▶️ Getting Started

### 🔑 Demo Account (for testing)

You can log in using the following credentials:

* **Username:** `Admin2`
* **Password:** `12345`

---

### 📌 Steps to Run

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/your-repo-name.git
   ```

2. Open the solution file in Visual Studio

3. Configure the database connection in `App.config`

4. Run the project

---

## 📸 Screenshots

*(You can add screenshots here to showcase the UI)*

---

## 💡 Future Improvements

* Add Logging System
* Improve Exception Handling
* Convert to Web API (ASP.NET Core)
* Add Reporting Dashboard

---

## 📌 Notes

This project is built for learning and demonstrating real-world backend and system design concepts, including transaction handling, layered architecture, and role-based security.

---

## 👨‍💻 Author

**Hicham Benhemine**

