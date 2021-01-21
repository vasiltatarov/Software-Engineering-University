USE Geography
GO
SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation 
FROM Peaks AS p
JOIN Mountains AS m ON m.Id = p.MountainId
JOIN MountainsCountries AS mc ON mc.MountainId = m.Id
WHERE mc.CountryCode LIKE 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC