CREATE PROCEDURE usp_SearchForFiles(@fileExtension VARCHAR(MAX))
AS
SELECT Id, Name, CONCAT(Size, 'KB') AS [Size]
FROM Files
WHERE Name LIKE '%.' + @fileExtension

GO
EXEC usp_SearchForFiles 'txt'