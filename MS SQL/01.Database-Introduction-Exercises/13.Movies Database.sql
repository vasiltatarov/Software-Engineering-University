CREATE DATABASE Movies;

USE Movies;

CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
);

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
);

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
);

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(100) NOT NULL,
	DirectorId INT NOT NULL FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear DATETIME2 NOT NULL,
	[Length] DECIMAL(4, 2) NOT NULL,
	GenreId INT NOT NULL FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
	Rating INT NOT NULL,
	Notes NVARCHAR(MAX)
);

INSERT INTO Directors (DirectorName, Notes)
	VALUES
		('Svetlin', 'Director of goats farm'),
		('Donika', 'Book Writer'),
		('Vasko', 'Junior Software Developer'),
		('Pesho', 'Policeman'),
		('Kristiqn', 'The Doctor');

INSERT INTO Genres (GenreName, Notes)
	VALUES
		('Horror', NULL),
		('Comedy', NULL),
		('Trailer', NULL),
		('Action', NULL),
		('Soap Opera', NULL);

INSERT INTO Categories (CategoryName, Notes)
	VALUES
		('Action and adventure', NULL),
		('Childrens', NULL),
		('Classic', NULL),
		('Crime', NULL),
		('Fantasy', NULL);

INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
	VALUES
		('The Matrix', 1, '02.03.2000', 2.45, 4, 1, 5, NULL),
		('Game Of Thrones', 3, '05.22.2011', 0.40, 4, 1, 10, NULL),
		('Social network', 5, '02.03.2010', 1.55, 3, 3, 10, NULL),
		('Warcraft', 4, '07.12.2010', 3.00, 4, 5, 7, NULL),
		('John Wick', 2, '02.03.2016', 2.33, 4, 1, 9, NULL);

SELECT * FROM Categories
SELECT * FROM Genres
SELECT * FROM Directors
SELECT * FROM Movies