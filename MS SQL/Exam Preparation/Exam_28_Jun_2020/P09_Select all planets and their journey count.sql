SELECT p.[Name] AS [PlanetName], COUNT(*) AS [JourneysCount]
FROM Journeys AS j
JOIN Spaceports AS sp ON sp.Id = j.DestinationSpaceportId
JOIN Planets as p ON p.Id = sp.PlanetId
GROUP BY p.[Name]
ORDER BY COUNT(*) DESC, p.[Name] ASC