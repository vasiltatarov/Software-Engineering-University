USE WMS

CREATE FUNCTION udf_GetCost(@jobId INT)
RETURNS DECIMAL(15, 2)
BEGIN
DECLARE @result DECIMAL(15, 2)

SET @result = (
				SELECT SUM(p.Price)
				FROM Jobs AS j
				JOIN Orders AS o ON j.JobId = o.JobId
				JOIN OrderParts AS op ON o.OrderId = op.OrderId
				JOIN Parts AS p ON op.PartId = p.PartId
				WHERE j.JobId = @jobId
				)

IF (@result IS NULL)
	RETURN 0

	RETURN @result
END

GO

SELECT dbo.udf_GetCost(1)