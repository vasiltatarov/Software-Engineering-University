USE SoftUni
GO
SELECT e.EmployeeID, e.FirstName, 
	CASE
	WHEN YEAR(p.StartDate) >= 2005 THEN NULL
	WHEN YEAR(p.StartDate) < 2005 THEN p.[Name]
	END AS [ProjectName]
FROM EmployeesProjects AS ep
RIGHT JOIN Employees AS e ON e.EmployeeID = ep.EmployeeID
RIGHT JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE ep.EmployeeID = 24