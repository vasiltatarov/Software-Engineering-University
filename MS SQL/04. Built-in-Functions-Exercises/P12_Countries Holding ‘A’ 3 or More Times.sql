USE Geography
GO
SELECT CountryName AS [Country Name], IsoCode AS [ISO Code] FROM Countries
WHERE CountryName LIKE '%A%A%A%'
ORDER BY IsoCode ASC