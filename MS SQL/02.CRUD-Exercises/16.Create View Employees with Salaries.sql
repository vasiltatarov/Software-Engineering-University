USE SoftUni;

CREATE VIEW V_EmployeesSalaries
AS
SELECT FirstName, LastName, Salary 
FROM Employees;

SELECT * FROM V_EmployeesSalaries;