USE WMS
GO

CREATE PROCEDURE usp_PlaceOrder(@jobId INT, @serialNumber VARCHAR(50), @quantity INT)
AS
DECLARE @jobStatus VARCHAR(50) = (SELECT [Status] FROM Jobs WHERE JobId = @jobId)

IF (@jobStatus = 'Finished')
	THROW 50011, 'This job is not active!', 1

IF (@quantity <= 0)
	THROW 50012, 'Part quantity must be more than zero!', 1

DECLARE @job INT = (SELECT JobId FROM Jobs WHERE JobId = @jobId)

IF (@job IS NULL)
	THROW 50013, 'Job not found!', 1

DECLARE @partId INT = (SELECT PartId FROM Parts WHERE SerialNumber = @serialNumber)

IF (@partId IS NULL)
	THROW 50014, 'Part not found!', 1

DECLARE @orderId INT = (SELECT OrderId FROM Orders 
						WHERE JobId = @jobId AND IssueDate IS NULL)

IF (@orderId IS NULL)
BEGIN
	INSERT INTO Orders (JobId, IssueDate, Delivered)
	VALUES (@jobId, NULL, 0)
END

SET @orderId = (
				SELECT OrderId FROM Orders
				WHERE JobId = @jobId AND IssueDate IS NULL
			   )

DECLARE @orderPartsQuantity INT = (SELECT Quantity FROM OrderParts
									WHERE OrderId = @orderId AND PartId = @partId)

IF (@orderPartsQuantity IS NULL)
BEGIN
	INSERT INTO OrderParts (OrderId, PartId, Quantity)
	VALUES (@orderId, @partId, @quantity)
END
ELSE
BEGIN
	UPDATE OrderParts
	SET Quantity += @quantity
	WHERE OrderId = @orderId AND PartId = @partId
END

GO
DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
  EXEC usp_PlaceOrder 1, 'ZeroQuantity', 0
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH