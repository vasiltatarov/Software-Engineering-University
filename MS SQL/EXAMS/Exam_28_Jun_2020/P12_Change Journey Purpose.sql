CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(MAX))
AS
BEGIN
-- If Id not exist!
	IF NOT EXISTS (SELECT TOP 1 Id FROM Journeys WHERE Id = @JourneyId)
			RAISERROR ('The journey does not exist!',16,1)
-- If Purpose is same!
	IF ((SELECT Purpose FROM Journeys WHERE Id = @JourneyId) LIKE @NewPurpose)
			RAISERROR ('You cannot change the purpose!',16,1)
-- If everything is OK
		UPDATE Journeys
		SET Purpose = @NewPurpose
		WHERE Id = @JourneyId
END

EXEC usp_ChangeJourneyPurpose 4, 'Technical'
EXEC usp_ChangeJourneyPurpose 2, 'Educational'
EXEC usp_ChangeJourneyPurpose 196, 'Technical'