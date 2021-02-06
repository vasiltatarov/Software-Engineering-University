USE Diablo
GO

SELECT SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider], 
		COUNT(*) AS [Number Of Users]
FROM Users
GROUP BY SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email))
ORDER BY [Number Of Users] DESC, [Email Provider] ASC