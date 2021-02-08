USE TripService

SELECT FirstName,
		LastName,
		FORMAT(BirthDate, 'MM-dd-yyyy') AS [BirthDate],
		c.[Name] AS [Hometown],
		Email
FROM Accounts AS ac
JOIN Cities AS c ON c.Id = ac.CityId
WHERE Email LIKE 'e%'
ORDER BY [Hometown] ASC