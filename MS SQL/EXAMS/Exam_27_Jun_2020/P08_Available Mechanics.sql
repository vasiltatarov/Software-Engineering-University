USE WMS

SELECT CONCAT(m.FirstName, ' ', m.LastName) AS [Available]
FROM Mechanics AS m
LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId
WHERE m.MechanicId NOT IN (
							SELECT MechanicId
							FROM Jobs
							WHERE [Status] LIKE 'In Progress'
							)
GROUP BY m.MechanicId, CONCAT(m.FirstName, ' ', m.LastName)
ORDER BY m.MechanicId ASC