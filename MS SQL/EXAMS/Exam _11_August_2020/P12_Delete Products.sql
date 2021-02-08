CREATE TRIGGER tr_ProductsDelete 
	ON Products INSTEAD OF DELETE
	AS
BEGIN
	DECLARE @deletedProductId INT = (SELECT p.Id FROM Products AS p
									JOIN deleted AS d ON p.Id = d.Id)

	DELETE FROM ProductsIngredients
	WHERE ProductId = @deletedProductId

	DELETE FROM Feedbacks
	WHERE ProductId = @deletedProductId

	DELETE FROM Products
	WHERE Id = @deletedProductId
END