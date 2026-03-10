CREATE DATABASE SchoolDB;

USE SchoolDB;

--Assignment-1 and Assignment-2--

CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100) UNIQUE,
    Location VARCHAR(100)
);


CREATE TABLE Teachers (
    TeacherID INT PRIMARY KEY,
    TeacherName VARCHAR(100),
    Email VARCHAR(100) UNIQUE,
    DepartmentID INT,
    HireDate DATE,

    FOREIGN KEY (DepartmentID)
    REFERENCES Departments(DepartmentID)
);

CREATE TABLE Students (
    StudentID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DateOfBirth DATE,
    Gender CHAR(1) CHECK (Gender IN ('M','F')),
    DepartmentID INT,
    AdmissionDate DATE,

    FOREIGN KEY (DepartmentID)
    REFERENCES Departments(DepartmentID)
);

CREATE TABLE Courses (
    CourseID INT PRIMARY KEY,
    CourseName VARCHAR(100),
    Credits INT CHECK (Credits BETWEEN 1 AND 5),
    DepartmentID INT,
    TeacherID INT,

    FOREIGN KEY (DepartmentID)
    REFERENCES Departments(DepartmentID),

    FOREIGN KEY (TeacherID)
    REFERENCES Teachers(TeacherID)
);

CREATE TABLE Enrollments (
    EnrollmentID INT PRIMARY KEY,
    StudentID INT,
    CourseID INT,
    EnrollmentDate DATE DEFAULT GETDATE(),

    FOREIGN KEY (StudentID)
    REFERENCES Students(StudentID),

    FOREIGN KEY (CourseID)
    REFERENCES Courses(CourseID)
);

CREATE TABLE Exams (
    ExamID INT PRIMARY KEY,
    CourseID INT,
    ExamDate DATE,
    ExamType VARCHAR(50),

    FOREIGN KEY (CourseID)
    REFERENCES Courses(CourseID)
);

CREATE TABLE Marks (
    MarkID INT PRIMARY KEY,
    StudentID INT,
    ExamID INT,
    MarksObtained INT CHECK (MarksObtained BETWEEN 0 AND 100),

    FOREIGN KEY (StudentID)
    REFERENCES Students(StudentID),

    FOREIGN KEY (ExamID)
    REFERENCES Exams(ExamID)
);

--Assignment 3 – ALTER TABLE--
--Add a column PhoneNumber to Students table.--
ALTER TABLE Students ADD PhoneNumber VARCHAR(15);

--Add Salary column to Teachers--
ALTER TABLE Teachers ADD Salary DECIMAL(10,2);

--Modify Salary datatype.
ALTER TABLE Teachers ALTER COLUMN Salary DECIMAL(12,2);

--Add CHECK constraint to Salary (salary > 20000).
ALTER TABLE Teachers ADD CONSTRAINT chk_salary CHECK (Salary > 20000);

--Drop PhoneNumber column.
ALTER TABLE Students DROP COLUMN PhoneNumber;

--Rename a column.
EXEC sp_rename 'Teachers.TeacherName', 'FullName', 'COLUMN';

--Assignment 4 – Insert Sample Data
INSERT INTO Departments VALUES
(1,'Computer Science','Block A'),
(2,'Mechanical','Block B'),
(3,'Electrical','Block C'),
(4,'Civil','Block D'),
(5,'Electronics','Block E');

INSERT INTO Teachers VALUES
(1,'John','john@school.com',1,'2021-06-10',50000),
(2,'David','david@school.com',2,'2020-04-15',55000),
(3,'Sarah','sarah@school.com',3,'2023-02-11',45000),
(4,'Emma','emma@school.com',4,'2022-08-20',60000),
(5,'Michael','michael@school.com',5,'2019-01-10',70000),
(6,'Daniel','daniel@school.com',1,'2024-01-05',40000),
(7,'Sophia','sophia@school.com',2,'2021-09-12',48000),
(8,'James','james@school.com',3,'2020-11-30',52000),
(9,'Olivia','olivia@school.com',4,'2022-03-18',46000),
(10,'William','william@school.com',5,'2023-07-25',42000);

