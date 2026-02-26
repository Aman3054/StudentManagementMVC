# Student Management MVC Application

## 📌 Project Overview
The **Student Management MVC Application** is an ASP.NET Core MVC web application designed to manage student records.  
It allows users to **view, add, edit, delete students**, and **view reports** such as total students and active students.

This project demonstrates:
- Proper MVC architecture
- Dependency Injection
- Entity Framework Core
- ADO.NET usage
- SQL Server database integration

---

## 🛠️ Technologies Used
- **ASP.NET Core MVC**
- **Entity Framework Core**
- **ADO.NET**
- **SQL Server**
- **Razor Views**
- **C#**

---

## 📂 Project Structure
- **Program.cs** – Application entry point and configuration
- **Controllers** – Handle HTTP requests
- **Models** – Represent database entities
- **Services** – Business logic layer
- **DataAccess** – EF Core and ADO.NET repositories
- **Views** – UI pages (Razor)
- **appsettings.json** – Configuration and connection string
- **database.sql** – Database creation script

---

## ▶️ Application Execution Flow

### Step 1: Run the Application
- When the **Run** button is clicked in Visual Studio:
  - `launchSettings.json` provides the localhost URL and port.
  - The application starts execution from **Program.cs**.

---

### Step 2: Program.cs Execution
- `WebApplication.CreateBuilder()` prepares:
  - Configuration (appsettings.json)
  - Dependency Injection container
  - Logging
  - Web server (not started yet)

---

### Step 3: Service Registration
In `Program.cs`, the following are registered:
- MVC services (`AddControllersWithViews`)
- Database connection string
- `ApplicationDbContext` (EF Core)
- Application services and repositories

⚠️ At this stage:
- No objects are created
- No database connection is opened

---

### Step 4: Application Start
- `app.Run()` starts the web server.
- Localhost becomes active.
- Browser opens the home page.

---

## 🧭 MVC Flow After Localhost

### Home Page
- Default route loads `HomeController`
- Displays the welcome page

---

### Students List (View Students)
- User clicks **Students**
- Request goes to `StudentController`
- `Index()` action is called
- Data is fetched from database using:
  - `StudentService`
  - `StudentEfRepository`
- Student list is displayed in the view

---

### Add Student
- User clicks **Create New**
- Create form is shown
- User enters student details and submits form
- Validation is performed
- Data is saved using **Entity Framework Core**
- Student is added to database
- Success message is shown

---

### Edit Student
- User clicks **Edit**
- Existing student data is loaded
- User updates details
- Changes are saved to database
- Updated data is displayed

---

### Delete Student
- User clicks **Delete**
- Confirmation page is shown
- On confirmation:
  - Student record is removed from database
- User is redirected to students list

---

### Reports Page
- User clicks **Reports**
- Uses **ADO.NET**
- Displays:
  - Total number of students
  - Total number of active students

---

## 🗄️ Database Details
- Database: **SQL Server**
- Database name: `StudentDB`
- Table: `Students`

The database structure is created using the provided **database.sql** file.

---

## 🔁 Dependency Injection Usage
- Services and repositories are registered in `Program.cs`
- Objects are created **only when needed**
- `DbContext` and services use **Scoped lifetime** (one per request)

---

## ✅ Key Learning Outcomes
- ASP.NET Core application startup flow
- MVC architecture
- Dependency Injection
- EF Core vs ADO.NET usage
- Clean separation of concerns
- Database-driven web application

---

## 📌 Conclusion
This project demonstrates a complete **end-to-end ASP.NET Core MVC application**, from startup configuration to database operations, following best practices and clean architecture.

