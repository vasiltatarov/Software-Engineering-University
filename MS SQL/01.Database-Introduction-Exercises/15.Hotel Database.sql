CREATE DATABASE Hotel;

USE Hotel;

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL, 
	Title NVARCHAR(50) NOT NULL, 
	Notes NVARCHAR(50)
);

CREATE TABLE Customers(
	AccountNumber INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(50) NOT NULL, 
	LastName NVARCHAR(50) NOT NULL, 
	PhoneNumber NVARCHAR(30) NOT NULL, 
	EmergencyName NVARCHAR(50), 
	EmergencyNumber NVARCHAR(30), 
	Notes NVARCHAR(50)
);

CREATE TABLE RoomStatus(
	RoomStatus NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(50)
);

CREATE TABLE RoomTypes(
	RoomType NVARCHAR(30) NOT NULL, 
	Notes NVARCHAR(50)
);

CREATE TABLE BedTypes(
	BedType NVARCHAR(30) NOT NULL, 
	Notes NVARCHAR(50)
);

CREATE TABLE Rooms(
	RoomNumber INT PRIMARY KEY,
	RoomType NVARCHAR(30) NOT NULL, 
	BedType NVARCHAR(30) NOT NULL,
	Rate INT NOT NULL, 
	RoomStatus NVARCHAR(30), 
	Notes NVARCHAR(30)
);

CREATE TABLE Payments(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	PaymentDate DATETIME2 NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	FirstDateOccupied DATETIME2 NOT NULL,
	LastDateOccupied DATETIME2 NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(15, 2) NOT NULL, 
	TaxRate INT,
	TaxAmount INT,
	PaymentTotal DECIMAL(15, 2) NOT NULL,
	Notes NVARCHAR(60)
);

CREATE TABLE Occupancies(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	DateOccupied DATETIME2 NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
	RateApplied INT,
	PhoneCharged DECIMAL(15, 2), 
	Notes NVARCHAR(60)
);

INSERT INTO Employees(FirstName, LastName, Title)
	VALUES
		('Vasko', 'Tatarov', 'Junior Software Developer'),
		('Pesho', 'Pashov', 'Cleaner'),
		('Gosho', 'Goshev', 'IOS Developer');

		
INSERT INTO Customers(FirstName, LastName, PhoneNumber)
	VALUES
		('donza', 'koduro', '+359 894 379 972'),
		('stamat', 'stamo', '088 653 3168'),
		('dimitrichko', 'dim', '088 511 2550');

INSERT INTO RoomStatus(RoomStatus)
	VALUES
		('Clean'),
		('Free'),
		('Not free');

INSERT INTO RoomTypes(RoomType)
	VALUES 
		('Apartment'),
		('Double'),
		('President Suite');

INSERT INTO BedTypes(BedType)
	VALUES 
		('Single'),
		('Double'),
		('Twice Double');

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate)
	VALUES 
		(5, 'Apartment', 'Single', 3),
		(3, 'Double', 'Double', 1),
		(4, 'President Suite', 'Twice Double', 2);

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, 
					TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal)
	VALUES
(1, '10.10.2020', 1, '10.10.2020', '10.15.2020', 3, 300.00, 20, NULL, 300.00),
(2, '10.05.2020', 1, '10.05.2020', '10.15.2020', 4, 400.00, 20, NULL, 400.00),
(3, '10.01.2020', 1, '10.01.2020', '10.15.2020', 5, 500.00, 20, NULL, 500.00);

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber)
	VALUES
		(1, GETDATE(), 1, 4),
		(2, GETDATE(), 2, 5),
		(3, GETDATE(), 3, 3);