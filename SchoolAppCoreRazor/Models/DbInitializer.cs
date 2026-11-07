using System;
using System.Linq;

namespace SchoolAppCoreRazor.Models
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            if (context.Departments.Any()) return;

            var d1 = new Department { DepartmentName = "Information Technology", Budget = 250000m, StartDate = DateTime.Parse("2026-09-01") };
            var d2 = new Department { DepartmentName = "Computer Engineering", Budget = 300000m, StartDate = DateTime.Parse("2026-09-01") };
            var d3 = new Department { DepartmentName = "Business Administration", Budget = 150000m, StartDate = DateTime.Parse("2026-09-01") };
            context.Departments.AddRange(d1, d2, d3);
            context.SaveChanges();

            var i1 = new Instructor { LastName = "Pham", FirstName = "Ky-Trung", HireDate = DateTime.Parse("2018-08-15") };
            var i2 = new Instructor { LastName = "Nguyen", FirstName = "Van A", HireDate = DateTime.Parse("2020-01-10") };
            var i3 = new Instructor { LastName = "Tran", FirstName = "Thi B", HireDate = DateTime.Parse("2021-03-20") };
            context.Instructors.AddRange(i1, i2, i3);
            context.SaveChanges();

            var s1 = new Student { LastName = "Trinh", FirstName = "Duc Long", EnrollmentDate = DateTime.Parse("2024-09-01") };
            var s2 = new Student { LastName = "Smith", FirstName = "John", EnrollmentDate = DateTime.Parse("2024-09-01") };
            var s3 = new Student { LastName = "Watson", FirstName = "Emma", EnrollmentDate = DateTime.Parse("2024-09-01") };
            var s4 = new Student { LastName = "Clark", FirstName = "David", EnrollmentDate = DateTime.Parse("2025-01-15") };
            context.Students.AddRange(s1, s2, s3, s4);
            context.SaveChanges();

            var c1 = new Course { Title = "Software Engineering", Credits = 4, DepartmentID = d1.DepartmentID, InstructorID = i1.InstructorID };
            var c2 = new Course { Title = "Database Systems", Credits = 3, DepartmentID = d1.DepartmentID, InstructorID = i2.InstructorID };
            var c3 = new Course { Title = "Web Development", Credits = 3, DepartmentID = d2.DepartmentID, InstructorID = i1.InstructorID };
            var c4 = new Course { Title = "Enterprise Management", Credits = 3, DepartmentID = d3.DepartmentID, InstructorID = i3.InstructorID };
            context.Courses.AddRange(c1, c2, c3, c4);
            context.SaveChanges();

            var e1 = new Enrollment { CourseID = c1.CourseID, StudentID = s1.StudentID, Grade = 9.5m };
            var e2 = new Enrollment { CourseID = c2.CourseID, StudentID = s1.StudentID, Grade = 9.0m };
            var e3 = new Enrollment { CourseID = c1.CourseID, StudentID = s2.StudentID, Grade = 8.5m };
            var e4 = new Enrollment { CourseID = c3.CourseID, StudentID = s3.StudentID, Grade = 8.8m };
            var e5 = new Enrollment { CourseID = c4.CourseID, StudentID = s4.StudentID, Grade = 7.5m };
            context.Enrollments.AddRange(e1, e2, e3, e4, e5);
            context.SaveChanges();
        }
    }
}
