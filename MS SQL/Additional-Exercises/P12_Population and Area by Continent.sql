USE [Geography]

SELECT cn.ContinentName AS [ContinentName],
		SUM(c.AreaInSqKm) AS [CountriesArea],
		SUM(CONVERT(BIGINT, c.[Population])) AS [CountriesPopulation]
FROM Continents AS cn
JOIN Countries AS c ON cn.ContinentCode = c.ContinentCode
GROUP BY [ContinentName]
ORDER BY [CountriesPopulation] DESC