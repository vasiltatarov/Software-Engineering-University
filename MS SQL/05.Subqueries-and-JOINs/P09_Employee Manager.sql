USE SoftUni
GO
SELECT e.EmployeeID, e.FirstName, e.ManagerID, em.FirstName
FROM Employees AS e
JOIN Employees AS em ON em.EmployeeID = e.ManagerID
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID ASC