--Views --
--Assignment 1
--create
CREATE VIEW vw_StudentDepartment AS
SELECT s.StudentID,s.FirstName + ' ' + s.LastName AS StudentName,d.DepartmentName,s.AdmissionDate
FROM Students s
INNER JOIN Departments d ON s.DepartmentID = d.DepartmentID;
--Retrieve all records from the view
SELECT * FROM vw_StudentDepartment;
--Filter students from Computer Science department
SELECT * FROM vw_StudentDepartment WHERE DepartmentName = 'Computer Science';
--Drop the view
DROP VIEW vw_StudentDepartment;

--Assignment 2
--Create view
CREATE VIEW vw_StudentCourses AS
SELECT s.StudentID,s.FirstName + ' ' + s.LastName AS StudentName,c.CourseName,e.EnrollmentDate
FROM Students s
INNER JOIN Enrollments e ON s.StudentID = e.StudentID
INNER JOIN Courses c ON e.CourseID = c.CourseID;
--Show courses taken by StudentID = 5
SELECT * FROM vw_StudentCourses WHERE StudentID = 5;
--Count courses taken by each student
SELECT StudentName, COUNT(CourseName) AS TotalCourses FROM vw_StudentCourses GROUP BY StudentName;
--List students enrolled after 2024
SELECT * FROM vw_StudentCourses WHERE EnrollmentDate > '2024-01-01';


--Assignment 3
--create view
CREATE VIEW vw_ExamResults AS
SELECT s.FirstName + ' ' + s.LastName AS StudentName,c.CourseName,e.ExamType,m.MarksObtained
FROM Students s
INNER JOIN Marks m ON s.StudentID = m.StudentID
INNER JOIN Exams e ON m.ExamID = e.ExamID
INNER JOIN Courses c ON e.CourseID = c.CourseID;
--Retrieve students scoring more than 80
SELECT * FROM vw_ExamResults WHERE MarksObtained > 80;
--Retrieve top scorers in each exam
SELECT * FROM vw_ExamResults
WHERE MarksObtained = (SELECT MAX(MarksObtained)FROM Marks);
--Find students who failed
SELECT * FROM vw_ExamResults WHERE MarksObtained < 35;


--Assignment 4
--create view
CREATE VIEW vw_DepartmentStudentCount AS
SELECT d.DepartmentName,
    COUNT(s.StudentID) AS TotalStudents
FROM Departments d
LEFT JOIN Students s
ON d.DepartmentID = s.DepartmentID
GROUP BY d.DepartmentName;
--Departments with more than 10 students
SELECT * FROM vw_DepartmentStudentCount WHERE TotalStudents > 10;
--Sort departments by highest student count
SELECT * FROM vw_DepartmentStudentCount ORDER BY TotalStudents DESC;

--Stored Procedures Assignments
--Assignment 1
--Insert Student Procedure
CREATE PROCEDURE sp_InsertStudent
    @StudentID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Gender VARCHAR(10),
    @DepartmentID INT,
    @AdmissionDate DATE
AS
BEGIN
    INSERT INTO Students
    (StudentID, FirstName, LastName, Gender, DepartmentID, AdmissionDate)
    VALUES
    (@StudentID, @FirstName, @LastName, @Gender, @DepartmentID, @AdmissionDate);
END;
--Execute Procedure
EXEC sp_InsertStudent 21,'Rahul','Kumar','M',2,'2024-07-01';
--Verify
SELECT * FROM Students;


--Assignment 2
--Get Students By Department
CREATE PROCEDURE sp_GetStudentsByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        StudentID,
        FirstName + ' ' + LastName AS StudentName,
        AdmissionDate
    FROM Students
    WHERE DepartmentID = @DepartmentID;
END;
--Execute procedure for DepartmentID = 2
EXEC sp_GetStudentsByDepartment 2;
--Execute for DepartmentID = 3
EXEC sp_GetStudentsByDepartment 3;

--Assignment 3
--Course Enrollment Procedure
CREATE PROCEDURE sp_EnrollStudent
    @StudentID INT,
    @CourseID INT
