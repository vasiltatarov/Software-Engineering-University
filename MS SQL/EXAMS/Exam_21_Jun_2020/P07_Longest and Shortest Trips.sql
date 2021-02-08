SELECT a.Id,
		CONCAT(a.FirstName, ' ', a.LastName) AS FullName,
		MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS LongestTrip,
		MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS ShortestTrip
FROM AccountsTrips AS [at]
JOIN Accounts AS a ON a.Id = [at].AccountId
JOIN Trips AS t ON [at].TripId = t.Id
WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
GROUP BY a.Id, CONCAT(a.FirstName, ' ', a.LastName)
ORDER BY LongestTrip DESC, ShortestTrip ASC