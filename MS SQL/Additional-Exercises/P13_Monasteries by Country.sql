USE [Geography]

--01
CREATE TABLE Monasteries(
	Id INT PRIMARY KEY IDENTITY, 
	[Name] VARCHAR(100),
	CountryCode CHAR(2) FOREIGN KEY REFERENCES Countries(CountryCode)
)

--02
INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

--03
ALTER TABLE Countries
ADD IsDeleted BIT DEFAULT(0)

UPDATE Countries
SET [IsDeleted] = 0
WHERE [CountryCode] IN (
						SELECT c.CountryCode
						FROM Countries AS c
						WHERE c.IsDeleted IS NULL
						)

--04
UPDATE Countries
SET [IsDeleted] = 1
WHERE [CountryCode] IN (
						SELECT c.CountryCode
						FROM CountriesRivers AS cr
						JOIN Countries AS c ON cr.CountryCode = c.CountryCode
						JOIN Rivers AS r ON cr.RiverId = r.Id
						GROUP BY c.CountryCode
						HAVING COUNT(r.RiverName) > 3
						)

--05
SELECT m.[Name] AS [Monastery], 
		c.CountryName AS [Country]
FROM [Monasteries] AS m
JOIN Countries AS c ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0
ORDER BY [Monastery] ASC