SELECT e.FirstName, e.LastName, e.HireDate, d.[Name]
FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE e.HireDate > '01-01-1999' AND d.[Name] LIKE 'Sales' OR d.[Name] LIKE 'Finance'
ORDER BY e.HireDate ASC