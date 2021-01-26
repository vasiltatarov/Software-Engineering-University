USE SoftUni
GO
CREATE PROCEDURE usp_GetTownsStartingWith @StartWith NVARCHAR(MAX)
AS
SELECT [Name] FROM Towns
WHERE [Name] LIKE @StartWith + '%'
GO
EXEC usp_GetTownsStartingWith @StartWith = 'b'