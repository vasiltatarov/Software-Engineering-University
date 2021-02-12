USE Diablo

SELECT u.Username,
		g.[Name] AS [Game],
		MAX(ch.[Name]) AS [Character],
		(SUM(iSt.Strength) + MAX(gSt.Strength) + MAX(chSt.Strength)) AS [Strength],
		(SUM(iSt.Defence) + MAX(gSt.Defence) + MAX(chSt.Defence)) AS [Defence],
		(SUM(iSt.Speed) + MAX(gSt.Speed) + MAX(chSt.Speed)) AS [Speed],
		(SUM(iSt.Mind) + MAX(gSt.Mind) + MAX(chSt.Mind)) AS [Mind],
		(SUM(iSt.Luck) + MAX(gSt.Luck) + MAX(chSt.Luck)) AS [Luck]
FROM Users AS u
JOIN UsersGames AS ug ON u.Id = ug.UserId
JOIN Characters AS ch ON ug.CharacterId = ch.Id
JOIN [Statistics] AS chSt ON chSt.Id = ch.StatisticId
JOIN Games AS g ON ug.GameId = g.Id
JOIN GameTypes AS gt ON gt.Id = g.GameTypeId
JOIN [Statistics] AS gSt ON gSt.Id = gt.BonusStatsId
JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
JOIN Items AS i ON ugi.ItemId = i.Id
JOIN [Statistics] AS iSt ON iSt.Id = i.StatisticId
GROUP BY u.Username, g.[Name]
ORDER BY [Strength] DESC,
		 [Defence] DESC,
		 [Speed] DESC,
		 [Mind] DESC,
		 [Luck] DESC