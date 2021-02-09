USE Bank
GO

CREATE PROCEDURE usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(18, 4))
AS
BEGIN TRANSACTION
--Make sure to guarantee valid positive MoneyAmount
	IF (@Amount < 0)
	BEGIN
	ROLLBACK
	RAISERROR('Amount cannot be negative number!', 16, 1)
	RETURN
	END

--Make sure if accounts Id's is valid
	DECLARE @sender INT = (SELECT Id FROM Accounts WHERE Id = @SenderId)
	DECLARE @receiver INT = (SELECT Id FROM Accounts WHERE Id = @SenderId)

	IF (@sender IS NULL OR @receiver IS NULL)
	BEGIN
	ROLLBACK
	RAISERROR('Invalid account Id!', 16, 1)
	RETURN
	END

--Make transaction
	EXEC usp_WithdrawMoney @SenderId, @Amount
	EXEC usp_DepositMoney @ReceiverId, @Amount
	COMMIT

GO
EXEC usp_TransferMoney 5, 1, 5000
GO
SELECT * FROM Accounts WHERE Id = 5
SELECT * FROM Accounts WHERE Id = 1