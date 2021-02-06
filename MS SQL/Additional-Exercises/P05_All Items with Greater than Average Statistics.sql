USE Diablo

DECLARE @mindAvg INT = (SELECT AVG(s.Mind) FROM Items AS i
						JOIN [Statistics] AS s ON i.StatisticId = s.Id)

DECLARE @luckAvg INT = (SELECT AVG(s.Luck) FROM Items AS i
						JOIN [Statistics] AS s ON i.StatisticId = s.Id)

DECLARE @speedAvg INT = (SELECT AVG(s.Speed) FROM Items AS i
						JOIN [Statistics] AS s ON i.StatisticId = s.Id)

SELECT i.[Name] AS [Name],
		i.Price AS [Price],
		i.MinLevel AS [MinLevel],
		s.Strength AS [Strength],
		s.Defence AS [Defence],
		s.Speed AS [Speed],
		s.Luck AS [Luck],
		s.Mind AS [Mind]
FROM Items AS i
JOIN [Statistics] AS s ON i.StatisticId = s.Id
WHERE [Mind] > @mindAvg AND
	  [Luck] > @luckAvg AND
	  [Speed] > @speedAvg
ORDER BY i.[Name] ASC