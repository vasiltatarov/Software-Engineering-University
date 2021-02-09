DECLARE @userName NVARCHAR(MAX) = 'Stamat'
DECLARE @gameName NVARCHAR(MAX) = 'Safflower'

DECLARE @userId INT = (SELECT Id FROM Users WHERE Username LIKE @userName)
DECLARE @gameId INT = (SELECT Id FROM Games WHERE Name = @gameName)

DECLARE @userBalance DECIMAL(18, 2) = (SELECT Cash FROM UsersGames 
									   WHERE UserId = @userId AND GameId = @gameId)

DECLARE @itemsTotalPrice DECIMAL(18, 2) = (SELECT SUM(Price) FROM Items 
										   WHERE (MinLevel BETWEEN 11 AND 12))

DECLARE @userGameId INT = (SELECT Id FROM UsersGames 
							   WHERE UserId = @userID AND GameId = @gameID)

BEGIN TRANSACTION
    SET @itemsTotalPrice = (SELECT SUM(Price) FROM Items 
							WHERE MinLevel BETWEEN 11 AND 12)
 
    IF(@userBalance >= @itemsTotalPrice)
    BEGIN
        INSERT INTO UserGameItems
        SELECT i.Id, @userGameID FROM Items AS i
        WHERE i.Id IN (SELECT Id FROM Items 
                       WHERE MinLevel BETWEEN 11 AND 12)
 
        UPDATE UsersGames
        SET Cash -= @itemsTotalPrice
        WHERE GameId = @gameID AND UserId = @userID
        COMMIT
    END
    ELSE
    BEGIN
        ROLLBACK
    END
 
SET @userBalance = (SELECT Cash FROM UsersGames 
                    WHERE UserId = @userID AND GameId = @gameID)

BEGIN TRANSACTION
    SET @itemsTotalPrice = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21)
 
    IF(@userBalance >= @itemsTotalPrice)
    BEGIN
        INSERT INTO UserGameItems
        SELECT i.Id, @userGameID FROM Items AS i
        WHERE i.Id IN (SELECT Id FROM Items 
                       WHERE MinLevel BETWEEN 19 AND 21 )
 
        UPDATE UsersGames
        SET Cash -= @itemsTotalPrice
        WHERE GameId = @gameID AND UserId = @userID
        COMMIT
    END
    ELSE
    BEGIN
        ROLLBACK
    END
 
SELECT i.[Name] AS [Item Name]
FROM Users as u
JOIN UsersGames AS ug ON ug.UserId = u.Id
JOIN Games AS g ON g.Id = ug.GameId
JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
JOIN Items AS i ON i.Id = ugi.ItemId
WHERE Username LIKE 'Stamat' AND g.[Name] LIKE 'Safflower'
ORDER BY [Item Name] ASC