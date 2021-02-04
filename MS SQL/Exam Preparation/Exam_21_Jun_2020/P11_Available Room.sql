USE TripService
GO

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX)
BEGIN
	IF ()

	RETURN 'Room {Room Id}: {Room Type} ({Beds} beds) - ${Total Price}'
END

GO

SELECT * FROM Rooms AS r
JOIN Trips AS t ON r.Id = t.RoomId
WHERE r.HotelId = 112 AND t.CancelDate IS NULL AND ('2011-12-17' >= t.ArrivalDate AND '2011-12-17' <= t.ReturnDate)