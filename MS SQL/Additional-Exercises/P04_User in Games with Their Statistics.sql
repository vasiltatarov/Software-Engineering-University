USE Diablo
GO

--SELECT *
--FROM Characters AS ch
--Join [Statistics] AS s ON ch.StatisticId = s.Id

SELECT u.Username,
		g.[Name],
		*
FROM GameTypeForbiddenItems AS gti
JOIN GameTypes AS gt ON gti.GameTypeId = gt.Id
JOIN Items AS i ON gti.ItemId = i.id
JOIN [Statistics] AS s ON i.StatisticId = s.Id
JOIN Characters AS ch ON s.Id = ch.StatisticId
JOIN UserGameItems AS ugi ON i.Id = ugi.ItemId
JOIN UsersGames AS ug ON ugi.UserGameId = ug.Id
JOIN Users AS u ON ug.UserId = u.Id
JOIN Games AS g ON ug.GameId = g.Id
WHERE g.Name LIKE 'Rose Fire & Ice'