SELECT s.[Name], s.Manufacturer
FROM TravelCards AS tc
JOIN Journeys AS j ON j.Id = tc.JourneyId
JOIN Colonists AS c ON c.Id = tc.ColonistId
JOIN Spaceships AS s ON s.Id = j.SpaceshipId
WHERE tc.JobDuringJourney LIKE 'Pilot' AND (YEAR('01-01-2019') - YEAR(c.BirthDate)) < 30
ORDER BY s.[Name]