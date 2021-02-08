USE TripService
GO

CREATE OR ALTER FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX)
BEGIN
DECLARE @error NVARCHAR(100) = 'No rooms available'
--The room must not be already occupied
--The room must be in the provided hotel
DECLARE @roomId INT = (SELECT TOP(1) r.Id 
						FROM Rooms AS r
						JOIN Trips AS t ON t.RoomId = r.Id
						JOIN Hotels AS h ON r.HotelId = h.Id
						WHERE h.Id = @HotelId AND
						t.CancelDate IS NULL AND
						@Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate AND
						YEAR(@Date) = YEAR(t.ArrivalDate) AND
						r.Beds >= @People
						ORDER BY r.Price DESC)

IF (@roomId IS NULL)
	RETURN @error

--The total price of the room can be calculated by using this formula:
--(HotelBaseRate + RoomPrice) * PeopleCount
DECLARE @roomType NVARCHAR(20) = (SELECT [Type] FROM Rooms AS r
								  WHERE r.Id = @roomId)

DECLARE @beds INT = (SELECT Beds FROM Rooms AS r
					 WHERE r.Id = @roomId)

DECLARE @price DECIMAL(15, 2) = (SELECT (h.BaseRate + r.Price) * @People
									FROM Rooms AS r
									JOIN Hotels AS h ON r.HotelId = h.Id
									WHERE r.Id = @roomId)

	RETURN CONCAT('Room ', @roomId, ': ', @roomType, ' (', @beds, ' beds) - $', @price)
END

GO
SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
GO
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)
GO
SELECT dbo.udf_GetAvailableRoom(6, '2012-11-01', 2)