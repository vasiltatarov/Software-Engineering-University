SELECT [JobDuringJourney], [FullName], [JobRank]
FROM (
	SELECT tc.JobDuringJourney AS [JobDuringJourney],
			CONCAT(c.FirstName, ' ', c.LastName) AS [FullName],
			DENSE_RANK() OVER (PARTITION BY JobDuringJourney ORDER BY Birthdate ASC) AS [JobRank]
	FROM Colonists AS c
	JOIN TravelCards AS tc ON tc.ColonistId = c.Id
	) AS [Result]
WHERE [JobRank] = 2