INSERT INTO Students VALUES
(1,'Amit','Kumar','2006-05-10','M',1,'2023-06-01'),
(2,'Anita','Sharma','2005-03-12','F',1,'2023-06-01'),
(3,'Rahul','Verma','2007-07-21','M',2,'2023-06-01'),
(4,'Sneha','Patel','2006-01-15','F',2,'2023-06-01'),
(5,'Arjun','Reddy','2005-11-11','M',3,'2023-06-01'),
(6,'Priya','Nair','2006-02-20','F',3,'2023-06-01'),
(7,'Kiran','Das','2007-09-10','M',4,'2023-06-01'),
(8,'Neha','Kapoor','2006-12-05','F',4,'2023-06-01'),
(9,'Rohit','Singh','2005-08-19','M',5,'2023-06-01'),
(10,'Pooja','Joshi','2007-04-28','F',5,'2023-06-01'),
(11,'Akash','Yadav','2006-06-30','M',1,'2023-06-01'),
(12,'Asha','Gupta','2005-02-14','F',1,'2023-06-01'),
(13,'Vikram','Mehta','2007-01-09','M',2,'2023-06-01'),
(14,'Divya','Iyer','2006-10-16','F',2,'2023-06-01'),
(15,'Ravi','Chopra','2005-07-07','M',3,'2023-06-01'),
(16,'Meena','Bansal','2006-09-22','F',3,'2023-06-01'),
(17,'Varun','Mishra','2007-03-03','M',4,'2023-06-01'),
(18,'Nisha','Arora','2006-11-29','F',4,'2023-06-01'),
(19,'Suresh','Pillai','2005-12-25','M',5,'2023-06-01'),
(20,'Kavya','Shetty','2007-05-18','F',5,'2023-06-01');

INSERT INTO Courses VALUES
(1,'Database Systems',4,1,1),
(2,'Data Structures',3,1,6),
(3,'Thermodynamics',4,2,2),
(4,'Machine Design',3,2,7),
(5,'Circuit Analysis',4,3,3),
(6,'Power Systems',3,3,8),
(7,'Structural Engineering',4,4,4),
(8,'Geotechnical Eng',3,4,9),
(9,'Digital Electronics',4,5,5),
(10,'Microprocessors',3,5,10);

INSERT INTO Enrollments (EnrollmentID,StudentID,CourseID) VALUES
(1,1,1),(2,1,2),(3,2,1),(4,3,3),(5,4,4),
(6,5,5),(7,6,6),(8,7,7),(9,8,8),(10,9,9),
(11,10,10),(12,11,1),(13,12,2),(14,13,3),(15,14,4),
(16,15,5),(17,16,6),(18,17,7),(19,18,8),(20,19,9),
(21,20,10),(22,2,3),(23,3,4),(24,4,5),(25,5,6),
(26,6,7),(27,7,8),(28,8,9),(29,9,10),(30,10,1);

INSERT INTO Exams VALUES
(1,1,'2024-05-10','Midterm'),
(2,2,'2024-05-15','Midterm'),
(3,3,'2024-05-20','Midterm'),
(4,4,'2024-05-25','Final'),
(5,5,'2024-05-30','Final');

INSERT INTO Marks VALUES
(1,1,1,85),(2,2,1,78),(3,3,1,90),(4,4,1,67),(5,5,1,88),
(6,6,2,76),(7,7,2,81),(8,8,2,69),(9,9,2,92),(10,10,2,75),
(11,11,3,84),(12,12,3,73),(13,13,3,89),(14,14,3,77),(15,15,3,91),
(16,16,4,68),(17,17,4,80),(18,18,4,74),(19,19,4,86),(20,20,4,79),
(21,1,5,88),(22,2,5,76),(23,3,5,90),(24,4,5,65),(25,5,5,82),
(26,6,5,71),(27,7,5,87),(28,8,5,69),(29,9,5,93),(30,10,5,78);

--Assignment 5 –Write SQL Queries
--Find students from Computer Science department
SELECT * FROM Students WHERE DepartmentID = 1;

--Find teachers hired after 2022
SELECT * FROM Teachers WHERE HireDate > '2022-01-01';

--Find students whose name starts with 'A'
SELECT * FROM Students WHERE FirstName LIKE 'A%';

--Find courses having credits greater than 3
SELECT * FROM Courses WHERE Credits > 3;

--Find students born between 2005 and 2008
SELECT * FROM Students WHERE DateOfBirth BETWEEN '2005-01-01' AND '2008-12-31';

--Find students not belonging to Mechanical department
SELECT * FROM Students WHERE DepartmentID <> 2;

--Find teachers whose salary between 40000 and 70000
SELECT * FROM Teachers WHERE Salary BETWEEN 40000 AND 70000;

--Find courses not taught by TeacherID = 3
SELECT * FROM Courses WHERE TeacherID <> 3;

--Assignment 6 – GROUP_BY Queries
--Count students in each department
SELECT DepartmentID, COUNT(StudentID) AS TotalStudents
FROM Students GROUP BY DepartmentID;

--Find average marks per exam
SELECT ExamID, AVG(MarksObtained) AS AverageMarks
FROM Marks GROUP BY ExamID;

--Find total students enrolled per course
SELECT CourseID, COUNT(StudentID) AS TotalStudents
FROM Enrollments GROUP BY CourseID;

--Find maximum marks scored in each exam
SELECT ExamID, MAX(MarksObtained) AS HighestMarks
FROM Marks GROUP BY ExamID;

--Find minimum marks per course
SELECT e.CourseID, MIN(m.MarksObtained) AS MinimumMarks
FROM Exams e INNER JOIN Marks m
ON e.ExamID = m.ExamID GROUP BY e.CourseID;

