USE Diablo
GO

--1. Users should not be allowed to buy items with higher level than their level. Create a trigger that restricts that.
CREATE TRIGGER tr_RestrictItems
	ON UserGameItems INSTEAD OF INSERT
AS
DECLARE @itemId INT = (SELECT ItemId FROM inserted)
DECLARE @userGameId INT = (SELECT UserGameId FROM inserted)

DECLARE @itemLevel INT = (SELECT MinLevel FROM Items WHERE Id = @itemId)
DECLARE @userLevel INT = (SELECT [Level] FROM UsersGames WHERE Id = @userGameId)

IF (@userLevel >= @itemLevel)
BEGIN
	INSERT INTO UserGameItems(ItemId, UserGameId)
		VALUES
			(@itemId, @userGameId)
END

GO

SELECT * FROM UserGameItems WHERE ItemId = 2 AND UserGameId = 150

INSERT INTO UserGameItems(ItemId, UserGameId)
	VALUES
		(2, 150)

--2. Add bonus cash of 50000 to users: baleremuda, loosenoise, inguinalself, buildingdeltoid, monoxidecos in the game "Bali".
UPDATE UsersGames
SET Cash += 50000
WHERE Id IN (
			SELECT ug.Id FROM UsersGames AS ug
			JOIN Users AS u ON ug.UserId = u.Id
			JOIN Games AS g On ug.GameId = g.Id
			WHERE g.[Name] LIKE 'Bali'
				AND
				  u.Username IN ('baleremuda', 
								 'loosenoise',
								 'inguinalself',
								 'buildingdeltoid',
								 'monoxidecos')
			)
--Show result
SELECT ug.Id, ug.Cash FROM UsersGames AS ug
			JOIN Users AS u ON ug.UserId = u.Id
			JOIN Games AS g On ug.GameId = g.Id
			WHERE g.[Name] LIKE 'Bali'
				AND
				  u.Username IN ('baleremuda', 
								 'loosenoise',
								 'inguinalself',
								 'buildingdeltoid',
								 'monoxidecos')

--3. There are two groups of items that you must buy for the above users. 
--The first are items with id between 251 and 299 including. Second group are items with id between 501 and 539 including.
--Take off cash from each user for the bought items.
GO

CREATE PROCEDURE usp_BuyItem(@userGameId INT, @itemId INT)--@userGameId
AS
BEGIN TRANSACTION
DECLARE @userCash DECIMAL(18, 2) = (SELECT Cash FROM UsersGames WHERE Id = @userGameId)
DECLARE @itemPrice DECIMAL(18, 2) = (SELECT Price FROM Items WHERE Id = @itemId)

	IF (@userCash < @itemPrice)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid user or item Ids!', 16, 1)
		RETURN
	END

	UPDATE UsersGames
	SET Cash -= @itemPrice
	WHERE Id = @userGameId

	INSERT INTO UserGameItems(ItemId, UserGameId)
		VALUES
			(@itemId, @userGameId)
COMMIT

GO

DECLARE @itemId INT = 251
WHILE(@itemId <= 299)
BEGIN
	EXEC usp_BuyItem 26, @itemId
	EXEC usp_BuyItem 115, @itemId
	EXEC usp_BuyItem 146, @itemId
	EXEC usp_BuyItem 177, @itemId
	EXEC usp_BuyItem 296, @itemId

	SET @itemId += 1
END

GO
DECLARE @itemId INT = 501
WHILE (@itemId <= 539)
BEGIN
	EXEC usp_BuyItem 26, @itemId
	EXEC usp_BuyItem 115, @itemId
	EXEC usp_BuyItem 146, @itemId
	EXEC usp_BuyItem 177, @itemId
	EXEC usp_BuyItem 296, @itemId

	SET @itemId += 1
END

--4. Select all users in the current game ("Bali") with their items. 
--Display username, game name, cash and item name. Sort the result by username alphabetically, then by item name alphabetically.
SELECT u.Username,
		g.[Name],
		ug.Cash,
		i.[Name] AS [Item Name]
FROM UsersGames AS ug
	JOIN Users AS u ON ug.UserId = u.Id
	JOIN Games AS g On ug.GameId = g.Id
	JOIN UserGameItems AS ugi ON ug.Id = ugi.UserGameId
	JOIN Items AS i ON ugi.ItemId = i.Id
	WHERE g.[Name] LIKE 'Bali'
		AND
		  u.Username IN ('baleremuda', 
						 'loosenoise',
						 'inguinalself',
						 'buildingdeltoid',
						 'monoxidecos')
ORDER BY u.Username ASC, i.[Name] ASC