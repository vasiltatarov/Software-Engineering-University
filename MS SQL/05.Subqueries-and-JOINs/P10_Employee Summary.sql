USE SoftUni
GO
SELECT TOP(50) e.EmployeeID, 
		e.FirstName + ' ' + e.LastName AS EmployeeName,
		em.FirstName + ' ' + em.LastName AS ManagerName,
		d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Employees AS em ON em.EmployeeID = e.ManagerID
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID ASC