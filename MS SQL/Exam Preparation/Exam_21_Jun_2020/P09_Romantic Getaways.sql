SELECT a.Id,
		a.Email,
		c.[Name] AS City,
		COUNT(*) AS Trips
FROM AccountsTrips AS act
JOIN Accounts AS a ON act.AccountId = a.Id
JOIN Trips AS t ON act.TripId = t.Id
JOIN Rooms AS r ON t.RoomId = r.Id
JOIN Hotels AS h ON r.HotelId = h.Id
JOIN Cities AS c ON a.CityId = c.Id
WHERE h.CityId = a.CityId
GROUP BY a.Id, a.Email, c.[Name]
ORDER BY Trips DESC, a.Id ASC