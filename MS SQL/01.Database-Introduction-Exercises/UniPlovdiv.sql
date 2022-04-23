-- Create Database
CREATE DATABASE UniPlovdiv

-- Use Database
USE UniPlovdiv

-- Create Tables and Relationships
CREATE TABLE Nationalities(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
);

CREATE TABLE Subjects(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
);

CREATE TABLE Students(
	Id INT PRIMARY KEY IDENTITY,
	FacultyNumber NVARCHAR(10) NOT NULL UNIQUE,
	FirstName NVARCHAR(40) NOT NULL,
	LastName NVARCHAR(40) NOT NULL,
	Birthdate DATE NOT NULL,
	NationalityId INT NOT NULL FOREIGN KEY REFERENCES Nationalities(Id),
	City NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(50) NOT NULL
);

CREATE TABLE StudentSubjects(
	StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(Id),
	SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(Id),
	CONSTRAINT Id PRIMARY KEY (StudentId, SubjectId)
);

CREATE TABLE Grades(
	Id INT PRIMARY KEY IDENTITY,
	[Value] TINYINT NOT NULL,
	StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(Id),
	SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(Id)
);

-- Insert data in tables
INSERT INTO Nationalities (Name)
	VALUES
		('Bulgaria'),
		('Italy'),
		('Spain'),
		('Greece'),
		('England');

INSERT INTO Subjects (Name)
	VALUES
		('English'),
		('Math'),
		('IT'),
		('Programing');

INSERT INTO Students (FacultyNumber, FirstName, LastName, Birthdate, NationalityId, City, [Address])
	VALUES
		('0045756598', 'Andi', 'Garcia', '2000-02-19', 1, 'Plovdiv', 'Smirnenski 45'),
		('0065165112', 'Vesi', 'Veleva', '1977-11-27', 2, 'Kardzhali', 'Dimitar Blagoev 21'),
		('0064511961', 'Gandi', 'Guneva', '1999-09-01', 3, 'Sofia', 'Smirnenski 65');

INSERT INTO StudentSubjects (StudentId, SubjectId)
	VALUES
		(2, 1),
		(2, 2),
		(2, 3),
		(2, 4),
		(3, 2),
		(3, 3),
		(4, 3);

INSERT INTO Grades ([Value], StudentId, SubjectId)
	VALUES
		(5, 2, 1),
		(5, 2, 2),
		(6, 2, 3),
		(2, 2, 4),
		(3, 3, 2),
		(4, 3, 3),
		(6, 4, 3);

-- CRUD Operations

-- 1. Update Data
UPDATE Students
	SET City = 'Kirkovo', [Address] = 'Shipka 12'
	WHERE Id = 3;

-- 2. Delete Data
DELETE FROM Grades WHERE Id = 7;

-- Select

SELECT * FROM Subjects;
SELECT * FROM Students;
SELECT * FROM Grades ORDER BY [Value] ASC, SubjectId ASC;
SELECT Id, FacultyNumber, FirstName, LastName, City 
	FROM Students 
	ORDER BY FacultyNumber;

-- JOIN, Like, Where, Order
SELECT FacultyNumber, FirstName, LastName, n.[Name] AS 'From'
	FROM Students AS s
	JOIN Nationalities AS n ON n.Id = s.NationalityId
	ORDER BY s.Id;

SELECT s.FacultyNumber, s.FirstName + ' ' + s.LastName AS [Name], sub.[Name]
	FROM Students AS s
	JOIN StudentSubjects as ss ON ss.StudentId = s.Id
	JOIN Subjects as sub ON sub.Id = ss.SubjectId

SELECT s.FacultyNumber, s.FirstName + ' ' + s.LastName AS [Name], sub.[Name]
	FROM Students AS s
	JOIN StudentSubjects as ss ON ss.StudentId = s.Id
	JOIN Subjects as sub ON sub.Id = ss.SubjectId
	WHERE s.FacultyNumber LIKE '0045756598';

SELECT s.FacultyNumber, s.FirstName + ' ' + s.LastName AS [Name], sub.[Name], g.[Value]
	FROM Students AS s
	JOIN StudentSubjects as ss ON ss.StudentId = s.Id
	JOIN Subjects as sub ON sub.Id = ss.SubjectId
	JOIN Grades AS g ON g.StudentId = ss.StudentId AND g.SubjectId = ss.SubjectId

SELECT s.FacultyNumber, s.FirstName + ' ' + s.LastName AS [Name], sub.[Name], g.[Value]
	FROM Students AS s
	JOIN StudentSubjects as ss ON ss.StudentId = s.Id
	JOIN Subjects as sub ON sub.Id = ss.SubjectId
	JOIN Grades AS g ON g.StudentId = ss.StudentId AND g.SubjectId = ss.SubjectId
	WHERE s.FacultyNumber LIKE '0045756598'
	ORDER BY g.Value;