SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum] 
FROM WizzardDeposits
WHERE MagicWandCreator LIKE 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY [TotalSum] DESC

--Same result but with nested select
SELECT * FROM(
			SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum] 
			FROM WizzardDeposits
			WHERE MagicWandCreator LIKE 'Ollivander family'
			GROUP BY DepositGroup
			) AS [DepositGroups]
WHERE [TotalSum] < 150000
ORDER BY [TotalSum] DESC