--08. Create Table Users
CREATE TABLE Users (
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL UNIQUE,
	[Password] VARCHAR(26) UNIQUE,
	ProfilePicture VARBINARY CHECK (DATALENGTH(ProfilePicture) <= 900 * 1024),
	LastLoginTime DATETIME,
	IsDeleted BIT
);

INSERT INTO Users (Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
	VALUES 
		('Vasko', 'vasko123', NULL, '10.13.2020', 0),
		('Donika', 'donikard', NULL, '10.13.2020', 0),
		('Svetlin', 'salibaba', NULL, '10.13.2020', 0),
		('Salim', 'kozletoboc', NULL, '10.13.2020', 1),
		('Iani', 'qnkata', NULL, '10.13.2020', 0);

--Problem 9. Change Primary Key
ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC074222BBA7];

ALTER TABLE Users
ADD CONSTRAINT PK_Users_CompositeIdUsername
PRIMARY KEY (Id, Username);

--Problem 10. Add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT CK_Users_PasswordLength
CHECK (LEN([Password]) >= 5);

--Problem 11. Set Default Value of a Field
ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime;

--Problem 12. Set Unique Field
ALTER TABLE Users
DROP CONSTRAINT [PK_Users_CompositeIdUsername];

ALTER TABLE Users
ADD CONSTRAINT PK_Users_Id
PRIMARY KEY(Id);

ALTER TABLE Users
ADD CONSTRAINT CK_Users_UsernameLength
CHECK (LEN(Username) >= 3);