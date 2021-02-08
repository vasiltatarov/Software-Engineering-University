SELECT CONCAT(m.FirstName, ' ', m.LastName) AS [Mechanic],
		AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Days going]
FROM Mechanics AS m
JOIN Jobs AS j ON m.MechanicId = j.MechanicId
GROUP BY CONCAT(m.FirstName, ' ', m.LastName), m.MechanicId
ORDER BY m.MechanicId