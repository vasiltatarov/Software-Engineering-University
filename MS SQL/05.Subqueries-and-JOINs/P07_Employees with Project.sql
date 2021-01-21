USE SoftUni
GO
SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name] FROM Projects AS p
JOIN EmployeesProjects AS ep ON ep.ProjectID = p.ProjectID
JOIN Employees AS e ON e.EmployeeID = ep.EmployeeID
WHERE p.StartDate > '08-13-2002' AND p.EndDate IS NULL
ORDER BY e.EmployeeID ASC