USE Bank

--Create another table – NotificationEmails(Id, Recipient, Subject, Body). 
--Add a trigger to logs table and create new email whenever new record is inserted in logs table.
--The following data is required to be filled for each email:
----•	Recipient – AccountId
--•	Subject – "Balance change for account: {AccountId}"
--•	Body - "On {date} your balance was changed from {old} to {new}."
--Submit your query only for the trigger action.


CREATE TABLE NotificationEmails(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT NOT NULL,
	[Subject] VARCHAR(100) NOT NULL,
	Body VARCHAR(200) NOT NULL
)

GO

CREATE TRIGGER tr_OnLogsInsertAddNotificationEmail
ON Logs FOR INSERT
AS
DECLARE @accountId INT = (SELECT AccountId FROM inserted)
DECLARE @oldBalance MONEY = (SELECT OldSum FROM inserted)
DECLARE @newBalance MONEY = (SELECT NewSum FROM inserted)

INSERT INTO NotificationEmails(Recipient, [Subject], Body)
	VALUES
		(
		@accountId,
		CONCAT('Balance change for account: ', @accountId),
		CONCAT('On ', GETDATE(), ' your balance was changed from ', @oldBalance, ' to ', @newBalance, '.')
		)