USE Bakery

CREATE VIEW v_UserWithCountries
AS
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS [CustomerName],
		c.Age AS [Age],
		c.Gender AS [Gender],
		cnt.[Name] AS [CountryName]
FROM Customers AS c
JOIN Countries AS cnt ON c.CountryId = cnt.Id

GO

SELECT TOP 5 *
  FROM v_UserWithCountries
 ORDER BY Age