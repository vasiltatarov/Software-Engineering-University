CREATE VIEW V_EmployeeNameJobTitle
AS
SELECT FirstName + ' ' + COALESCE(MiddleName + ' ', ' ') + LastName AS [Full Name], JobTitle
FROM Employees;

SELECT * FROM V_EmployeeNameJobTitle;