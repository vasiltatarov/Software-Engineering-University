USE Geography
GO
SELECT p.PeakName, 
	r.RiverName, 
	LOWER(p.PeakName + SUBSTRING(r.RiverName, 2, LEN(r.RiverName) - 1)) AS Mix
FROM Peaks AS p
JOIN Rivers AS r ON LEFT(r.RiverName, 1) = RIGHT(p.PeakName, 1)
ORDER BY Mix ASC