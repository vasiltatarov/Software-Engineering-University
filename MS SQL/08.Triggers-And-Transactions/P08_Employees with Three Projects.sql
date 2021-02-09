USE SoftUni
GO

CREATE PROCEDURE usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN TRANSACTION
DECLARE @employee INT = (SELECT EmployeeID FROM Employees WHERE EmployeeID = @emloyeeId)
DECLARE @project INT = (SELECT ProjectID FROM Projects WHERE ProjectID = @projectID)

	IF (@employee IS NULL OR @project IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Employee or project does not exist!', 16, 1)
		RETURN
	END

DECLARE @employeeProjects INT = (SELECT COUNT(*) FROM EmployeesProjects
								 WHERE EmployeeID = @emloyeeId
								 GROUP BY EmployeeID)

	IF (@employeeProjects >= 3)
	BEGIN
		ROLLBACK
		RAISERROR('The employee has too many projects!', 16, 1)
		RETURN
	END
	ELSE
		INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
			VALUES (@emloyeeId, @projectID)
COMMIT

GO
EXEC usp_AssignProject 2, 4
GO
SELECT * FROM EmployeesProjects
WHERE EmployeeID = 2