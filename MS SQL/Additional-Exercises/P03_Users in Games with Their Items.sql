SELECT *
	FROM (
		SELECT u.Username AS [Username],
				g.[Name] AS [Game],
				COUNT(*) AS [Items Count],
				SUM(i.Price) AS [Items Price]
		FROM UserGameItems AS ugi
		JOIN Items AS i ON ugi.ItemId = i.Id
		JOIN UsersGames	AS ug ON ugi.UserGameId = ug.Id
		JOIN Games AS g ON ug.GameId = g.Id
		JOIN Users AS u ON ug.UserId = u.Id
		GROUP BY u.Username, g.[Name]
		) AS [result]
WHERE [result].[Items Count] >= 10
ORDER BY [result].[Items Count] DESC, 
		 [result].[Items Price] DESC, 
		 [result].[Username] ASC