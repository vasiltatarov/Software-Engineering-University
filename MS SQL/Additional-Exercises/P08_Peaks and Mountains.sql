USE Geography

SELECT p.PeakName AS [PeakName], 
		m.MountainRange AS [Mountain],
		p.Elevation
FROM Peaks AS p
JOIN Mountains AS m ON p.MountainId = m.Id
ORDER BY p.Elevation DESC, [PeakName] ASC