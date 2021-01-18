USE Orders
GO
CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	Birthdate DATETIME2,
)
GO
INSERT INTO People([Name], Birthdate)
	VALUES
		('Victor', '2000-12-07 00:00:00.000'),
		('Steven', '1992-09-10 00:00:00.000'),
		('Stephen', '1910-09-19 00:00:00.000'),
		('John', '2010-01-06 00:00:00.000');
GO
INSERT INTO People([Name], Birthdate)
	VALUES
		('Vasko', '2000-02-19 00:00:00.000');
		GO
SELECT [Name],
	DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],
	DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months]
FROM People