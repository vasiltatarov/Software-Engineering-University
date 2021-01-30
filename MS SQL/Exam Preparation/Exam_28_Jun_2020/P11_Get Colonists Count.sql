CREATE FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
BEGIN
	RETURN (
			SELECT COUNT(*)
			FROM TravelCards AS tc
			JOIN Journeys AS j ON tc.JourneyId = j.Id
			JOIN Spaceports AS sp ON j.DestinationSpaceportId = sp.Id
			JOIN Planets AS p ON sp.PlanetId = p.Id
			WHERE p.Name LIKE @PlanetName
			)
END

GO

SELECT dbo.udf_GetColonistsCount('Otroyphus') AS [Count]