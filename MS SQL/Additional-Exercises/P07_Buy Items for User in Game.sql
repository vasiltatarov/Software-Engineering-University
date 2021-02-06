SELECT u.Username AS [Username],
		g.[Name] AS [Name],
		ug.Cash AS [Cash],
		i.[Name] AS [Item Name]
FROM UserGameItems AS ugi
JOIN Items AS i ON ugi.ItemId = i.Id
JOIN UsersGames AS ug ON ugi.UserGameId = ug.Id
JOIN Users AS u ON ug.UserId = u.Id
JOIN Games AS g ON ug.GameId = g.Id
WHERE g.Name = 'Edinburgh'
ORDER BY [Item Name] ASC