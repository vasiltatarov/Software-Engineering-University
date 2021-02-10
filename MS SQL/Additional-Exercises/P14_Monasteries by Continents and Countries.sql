USE [Geography]

--1.Write and execute a SQL command that changes the country named "Myanmar" to its other name "Burma".
UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

--2.Add a new monastery holding the following information: Name="Hanga Abbey", Country="Tanzania".
INSERT INTO Monasteries([Name], CountryCode)
	VALUES
		('Hanga Abbey', (SELECT CountryCode FROM Countries WHERE CountryName LIKE 'Tanzania'))

--3.Add a new monastery holding the following information: Name="Myin-Tin-Daik", Country="Myanmar".
INSERT INTO Monasteries([Name], CountryCode)
	VALUES
		('Myin-Tin-Daik', (SELECT CountryCode FROM Countries WHERE CountryName LIKE 'Myanmar'))

--4.Find the count of monasteries for each continent and not deleted country.
--Display the continent name, the country name and the count of monasteries.
--Include also the countries with 0 monasteries. Sort the results by monasteries count DESC, then by country name alphabetically.
SELECT cnt.ContinentName,
		c.CountryName,
		COUNT(M.Id) AS MonasteriesCount
FROM [Monasteries] AS m
RIGHT JOIN Countries AS c ON m.CountryCode = c.CountryCode
RIGHT JOIN Continents AS cnt ON c.ContinentCode = cnt.ContinentCode
WHERE c.IsDeleted = 0
GROUP BY cnt.ContinentName, c.CountryName
ORDER BY [MonasteriesCount] DESC, 
		 c.CountryName ASC