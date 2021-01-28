USE Bank
GO
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan @minBalance DECIMAL(18, 4)
AS
SELECT [First Name], [Last Name]
	FROM(
		SELECT ac.FirstName AS [First Name], ac.LastName AS [Last Name], SUM(a.Balance) AS [total]
		FROM AccountHolders AS ac
		JOIN Accounts AS a ON a.AccountHolderId = ac.Id
		GROUP BY ac.FirstName, ac.LastName, ac.Id
		) AS [accountsWithTotalBalance]
WHERE [total] > @minBalance
ORDER BY [First Name], [Last Name]