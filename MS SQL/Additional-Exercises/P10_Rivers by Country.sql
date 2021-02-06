SELECT c.CountryName AS [CountryName],
		cnt.ContinentName AS [ContinentName],
		COUNT(r.[Length]) AS [RiversCount],
		CASE
			WHEN SUM(r.[Length]) IS NULL THEN 0
			ELSE SUM(r.[Length])
		END  AS [TotalLength]
FROM CountriesRivers AS cr
RIGHT JOIN Rivers AS r ON cr.RiverId = r.Id
RIGHT JOIN Countries AS c ON cr.CountryCode = c.CountryCode
RIGHT JOIN Continents AS cnt ON c.ContinentCode = cnt.ContinentCode
GROUP BY [CountryName], [ContinentName]
ORDER BY [RiversCount] DESC,
		 [TotalLength] DESC,
		 [CountryName] ASC