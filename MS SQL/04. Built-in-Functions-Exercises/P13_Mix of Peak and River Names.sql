USE Geography
GO
SELECT p.PeakName, r.RiverName, LOWER(p.PeakName + r.RiverName) AS Mix
FROM Peaks AS p
JOIN Rivers AS r ON LEFT(r.RiverName, 1) = RIGHT(p.PeakName, 1)
ORDER BY Mix ASC