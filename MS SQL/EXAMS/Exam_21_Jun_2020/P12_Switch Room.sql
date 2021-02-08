CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN
-- If the target room ID is in a different hotel, than the trip is in
	IF (
		(SELECT h.Id FROM Trips AS t
		JOIN Rooms AS r ON t.RoomId = r.Id
		JOIN Hotels AS h ON r.HotelId = h.Id
		WHERE t.Id = @TripId) 
			!=
		(SELECT h.Id
		FROM Rooms AS r
		JOIN Hotels AS h ON r.HotelId = h.Id
		WHERE r.Id = @TargetRoomId)
		)
			RAISERROR ('Target room is in another hotel!', 16, 1)
-- If the target room doesn’t have enough beds for all the trip’s accounts
	IF (
		(SELECT Beds FROM Rooms
		WHERE Id = @TargetRoomId)
			<
		(SELECT COUNT(*)
		FROM AccountsTrips
		WHERE TripId = @TripId)
		)
			RAISERROR ('Not enough beds in target room!', 16, 1)
-- If everything is OK
		UPDATE Trips
		SET RoomId = @TargetRoomId
		WHERE Id = @TripId
END

GO

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10

EXEC usp_SwitchRoom 10, 7

EXEC usp_SwitchRoom 10, 8