SELECT t.Id,
		CONCAT(a.FirstName, ' ', COALESCE(a.MiddleName + ' ', ''), a.LastName) AS [Full Name],
		c.[Name] AS [From],
		hotelCity.[Name] AS [To],
		CASE
			WHEN t.CancelDate IS NULL THEN CONCAT(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate), ' days')
		ELSE 'Canceled' 
		END AS [Duration]
FROM AccountsTrips AS act
JOIN Accounts AS a ON act.AccountId = a.Id
JOIN Trips AS t ON act.TripId = t.Id
JOIN Cities AS c ON a.CityId = c.Id
JOIN Rooms AS r ON t.RoomId = r.Id
JOIN Hotels AS h ON r.HotelId = h.Id
JOIN Cities AS hotelCity ON h.CityId = hotelCity.Id
ORDER BY [Full Name] ASC, t.Id ASC