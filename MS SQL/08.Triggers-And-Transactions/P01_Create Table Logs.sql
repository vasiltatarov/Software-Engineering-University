USE Bank

CREATE TABLE Logs(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
	OldSum MONEY,
	NewSum MONEY
)

GO

CREATE TRIGGER tr_OnAccountsChangeAddLogRecord
ON Accounts FOR UPDATE
AS
	INSERT INTO Logs(AccountId, OldSum, NewSum)
			SELECT i.Id, d.Balance, i.Balance 
			FROM inserted AS i
			JOIN deleted AS d ON i.Id = d.Id