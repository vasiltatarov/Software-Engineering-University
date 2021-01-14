--First make Back up on database, to can restore it after changes 
--Right click on database/Tasks/Back up...

USE SoftUni;

UPDATE Employees
SET Salary *= 1.12
WHERE DepartmentID IN (1, 2, 4, 11);

SELECT Salary FROM Employees;

--To restore database and reverse changes
--Delete database without check on delete back up!
--Right click on Dtabases/Restore Dtabase...