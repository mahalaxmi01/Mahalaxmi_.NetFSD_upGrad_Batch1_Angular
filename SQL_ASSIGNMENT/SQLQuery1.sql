create database AssignmentDB
use AssignmentDB

CREATE TABLE Worker (
	WORKER_ID INT PRIMARY KEY IDENTITY(1,1),
	FIRST_NAME VARCHAR(25),
	LAST_NAME VARCHAR(25),
	SALARY INT,
	JOINING_DATE DATETIME,
	DEPARTMENT CHAR(25)
);

CREATE TABLE Bonus (
	WORKER_REF_ID INT,
	BONUS_AMOUNT INT,
	BONUS_DATE DATETIME,
	FOREIGN KEY (WORKER_REF_ID)
		REFERENCES Worker(WORKER_ID)
        ON DELETE CASCADE
);

CREATE TABLE Title (
	WORKER_REF_ID INT,
	WORKER_TITLE CHAR(25),
	AFFECTED_FROM DATETIME,
	FOREIGN KEY (WORKER_REF_ID)
		REFERENCES Worker(WORKER_ID)
        ON DELETE CASCADE
);
insert into Worker 
(FIRST_NAME, LAST_NAME, SALARY, JOINING_DATE, DEPARTMENT)
values
('monika','arora',100000,'2014-02-20 09:00:00','hr'),
('niharika','verma',80000,'2014-06-11 09:00:00','admin'),
('vishal','singhal',300000,'2014-02-20 09:00:00','hr'),
('Amitabh','singh',500000,'2014-02-20 09:00:00','admin'),
('vivek','bhati',500000,'2014-06-11 09:00:00','admin'),
('Vipul','Diwan	',200000,'2014-06-11 09:00:00','Account'),
('Satish','Kumar',75000,'2014-01-20 09:00:00','Account'),
('Geetika','Chauhan',90000,'2014-04-11 09:00:00','Admin');

insert into Bonus
(WORKER_REF_ID,BONUS_DATE,BONUS_AMOUNT)
values
(1,'2016-02-20 00:00:00',5000),
(2,'2016-06-11 00:00:00',3000),
(3,'2016-02-20 00:00:00',4000),
(1,'2016-02-20 00:00:00',4500),
(2,'2016-06-11 00:00:00',3500);

insert into Title
(WORKER_REF_ID,WORKER_TITLE,AFFECTED_FROM)
values
(1,'Manager','2016-02-20 00:00:00'),
(2,'Executive','2016-06-11 00:00:00'),
(8,'Executive','2016-06-11 00:00:00'),
(5,'Manager','2016-06-11 00:00:00'),
(4,'Asst. Manager','2016-06-11 00:00:00'),
(7,'Executive','2016-06-11 00:00:00'),
(6,'Lead','2016-06-11 00:00:00'),
(3,'Lead','2016-06-11 00:00:00');


--Write an SQL query to fetch “FIRST_NAME” from Worker table using the alias name as <WORKER_NAME>.
SELECT FIRST_NAME AS WORKER_NAME FROM Worker;

--Write an SQL query to fetch “FIRST_NAME” from Worker table in upper case.
SELECT UPPER(FIRST_NAME) AS FIRST_NAME FROM Worker;

--Write an SQL query to fetch unique values of DEPARTMENT from Worker table.
SELECT DISTINCT DEPARTMENT FROM Worker;

-- Write an SQL query to print the first three characters of  FIRST_NAME from Worker table.
SELECT SUBSTRING(FIRST_NAME, 1, 3) AS FIRST_NAME FROM Worker;

--Write an SQL query to find the position of the alphabet (‘a’) in the first name column ‘Amitabh’ from Worker table.
SELECT CHARINDEX('a', FIRST_NAME) AS Position FROM Worker WHERE FIRST_NAME = 'Amitabh';

--Write an SQL query to print the FIRST_NAME from Worker table after removing white spaces from the right side.
SELECT RTRIM(FIRST_NAME) AS FIRST_NAME FROM Worker;

--Write an SQL query to print the DEPARTMENT from Worker table after removing white spaces from the left side.
SELECT LTRIM(DEPARTMENT) AS DEPARTMENT FROM Worker;

--Write an SQL query that fetches the unique values of DEPARTMENT from Worker table and prints its length.
SELECT DISTINCT DEPARTMENT, LEN(DEPARTMENT) AS Length FROM Worker;

--Write an SQL query to print the FIRST_NAME from Worker table after replacing ‘a’ with ‘A’.
SELECT REPLACE(FIRST_NAME, 'a', 'A') AS FIRST_NAME FROM Worker;

-- Write an SQL query to print the FIRST_NAME and LAST_NAME from Worker table into a single column COMPLETE_NAME. A space char should separate them.
SELECT CONCAT(FIRST_NAME, ' ', LAST_NAME) AS COMPLETE_NAME FROM Worker;

-- Write an SQL query to print all Worker details from the Worker table order by FIRST_NAME Ascending.
SELECT * FROM Worker ORDER BY FIRST_NAME ASC;

--Write an SQL query to print all Worker details from the Worker table order by FIRST_NAME Ascending and DEPARTMENT Descending.
SELECT * FROM Worker ORDER BY FIRST_NAME ASC, DEPARTMENT DESC;

--Write an SQL query to print details for Workers with the first name as “Vipul” and “Satish” from Worker table.
SELECT * FROM Worker WHERE FIRST_NAME IN ('Vipul', 'Satish');

--Write an SQL query to print details of workers excluding first names, “Vipul” and “Satish” from Worker table.
SELECT * FROM Worker WHERE FIRST_NAME NOT IN ('Vipul', 'Satish');

--Write an SQL query to print details of Workers with DEPARTMENT name as “Admin”.
SELECT * FROM Worker WHERE DEPARTMENT = 'Admin';

--Write an SQL query to print details of the Workers whose FIRST_NAME contains ‘a’.
SELECT * FROM Worker WHERE FIRST_NAME LIKE '%a%';

-- Write an SQL query to print details of the Workers whose FIRST_NAME ends with ‘a’.
SELECT * FROM Worker WHERE FIRST_NAME LIKE '%a';

--Write an SQL query to print details of the Workers whose FIRST_NAME ends with ‘h’ and contains six alphabets.
SELECT * FROM Worker WHERE FIRST_NAME LIKE '_____h';

--Write an SQL query to print details of the Workers whose SALARY lies between 100000 and 500000.
SELECT * FROM Worker WHERE SALARY BETWEEN 100000 AND 500000;

--Write an SQL query to print details of the Workers who have joined in Feb’2014.
SELECT * FROM Worker WHERE MONTH(JOINING_DATE) = 2 AND YEAR(JOINING_DATE) = 2014;

-- Write an SQL query to fetch worker names with salaries >= 50000 and <= 100000.
SELECT FIRST_NAME FROM Worker WHERE SALARY >= 50000 AND SALARY <= 100000;

--Write an SQL query to fetch the no. of workers for each department in the descending order.
SELECT DEPARTMENT, COUNT(*) AS WorkerCount FROM Worker GROUP BY DEPARTMENT ORDER BY WorkerCount DESC;

--Write an SQL query to print details of the Workers who are also Managers
SELECT * FROM Worker WHERE DEPARTMENT = 'Manager';

--Write an SQL query to show the current date and time.
SELECT GETDATE() AS CurrentDateTime;

--Write an SQL query to show the top n (say 10) records of a table.
SELECT TOP 10 * FROM Worker;