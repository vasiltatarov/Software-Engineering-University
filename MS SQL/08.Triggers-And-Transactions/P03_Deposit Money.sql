USE Bank
GO

CREATE PROCEDURE usp_DepositMoney(@AccountId INT, @MoneyAmount DECIMAL(18, 4))
AS
BEGIN TRANSACTION
	DECLARE @IsAccountIdValid INT = (SELECT Id FROM Accounts WHERE Id = @AccountId)

	IF (@IsAccountIdValid IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid AccountId!', 16, 1)
		RETURN
	END

	IF (@MoneyAmount < 0)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid amount of money!', 16, 1)
		RETURN
	END

	UPDATE Accounts
	SET Balance += @MoneyAmount
	WHERE Id = @AccountId
	COMMIT

GO

EXEC usp_DepositMoney 1, 1000
GO
SELECT * FROM Accounts WHERE Id = 1
GO
SELECT * FROM Logs
SELECT * FROM NotificationEmails