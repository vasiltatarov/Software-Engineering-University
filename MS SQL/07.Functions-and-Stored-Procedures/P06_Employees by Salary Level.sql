USE SoftUni
GO

CREATE PROCEDURE usp_EmployeesBySalaryLevel @salaryLevel NVARCHAR(50)
AS
SELECT FirstName AS [First Name], LastName AS [Last Name] FROM(
			SELECT FirstName, LastName, Salary, dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
			FROM Employees
			) AS [SalaryLevel]
WHERE [Salary Level] LIKE @salaryLevel
GO
EXEC usp_EmployeesBySalaryLevel @salaryLevel = 'high'