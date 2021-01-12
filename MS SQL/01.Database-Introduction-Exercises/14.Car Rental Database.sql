CREATE DATABASE CarRental;

USE CarRental;

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	DailyRate INT,
	WeeklyRate INT,
	MonthlyRate INT,
	WeekendRate INT
);

CREATE TABLE Cars (
	Id INT PRIMARY KEY IDENTITY, 
	PlateNumber NVARCHAR(40) NOT NULL, 
	Manufacturer NVARCHAR(40) NOT NULL, 
	Model NVARCHAR(40) NOT NULL, 
	CarYear INT NOT NULL, 
	CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id), 
	Doors INT NOT NULL, 
	Picture VARBINARY(MAX), 
	Condition NVARCHAR(MAX), 
	Available BIT NOT NULL
);

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(50) NOT NULL, 
	LastName NVARCHAR(50) NOT NULL, 
	Title NVARCHAR(50) NOT NULL, 
	Notes NVARCHAR(50)
);

CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY,  
	DriverLicenceNumber INT NOT NULL, 
	FullName NVARCHAR(100) NOT NULL, 
	[Address] NVARCHAR(50) NOT NULL, 
	City NVARCHAR(50) NOT NULL, 
	ZIPCode INT, 
	Notes NVARCHAR(50)
);

CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT NOT NULL FOREIGN KEY REFERENCES Employees(Id), 
	CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(Id), 
	CarId INT NOT NULL FOREIGN KEY REFERENCES Cars(Id), 
	TankLevel INT NOT NULL, 
	KilometrageStart DECIMAL(7, 3) NOT NULL, 
	KilometrageEnd DECIMAL(7, 3) NOT NULL, 
	TotalKilometrage DECIMAL(7, 3) NOT NULL, 
	StartDate DATETIME2 NOT NULL, 
	EndDate DATETIME2 NOT NULL, 
	TotalDays INT NOT NULL, 
	RateApplied DECIMAL(7, 2),
	TaxRate DECIMAL(7, 2) NOT NULL,
	OrderStatus NVARCHAR(40),
	Notes NVARCHAR(50)
);

INSERT INTO Categories(CategoryName)
	VALUES	
		('Coupe'),
		('Sedan'),
		('Van');

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Condition, Available)
	VALUES
		('K3146BK', 'Germany', 'BMW E90', 2006, 2, 4, 'Used', 1),
		('K8440BB', 'French', 'Peugeot 307', 2002, 2, 4, 'Used', 1),
		('K6360BK', 'French', 'Peugeot 106', 1994, 1, 2, 'Used', 1);

INSERT INTO Employees(FirstName, LastName, Title)
	VALUES
		('Pesho', 'Peshev', 'Policeman'),
		('salim', 'Baba', 'Security'),
		('Donza', 'Coduro', 'Cleaner');

INSERT INTO Customers(DriverLicenceNumber, FullName, [Address], City)
	VALUES
		('08756941', 'Ilia Mandrata', 'Kirkovo', 'Kirkovo'),
		('07542625', 'Ivaylo', 'Iakovica', 'Kirkovo'),
		('98546552', 'Mamalev', 'Kirkovo', 'Kirkovo');

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, 
						TotalKilometrage, StartDate, EndDate, TotalDays, TaxRate)
	VALUES
		(1, 1, 3, 23, 8952.000, 9245.000, (9245.000 - 8952.000), '10.10.2020', GETDATE(), DATEDIFF(DAY, '10.10.2020', GETDATE()), 250.00),
		(1, 1, 3, 23, 5725.000, 6200.000, (6200.000 - 5725.000), '10.10.2020', GETDATE(), DATEDIFF(DAY, '10.10.2020', GETDATE()), 350.00);