CREATE DATABASE SoftUni;

USE SoftUni;

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
);

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY,
	AddressText NVARCHAR(80) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
);

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL 
);

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL, 
	MiddleName NVARCHAR(50) NOT NULL, 
	LastName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(80) NOT NULL,
	DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATETIME2 NOT NULL,
	Salary DECIMAL(7, 2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
);

INSERT INTO Towns([Name])
	VALUES
		('Sofia'),
		('Plovdiv'),
		('Varna'),
		('Burgas');

INSERT INTO Departments([Name])
	VALUES
		('Engineering'),
		('Sales'),
		('Marketing'),
		('Software Development'),
		('Quality Assurance');

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
	VALUES
		('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '02.01.2013', 3500.00),
		('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '03.02.2004', 4000.00),
		('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '08.28.2016', 525.25),
		('Georgi', 'Terziev', 'Ivanov', 'CEO', 2, '12.09.2007', 3000.00),
		('Peter', 'Pan', 'Pan', 'Intern', 3, '08.28.2016', 599.88);