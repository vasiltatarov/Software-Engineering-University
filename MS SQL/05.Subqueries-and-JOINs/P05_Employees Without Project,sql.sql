SELECT TOP(3) e.EmployeeID, e.FirstName
FROM Employees AS e
LEFT OUTER JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID ASC