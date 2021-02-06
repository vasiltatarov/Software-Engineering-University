SELECT p.PeakName,
		m.MountainRange AS [Mountain],
		c.CountryName,
		cnt.ContinentName
FROM Peaks AS p
JOIN Mountains AS m ON p.MountainId = m.Id
JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
JOIN Countries AS c ON mc.CountryCode = c.CountryCode
JOIN Continents AS cnt ON c.ContinentCode = cnt.ContinentCode
ORDER BY p.PeakName ASC, c.CountryName ASC