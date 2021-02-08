USE Bakery

SELECT f.ProductId, f.Rate, f.[Description], c.Id, c.Age, c.Gender
FROM Feedbacks AS f
JOIN Customers AS c ON f.CustomerId = c.Id
WHERE f.Rate < (5.0)
ORDER BY f.ProductId DESC, f.Rate ASC