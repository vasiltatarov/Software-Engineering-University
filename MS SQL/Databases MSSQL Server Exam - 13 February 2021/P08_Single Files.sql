SELECT f1.Id,
		f1.Name,
		CONCAT(f1.Size, 'KB') AS [Size]
FROM Files AS f
RIGHT JOIN Files AS f1 ON f.ParentId = f1.Id
WHERE f.ParentId IS NULL
ORDER BY f1.Id ASC, f1.Name ASC, f1.[Size] DESC