# SE Lab 8 Summary Report: ASP.NET Core with Razor & MVC (Code First)

**Author:** Trinh Duc Long  
**Student ID:** 524K0021  
**Course:** Software Engineering – Lab 8  
**Faculty:** Faculty of Information Technology – Ton Duc Thang University (TDTU)  
**Instructor:** MSc. Pham Thai Ky Trung  
**Submission Type:** Individual Work  

---

## 1. Introduction
The objective of Lab 8 is to examine, implement, and compare the **Code First** database development approach using **ASP.NET Core (.NET 8 / 10)** and **Entity Framework Core (EF Core)** across both **Razor Pages** and **MVC** application architectures.

In contrast to Database First (Lab 7), the Code First approach allows developers to define the data models and relationships using pure C# POCO classes. EF Core Migrations are then applied to generate and evolve the database schema automatically.

---

## 2. Exercise Overview & Implementation

### 2.1. Solution Architecture & Package Setup
- Created the root solution `SchoolManagementSystem.slnx` containing both web applications.
- Installed essential EF Core NuGet packages:
  - `Microsoft.EntityFrameworkCore.SqlServer`
  - `Microsoft.EntityFrameworkCore.Tools`
  - `Microsoft.EntityFrameworkCore.Design`

### 2.2. Domain Model Definition
Implemented 5 interconnected domain entities:
- `Department`: DepartmentID, DepartmentName, Budget, StartDate, Courses collection.
- `Instructor`: InstructorID, LastName, FirstName, HireDate, Courses collection.
- `Course`: CourseID, Title, Credits, DepartmentID, InstructorID, Department/Instructor navigation properties, Enrollments collection.
- `Student`: StudentID, LastName, FirstName, EnrollmentDate, Enrollments collection.
- `Enrollment`: EnrollmentID, CourseID, StudentID, Grade, Course/Student navigation properties.

### 2.3. DbContext, Database Connection & Code First Migrations
- Authored `SchoolContext` establishing `DbSet<>` properties for all entities.
- Configured connection strings in `appsettings.json`.
- Generated initial Code First migrations:
  ```bash
  dotnet ef migrations add InitialCreate
  dotnet ef database update
  ```
- Created initial database schemas with primary keys, cascading/nullable foreign keys, and indexes.

### 2.4. CRUD Implementation & Dropdown Customization
- **Razor Pages (`SchoolAppCoreRazor`):** Built 5 complete CRUD page suites for Departments, Courses, Instructors, Students, and Enrollments.
- **MVC (`SchoolAppCoreMVC`):** Implemented asynchronous controllers and Razor views for all 5 entities.
- **Dropdown List Customization:** Enhanced the Department selection dropdown in Course Create/Edit views to display combined text: `DepartmentID - DepartmentName`:
  ```csharp
  ViewData["DepartmentID"] = new SelectList(
      _context.Departments.Select(d => new {
          d.DepartmentID,
          DisplayText = d.DepartmentID + " - " + d.DepartmentName
      }),
      "DepartmentID",
      "DisplayText"
  );
  ```
- **Data Seeding:** Created `DbInitializer` to automatically populate sample departments, instructors, students, courses, and grades on application startup.

---

## 3. Architecture Comparison: Razor Pages vs MVC

| Feature | ASP.NET Core MVC | ASP.NET Core Razor Pages |
|:---|:---|:---|
| **Structure** | Separate Controllers/, Views/, Models/ | Co-located .cshtml and .cshtml.cs files |
| **Routing Pattern** | Action-based (Route -> Controller -> Action -> View) | Page-based (Route -> Page Handler OnGet/OnPost) |
| **Benefits** | Clear separation of concerns, high testability | Simplicity, tight integration, rapid development |
| **Drawbacks** | Boilerplate code, higher overhead for small tasks | Less granular URL flexibility for nested flows |
| **Best Suited For** | Enterprise-scale systems, multi-platform APIs | Admin dashboards, CRUD forms, lightweight apps |

---

## 4. Conclusion
- Code First migrations provide full version control of the database schema within the source code repository.
- Successfully implemented and tested both Razor Pages and MVC paradigms, validating data persistence, validation, and user interface workflows.

---

## Appendix
- **GitHub Repository:** [https://github.com/Kuma984/Lab8-SchoolManagement](https://github.com/Kuma984/Lab8-SchoolManagement)
- **Author:** Trinh Duc Long (Student ID: 524K0021) - GitHub: @Kuma984