AS
BEGIN
    INSERT INTO Enrollments (StudentID, CourseID, EnrollmentDate)
    VALUES (@StudentID, @CourseID, GETDATE());
END;

EXEC sp_EnrollStudent 3, 2;

--Assignment 4
--Student Marks Procedure
CREATE PROCEDURE sp_GetStudentMarks
    @StudentID INT
AS
BEGIN
    SELECT 
        s.FirstName + ' ' + s.LastName AS StudentName,
        c.CourseName,
        e.ExamType,
        m.MarksObtained
    FROM Students s
    INNER JOIN Marks m ON s.StudentID = m.StudentID
    INNER JOIN Exams e ON m.ExamID = e.ExamID
    INNER JOIN Courses c ON e.CourseID = c.CourseID
    WHERE s.StudentID = @StudentID;
END;

EXEC sp_GetStudentMarks 1;

--Assignment 5
CREATE PROCEDURE sp_UpdateMarks
    @MarkID INT,
    @NewMarks INT
AS
BEGIN
    UPDATE Marks
    SET MarksObtained = @NewMarks
    WHERE MarkID = @MarkID;

    SELECT * FROM Marks WHERE MarkID = @MarkID;
END;

EXEC sp_UpdateMarks 2, 85;

--Delete Enrollment
CREATE PROCEDURE sp_DeleteEnrollment
    @EnrollmentID INT
AS
BEGIN
    DELETE FROM Enrollments
    WHERE EnrollmentID = @EnrollmentID;
END;

EXEC sp_DeleteEnrollment 3;

SELECT * FROM Enrollments;


--User Defined Functions Assignments
--Assignment 1 -Calculate Grade (Scalar Function)
CREATE FUNCTION fn_GetGrade
(
    @MarksObtained INT
)
RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @Grade VARCHAR(10)

    IF @MarksObtained >= 90
        SET @Grade = 'A'
    ELSE IF @MarksObtained >= 75
        SET @Grade = 'B'
    ELSE IF @MarksObtained >= 60
        SET @Grade = 'C'
    ELSE
        SET @Grade = 'Fail'

    RETURN @Grade
END;
--Use this function to display grades in exam results.
SELECT StudentID,MarksObtained,dbo.fn_GetGrade(MarksObtained) AS Grade FROM Marks;

--Assignment 2 -Student Age Function
CREATE FUNCTION fn_GetStudentAge
(
    @DateOfBirth DATE
)
RETURNS INT
AS
BEGIN
    DECLARE @Age INT

    SET @Age = DATEDIFF(YEAR, @DateOfBirth, GETDATE())

    RETURN @Age
END;
--Use function to display student age.
SELECT StudentID,DateOfBirth,dbo.fn_GetStudentAge(DateOfBirth) AS Age FROM Students;

--Assignment 3 – Total Marks Function
CREATE FUNCTION fn_GetTotalMarks
(
    @StudentID INT
)
RETURNS INT
AS
BEGIN
    DECLARE @TotalMarks INT

    SELECT @TotalMarks = SUM(MarksObtained)
    FROM Marks
    WHERE StudentID = @StudentID

    RETURN @TotalMarks
END;

SELECT StudentID,dbo.fn_GetTotalMarks(StudentID) AS TotalMarks FROM Students;

--Assignment 4 – Student Courses Function (Table Valued)
CREATE FUNCTION fn_GetStudentCourses
(
    @StudentID INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        c.CourseName,
        e.EnrollmentDate
    FROM Enrollments e
    INNER JOIN Courses c
    ON e.CourseID = c.CourseID
    WHERE e.StudentID = @StudentID
);

SELECT * FROM dbo.fn_GetStudentCourses(1);

--Assignment 5 – Department Students Function (Table Valued)
CREATE FUNCTION fn_GetDepartmentStudents
(
    @DepartmentID INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        s.StudentID,
        s.FirstName + ' ' + s.LastName AS StudentName,
        s.AdmissionDate
    FROM Students s
    WHERE s.DepartmentID = @DepartmentID
);

SELECT * FROM dbo.fn_GetDepartmentStudents(2);