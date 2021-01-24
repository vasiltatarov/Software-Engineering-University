USE SoftUni

SELECT * INTO EmployeesWithHightSalaries FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesWithHightSalaries
WHERE ManagerID = 42

UPDATE EmployeesWithHightSalaries
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS [AverageSalary]
FROM EmployeesWithHightSalaries
GROUP BY DepartmentID