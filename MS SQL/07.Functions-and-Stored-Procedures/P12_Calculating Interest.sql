CREATE PROCEDURE usp_CalculateFutureValueForAccount @accountID INT, @yearlyInterestRate FLOAT
AS
SELECT a.Id AS [Account Id], 
		ac.FirstName AS [First Name], 
		ac.LastName AS [Last Name], 
		a.Balance AS [Current Balance],
		dbo.ufn_CalculateFutureValue(a.Balance, @yearlyInterestRate, 5) AS [Balance in 5 years]
FROM Accounts AS a
JOIN AccountHolders AS ac ON ac.Id = a.AccountHolderId
WHERE a.Id = @accountID

GO

EXEC dbo.usp_CalculateFutureValueForAccount @accountID = 1, @yearlyInterestRate = 0.1