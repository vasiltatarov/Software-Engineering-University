USE Bank
GO

CREATE PROCEDURE usp_WithdrawMoney(@AccountId INT, @MoneyAmount DECIMAL(18, 4))
AS
BEGIN TRANSACTION
	DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @AccountId)

	IF (@account IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid account Id!', 16, 1)
		RETURN
	END

	IF (@MoneyAmount < 0)
	BEGIN
		ROLLBACK
		RAISERROR('Cannot withdraw negative amount of money!', 16, 1)
		RETURN
	END

	DECLARE @currentBalance DECIMAL(18, 4) = (SELECT Balance FROM Accounts WHERE Id = @AccountId)

	IF (@currentBalance < @MoneyAmount)
	BEGIN
		ROLLBACK
		RAISERROR('Sorry, but you have enough balance to withdraw!', 16, 1)
		RETURN
	END

	UPDATE Accounts
	SET Balance -= @MoneyAmount
	WHERE Id = @AccountId
	COMMIT

GO
EXEC usp_WithdrawMoney 5, 25
GO
SELECT * FROM Accounts WHERE Id = 5