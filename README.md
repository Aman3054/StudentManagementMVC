# 🎓 Student Management System — ASP.NET Core MVC

A production-style **ASP.NET Core MVC** web application for managing student records, demonstrating clean architecture, dependency injection, EF Core, and ADO.NET reporting.

---

## 🚀 Project Overview

The **Student Management MVC Application** allows users to:

- View, add, edit, and delete students
- Generate reports (Total Students & Active Students)
- Perform secure database operations using EF Core and ADO.NET

This project showcases real-world backend architecture and enterprise development practices.

---

## 🛠️ Tech Stack

- ASP.NET Core MVC
- C#
- Entity Framework Core
- ADO.NET
- SQL Server
- Razor Views

---

## 🧱 Architecture Highlights

✔ MVC Pattern (Separation of Concerns)  
✔ Dependency Injection  
✔ Repository & Service Layer  
✔ EF Core for CRUD Operations  
✔ ADO.NET for Reporting Queries  
✔ Background Logging  

---

## 📂 Project Structure

```
## 📂 Project Structure

```
StudentManagementMVC
│
├── Documentation
│   ├── database.sql
│   ├── README.md
│   └── StudentManagement_Project_Demo.pdf
│
├── .gitignore
│
├── StudentManagementMVC
│   ├── Connected Services
│   ├── Dependencies
│   ├── Properties
│   ├── wwwroot
│   ├── Controllers
│   ├── DataAccess
│   ├── Helpers
│   ├── Models
│   ├── Services
│   ├── Views
│   ├── appsettings.json
│   ├── appsettings.Development.json
│   └── Program.cs
│
└── StudentManagementMVC.Tests
    ├── Dependencies
    └── StudentEfRepositoryTests.cs
```

---

## ▶️ Application Execution Flow

### 1️⃣ Application Startup
- `Program.cs` builds the WebApplication
- Services & DbContext registered in DI container
- Logging and configuration initialized

### 2️⃣ MVC Request Flow
- Request → Controller → Service → Repository → Database
- Data returned to Razor Views for rendering

### 3️⃣ Reports Module
- Uses **ADO.NET** for optimized SQL queries
- Displays:
  - Total Students
  - Active Students

---

## 🗄️ Database

- **Database:** SQL Server  
- **Database Name:** `Your Database Name`  
- **Table:** `Students`

Run the provided `database.sql` script before starting the application.

---

## ⚙️ Setup & Run

1. Clone the repository:

```bash
git clone https://github.com/Aman3054/StudentManagementMVC.git
```

2. Open the solution in **Visual Studio**

3. Update connection string in `appsettings.json`

4. Run the project:

```
Ctrl + F5
```

---

## 🔁 Dependency Injection

- MVC Services registered using `AddControllersWithViews`
- DbContext configured using EF Core
- Services and repositories use **Scoped lifetime**

Objects are created only when required — improving performance and maintainability.

---

## 📊 Features

- Student CRUD Operations
- Server-side Validation
- Reports Dashboard
- Background Logging
- Clean Layered Architecture

---

## 🎯 Learning Outcomes

- ASP.NET Core application startup pipeline
- EF Core vs ADO.NET usage patterns
- MVC architecture in real-world apps
- Dependency Injection and service lifetimes
- Database-driven web application design

---

## 📌 Conclusion

This project demonstrates an **end-to-end ASP.NET Core MVC application** following clean architecture principles, scalable backend design, and modern .NET development practices.

---

## 👨‍💻 Author
Aman Goswami | DotNet Developer 

**Aman Goswami**  
B.Tech CSE | Full-Stack Developer  
MERN Stack • .NET • SQL • System Design
