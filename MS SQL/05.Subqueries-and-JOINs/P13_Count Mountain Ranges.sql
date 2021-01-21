USE Geography
Go
SELECT mc.CountryCode, COUNT(mc.CountryCode) FROM Mountains AS m
JOIN MountainsCountries AS mc ON mc.MountainId = m.Id
WHERE mc.CountryCode LIKE 'BG' OR mc.CountryCode LIKE 'RU' OR mc.CountryCode LIKE 'US'
GROUP BY mc.CountryCode