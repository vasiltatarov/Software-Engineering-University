USE Bakery

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS [CustomerName],
		c.PhoneNumber AS [PhoneNumber],
		c.Gender
FROM Feedbacks AS f
RIGHT JOIN Customers AS c ON f.CustomerId = c.Id
WHERE f.Id IS NULL
ORDER BY c.Id ASC