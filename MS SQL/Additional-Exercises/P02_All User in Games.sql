SELECT g.[Name] AS [Game],
		gt.[Name] AS [Game Type],
		u.Username AS [Username],
		ug.[Level] AS [Level],
		ug.Cash AS [Cash],
		ch.[Name] AS [Character]
FROM UsersGames AS ug
JOIN Games AS g ON ug.GameId = g.Id
JOIN GameTypes AS gt ON g.GameTypeId = gt.Id
JOIN Characters AS ch ON ug.CharacterId = ch.Id
JOIN Users AS u ON ug.UserId = u.Id
ORDER BY [Level] DESC,
		[Username] ASC,
		[Game] ASC