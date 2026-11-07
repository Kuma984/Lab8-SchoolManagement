# School App Projects - Lab 8 (ASP.NET Core Code First)

**Author:** Trinh Duc Long (Student ID: 524K0021)  
**Course:** Software Engineering – Lab 8  
**Faculty:** Faculty of Information Technology – Ton Duc Thang University (TDTU)  
**Instructor:** MSc. Pham Thai Ky Trung  

---

## 📌 Project Overview
This repository contains the complete implementation for **Lab 8: ASP.NET Core with Razor/MVC – Code First Approach**.
In this lab, the database schema is defined directly using C# model classes and Entity Framework Core (EF Core) generates and updates the database through Code First migrations.

Two web applications have been fully implemented and tested:
1. **`SchoolAppCoreRazor`**: ASP.NET Core Web Application built using **Razor Pages** with EF Core Code First.
2. **`SchoolAppCoreMVC`**: ASP.NET Core Web Application built using the **Model-View-Controller (MVC)** architectural pattern with EF Core Code First.

Both projects provide full CRUD (Create, Read, Update, Delete) capabilities for all 5 entities:
- **Departments** (DepartmentID, DepartmentName, Budget, StartDate)
- **Courses** (CourseID, Title, Credits, DepartmentID, InstructorID) – Featuring an enhanced dropdown displaying `DepartmentID - DepartmentName`
- **Instructors** (InstructorID, LastName, FirstName, HireDate)
- **Students** (StudentID, LastName, FirstName, EnrollmentDate)
- **Enrollments** (EnrollmentID, CourseID, StudentID, Grade)

---

## 🔗 Important Links
- **GitHub Repository:** [https://github.com/Kuma984/Lab8-SchoolManagement](https://github.com/Kuma984/Lab8-SchoolManagement)

---

## 🚀 Running the Applications

### Prerequisites
- [.NET 8.0 / 10.0 SDK](https://dotnet.microsoft.com/)
- SQL Server LocalDB or SQL Server Express

### Exercise 1: Razor Pages Application
- **Description:** ASP.NET Core Razor Pages project using the Code First approach.
- **Instructions:**
```bash
cd SchoolAppCoreRazor
dotnet ef database update
dotnet run
```
Open your browser and navigate to: `http://localhost:5000` (or the port specified in terminal).

### Exercise 2: MVC Application
- **Description:** ASP.NET Core MVC project using the Code First approach.
- **Instructions:**
```bash
cd SchoolAppCoreMVC
dotnet ef database update
dotnet run
```
Open your browser and navigate to: `http://localhost:5000` (or the port specified in terminal).

---

## 📊 ASP.NET Core Razor Pages vs ASP.NET Core MVC Comparison

| Feature | ASP.NET Core MVC | ASP.NET Core Razor Pages |
|:---|:---|:---|
| **Structure** | Controllers, Views, Models | Page Model (.cshtml.cs), Razor Page (.cshtml) |
| **Routing Pattern** | Action-based (Route -> Controller -> Action -> View) | Page-based (Route -> Page Handler OnGet/OnPost) |
| **Benefits** | Clear separation of concerns, testability, flexibility | Simplicity, tight integration, rapid development |
| **Drawbacks** | Boilerplate code, higher complexity for simple scenarios | Less granular URL control for complex nested workflows |
| **Recommended Use** | Enterprise-grade applications, multi-tier architectures, REST APIs | Administrative dashboards, CRUD form workflows, internal tools |
