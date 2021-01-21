USE Geography
GO
SELECT ContinentCode, CurrencyCode, CurrencyCount FROM(
	SELECT ContinentCode, CurrencyCode, CurrencyCount, DENSE_RANK() OVER
			(PARTITION BY ContinentCode ORDER BY CurrencyCount DESC) AS [CurrencyRank]
	FROM(
		SELECT c.ContinentCode, c.CurrencyCode, COUNT(*) AS [CurrencyCount]
		FROM Countries AS c
		GROUP BY c.ContinentCode, c.CurrencyCode) AS [CurrencyCountQuery]
	WHERE [CurrencyCount] > 1) AS [CurrencyRankingQuery]
WHERE [CurrencyRank] = 1
ORDER BY ContinentCode ASC