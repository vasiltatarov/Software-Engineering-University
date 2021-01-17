USE SoftUni;
GO
SELECT FirstName, LastName FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'