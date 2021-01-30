USE [ColonialJourney]

SELECT c.Id AS [id], CONCAT(FirstName, ' ', LastName) AS [full_name]
FROM Colonists AS c
JOIN TravelCards AS tc ON tc.ColonistId = c.Id
WHERE tc.JobDuringJourney LIKE 'pilot'
ORDER BY Id