USE [Geography]

SELECT cr.CurrencyCode AS [CurrencyCode],
		cr.[Description] AS [Currency],
		COUNT(*) AS [NumberOfCountries]
FROM Countries AS cnt
JOIN Currencies AS cr ON cnt.CurrencyCode = cr.CurrencyCode
GROUP BY cr.CurrencyCode, cr.[Description]
ORDER BY [NumberOfCountries] DESC, [Currency] ASC

-- TESTS
SELECT [CurrencyCode],
		[Currency],
		[NumberOfCountries]
	FROM (
		  SELECT cr.CurrencyCode AS [CurrencyCode],
		  		cr.[Description] AS [Currency],
		  		ROW_NUMBER() OVER (PARTITION BY cnt.CurrencyCode ORDER BY cnt.CurrencyCode) AS [NumberOfCountries]
		  FROM Countries AS cnt
		  JOIN Currencies AS cr ON cnt.CurrencyCode = cr.CurrencyCode
		 ) AS [result]
GROUP BY [CurrencyCode], [Currency], [NumberOfCountries]
ORDER BY [NumberOfCountries] DESC,
		 [Currency] ASC




SELECT * ,ROW_NUMBER() OVER (PARTITION BY cr.CurrencyCode ORDER BY cr.CurrencyCode)
FROM Countries AS cnt
JOIN Currencies AS cr ON cnt.CurrencyCode = cr.CurrencyCode