USE TripService

SELECT c.[Name], COUNT(*)
FROM Cities AS c
JOIN Hotels AS h ON c.Id = h.CityId
GROUP BY c.Name
ORDER BY COUNT(*) DESC, c.[Name] ASC