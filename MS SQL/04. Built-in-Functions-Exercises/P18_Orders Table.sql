USE Orders
GO
SELECT ProductName, 
	OrderDate, 
	DATEADD(DAY, 3, OrderDate) AS [Pay Due],
	DATEADD(DAY, 30, OrderDate) AS [Deliver Due]
FROM Orders