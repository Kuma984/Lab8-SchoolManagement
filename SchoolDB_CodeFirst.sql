IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Departments] (
    [DepartmentID] int NOT NULL IDENTITY,
    [DepartmentName] nvarchar(max) NOT NULL,
    [Budget] decimal(18,2) NOT NULL,
    [StartDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Departments] PRIMARY KEY ([DepartmentID])
);

CREATE TABLE [Instructors] (
    [InstructorID] int NOT NULL IDENTITY,
    [LastName] nvarchar(max) NOT NULL,
    [FirstName] nvarchar(max) NOT NULL,
    [HireDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Instructors] PRIMARY KEY ([InstructorID])
);

CREATE TABLE [Students] (
    [StudentID] int NOT NULL IDENTITY,
    [LastName] nvarchar(max) NOT NULL,
    [FirstName] nvarchar(max) NOT NULL,
    [EnrollmentDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY ([StudentID])
);

CREATE TABLE [Courses] (
    [CourseID] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Credits] int NOT NULL,
    [DepartmentID] int NOT NULL,
    [InstructorID] int NULL,
    CONSTRAINT [PK_Courses] PRIMARY KEY ([CourseID]),
    CONSTRAINT [FK_Courses_Departments_DepartmentID] FOREIGN KEY ([DepartmentID]) REFERENCES [Departments] ([DepartmentID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Courses_Instructors_InstructorID] FOREIGN KEY ([InstructorID]) REFERENCES [Instructors] ([InstructorID])
);

CREATE TABLE [Enrollments] (
    [EnrollmentID] int NOT NULL IDENTITY,
    [CourseID] int NOT NULL,
    [StudentID] int NOT NULL,
    [Grade] decimal(18,2) NULL,
    CONSTRAINT [PK_Enrollments] PRIMARY KEY ([EnrollmentID]),
    CONSTRAINT [FK_Enrollments_Courses_CourseID] FOREIGN KEY ([CourseID]) REFERENCES [Courses] ([CourseID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Enrollments_Students_StudentID] FOREIGN KEY ([StudentID]) REFERENCES [Students] ([StudentID]) ON DELETE CASCADE
);

CREATE INDEX [IX_Courses_DepartmentID] ON [Courses] ([DepartmentID]);

CREATE INDEX [IX_Courses_InstructorID] ON [Courses] ([InstructorID]);

CREATE INDEX [IX_Enrollments_CourseID] ON [Enrollments] ([CourseID]);

CREATE INDEX [IX_Enrollments_StudentID] ON [Enrollments] ([StudentID]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261107130340_InitialCreate', N'10.0.14');

COMMIT;
GO

