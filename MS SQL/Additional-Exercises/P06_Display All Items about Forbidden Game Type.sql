SELECT i.[Name] AS [Item],
		i.Price,
		i.MinLevel,
		gt.[Name] AS [Forbidden Game Type]
FROM GameTypeForbiddenItems AS gtfi
JOIN Items AS i ON gtfi.ItemId = i.Id
JOIN GameTypes AS gt ON gtfi.GameTypeId = gt.Id
ORDER BY [Forbidden Game Type] DESC,
		 [Item] ASC