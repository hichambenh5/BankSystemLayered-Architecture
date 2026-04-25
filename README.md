# 🏦 Bank Management System

A full-featured **Banking System** built using **C#**, **SQL Server**, and **Windows Forms**, designed with a **Layered Architecture** approach to ensure scalability, maintainability, and clean separation of concerns.

---

## 🚀 Features

### 🔐 Authentication & Authorization

* Secure login system
* Role-based access control
* Bitwise permission management

### 👥 Customer Management

* Create, update, and manage customer records
* Link customers with their bank accounts

### 💳 Account Management

* Support for multiple account types
* Full account lifecycle management (Create / Update / View)

### 💸 Financial Transactions

* Deposit funds
* Withdraw funds
* Transfer between accounts
* Ensures consistency using **database transactions (Commit / Rollback)**

### 🧠 Business Logic Layer

* Clear separation between UI, logic, and data
* Maintainable and scalable code structure

### 🛡️ Data Integrity & Reliability

* SQL Transactions for safe operations
* Stored Procedures & Triggers for enforcing rules

---

## 🏗️ Architecture

This project follows a **3-Tier Layered Architecture**:

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

### 🔑 Demo Account

Use the following credentials to explore the system:

* **Username:** `Admin2`
* **Password:** `12345`

---

### ⚙️ Setup Instructions

1. Clone the repository
2. Open the solution file in Visual Studio
3. Configure the database connection in `App.config`
4. Run the project

---

## 💡 Future Improvements

* Implement centralized logging system
* Enhance exception handling strategy
* Migrate to Web API using ASP.NET Core
* Add analytics & reporting dashboard

---

## 📌 Notes

This project demonstrates practical backend concepts such as:

* Transaction management
* Role-based security
* Layered architecture design

It is designed to simulate real-world banking system behavior in a desktop environment.

---

## 👨‍💻 Author

**Hicham Benhemine**
