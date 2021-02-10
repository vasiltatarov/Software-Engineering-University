DECLARE @userId INT = (SELECT Id FROM Users WHERE Username LIKE 'Alex')
DECLARE @gameId INT = (SELECT Id FROM Games WHERE [Name] LIKE 'Edinburgh')

DECLARE @userGameId INT = (SELECT Id FROM UsersGames
						   WHERE UserId = @userId AND GameId = @gameId)

DECLARE @totalSumItems DECIMAL(15, 2) = (SELECT SUM(Price) FROM Items
										 WHERE [Name] IN ('Blackguard',
														  'Bottomless Potion of Amplification',
														  'Eye of Etlich (Diablo III)',
														  'Gem of Efficacious Toxin',
														  'Golden Gorget of Leoric',
														  'Hellfire Amulet'))

UPDATE UsersGames
SET Cash -= @totalSumItems
WHERE Id = @userGameId

INSERT INTO UserGameItems(ItemId ,UserGameId)
	VALUES
		( (SELECT Id FROM Items WHERE Name = 'Blackguard'), @userGameId),
        ( (SELECT Id FROM Items WHERE Name='Bottomless Potion of Amplification'), @userGameId),
        ( (SELECT Id FROM Items WHERE Name='Eye of Etlich (Diablo III)'), @userGameId),
        ( (SELECT Id FROM Items WHERE Name='Gem of Efficacious Toxin'), @userGameId),
        ( (SELECT Id FROM Items WHERE Name='Golden Gorget of Leoric'), @userGameId),
        ( (SELECT Id FROM Items WHERE Name='Hellfire Amulet'), @userGameId)

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