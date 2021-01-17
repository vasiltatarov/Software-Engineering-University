USE SoftUni
GO
SELECT TownID, [Name] FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name] ASC