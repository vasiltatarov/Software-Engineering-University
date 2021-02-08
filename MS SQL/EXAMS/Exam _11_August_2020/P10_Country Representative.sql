USE Bakery

SELECT [CountryName], [DisributorName]
	FROM (
		SELECT c.[Name] AS [CountryName],
				d.[Name] AS [DisributorName],
				DENSE_RANK() OVER (PARTITION BY c.[Name] ORDER BY COUNT(i.Id) DESC) AS [Ranking]
		FROM Countries AS c
		LEFT JOIN Distributors AS d ON d.CountryId = c.Id
		LEFT JOIN Ingredients AS i ON i.DistributorId = d.Id
		GROUP BY c.[Name], d.[Name]
		) AS [RankQuery]
WHERE [Ranking] = 1
ORDER BY [CountryName] ASC, [DisributorName] ASC