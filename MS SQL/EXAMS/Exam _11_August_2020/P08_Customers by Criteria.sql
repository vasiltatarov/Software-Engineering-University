USE Bakery

SELECT c.FirstName,
		c.Age,
		c.PhoneNumber
FROM Customers AS c
JOIN Countries AS cnt ON c.CountryId = cnt.Id
WHERE c.Age >= 21 AND
	  (c.FirstName LIKE '%an%' OR
	  c.PhoneNumber LIKE '%38') AND
	  cnt.[Name] <> 'Greece'
ORDER BY c.FirstName ASC, c.Age DESC