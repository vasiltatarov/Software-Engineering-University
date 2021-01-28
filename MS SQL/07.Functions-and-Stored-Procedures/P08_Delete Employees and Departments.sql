USE SoftUni
GO
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
-- DELETE EmployeesProjects
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
						SELECT EmployeeID FROM Employees
						WHERE DepartmentID = @departmentId
						)
-- SET ManagerID on NULL
	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (
						SELECT EmployeeID FROM Employees
						WHERE DepartmentID = @departmentId
						)
-- ALTER COLUMN ManagerID to ALLOW NULL
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT
--
	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (
						SELECT EmployeeID FROM Employees
						WHERE DepartmentID = @departmentId
						)
	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*) FROM Employees
	WHERE DepartmentID = @departmentId
END