--Find departments having more than 5 students
SELECT DepartmentID, COUNT(StudentID) AS TotalStudents
FROM Students GROUP BY DepartmentID
HAVING COUNT(StudentID) > 5;


--Assignment 7 – JOINS
--Show students with department names
SELECT s.StudentID,s.FirstName,s.LastName,d.DepartmentName
FROM Students s INNER JOIN Departments d ON s.DepartmentID = d.DepartmentID;

--Show courses with teacher names
SELECT c.CourseName,t.FullName
FROM Courses c INNER JOIN Teachers t ON c.TeacherID = t.TeacherID;

--Show student name and enrolled courses
SELECT s.FirstName,s.LastName,c.CourseName
FROM Students s INNER JOIN Enrollments e ON s.StudentID = e.StudentID
INNER JOIN Courses c ON e.CourseID = c.CourseID;

--Show students with exam marks
SELECT s.FirstName,s.LastName,e.ExamType,m.MarksObtained
FROM Students s INNER JOIN Marks m ON s.StudentID = m.StudentID
INNER JOIN Exams e ON m.ExamID = e.ExamID;

--Show all courses and teachers (even if no teacher assigned)
SELECT c.CourseName,t.FullName
FROM Courses c LEFT JOIN Teachers t ON c.TeacherID = t.TeacherID;

--Show teachers who are not assigned to any course
SELECT t.FullName FROM Teachers t
LEFT JOIN Courses c ON t.TeacherID = c.TeacherID WHERE c.CourseID IS NULL;

--Assignment 8 – Subqueries
--Find students whose marks are greater than average marks
SELECT StudentID, MarksObtained FROM Marks
WHERE MarksObtained > (SELECT AVG(MarksObtained)FROM Marks);

--Find courses with maximum credits
SELECT * FROM Courses
WHERE Credits = (SELECT MAX(Credits)FROM Courses);

--Find students enrolled in more than 2 courses
SELECT StudentID FROM Enrollments GROUP BY StudentID HAVING COUNT(CourseID) > 2;

--Find teachers working in the same department as teacher 'John'
SELECT * FROM Teachers
WHERE DepartmentID = (SELECT DepartmentID FROM Teachers WHERE FullName = 'John');

--Find students who scored highest marks in an exam
SELECT * FROM Marks
WHERE MarksObtained = ( SELECT MAX(MarksObtained)FROM Marks);

--Find departments having maximum number of students
SELECT DepartmentID FROM Students
GROUP BY DepartmentID HAVING COUNT(StudentID) = (
SELECT MAX(StudentCount)
 FROM (
        SELECT COUNT(StudentID) AS StudentCount
        FROM Students GROUP BY DepartmentID
    ) AS DeptCount
);

--Assignment 9 – Views
--View 1 – Student basic information with department name
CREATE VIEW StudentDepartmentView AS
SELECT s.StudentID,s.FirstName + ' ' + s.LastName AS StudentName,d.DepartmentName
FROM Students s INNER JOIN Departments d ON s.DepartmentID = d.DepartmentID;

SELECT * FROM StudentDepartmentView;

--View 2 –Student course enrollment view
CREATE VIEW StudentCourseEnrollmentView AS
SELECT s.FirstName + ' ' + s.LastName AS StudentName,c.CourseName,e.EnrollmentDate
FROM Students s INNER JOIN Enrollments e ON s.StudentID = e.StudentID
INNER JOIN Courses c ON e.CourseID = c.CourseID;

SELECT * FROM StudentCourseEnrollmentView;

--View 3 – Exam result view
CREATE VIEW ExamResultView AS
SELECT s.FirstName + ' ' + s.LastName AS StudentName,c.CourseName,e.ExamType,m.MarksObtained
FROM Students s 
INNER JOIN Marks m ON s.StudentID = m.StudentID
INNER JOIN Exams e ON m.ExamID = e.ExamID
INNER JOIN Courses c ON e.CourseID = c.CourseID;

SELECT * FROM ExamResultView;

--Update data through view (where possible)
UPDATE Students
SET FirstName = 'Amit',LastName = 'Sharma'
WHERE StudentID = 1;

--Drop views
DROP VIEW StudentDepartmentView;
DROP VIEW StudentCourseEnrollmentView;
DROP VIEW ExamResultView;

--Assignment 10 – Indexes
--Create index on Student LastName
CREATE INDEX idx_student_lastname ON Students(LastName);

--Create index on Teacher Email
CREATE INDEX idx_teacher_email ON Teachers(Email);

--Create composite index on StudentID + CourseID in Enrollments table
CREATE INDEX idx_enrollment_student_course ON Enrollments(StudentID, CourseID);

--Create unique index on DepartmentName
CREATE UNIQUE INDEX idx_department_name ON Departments(DepartmentName);

--Drop an index
DROP INDEX idx_student_lastname ON Students;
