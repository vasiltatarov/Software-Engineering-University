USE Minions

CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX) CHECK (DATALENGTH(Picture) <= 900 * 1024),
	Height DECIMAL(3, 2),
	[Weight] DECIMAL(4, 2),
	Gender NCHAR NOT NULL,
	Birthdate DATETIME2 NOT NULL,
	Biography NVARCHAR(MAX)
);

INSERT INTO People ([Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
	VALUES	
		('Vasko', NULL, 1.85, 76.40, 'm', '02.19.2000', 'My Name is Vasko, I am Software Engineer!'),
		('Dona', NULL, 1.57, 45.00, 'f', '07.09.2000', 'My Name is Donika, I am Law!'),
		('Svetlin', NULL, 1.80, 90.00, 'm', '07.09.2000', 'My Name is Sali Baba, I am a Goatherd!'),
		('Elvana', NULL, 2.10, 90.00, 'm', '07.09.2000', 'My Name is Elvana, I am a Prostitute!'),
		('Mahmut', NULL, 1.60, 55.00, 'm', '07.09.2000', 'My Name is Mahmut, I am a Jigolo!');