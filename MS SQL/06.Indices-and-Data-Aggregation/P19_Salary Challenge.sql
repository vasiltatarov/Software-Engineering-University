USE SoftUni

SELECT TOP(10) e1.FirstName, e1.LastName, e1.DepartmentID
FROM Employees AS e1
WHERE e1.Salary > (
				SELECT AVG(Salary) AS [AvgSalary]
				FROM Employees AS e2
				WHERE e2.DepartmentID = e1.DepartmentID
				GROUP BY DepartmentID
				)
ORDER BY e1.DepartmentID ASC