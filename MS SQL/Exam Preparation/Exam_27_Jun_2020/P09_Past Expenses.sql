USE WMS

SELECT j.JobId, 
		ISNULL(SUM(p.Price * op.Quantity), 0) AS [Total]
FROM Jobs AS j
LEFT JOIN Orders AS o ON o.JobId = j.JobId
LEFT JOIN OrderParts AS op ON o.OrderId = op.OrderId
LEFT JOIN Parts AS p ON op.PartId = p.PartId
WHERE j.[Status] LIKE 'Finished'
GROUP BY j.JobId
ORDER BY [Total] DESC, j.JobId ASC