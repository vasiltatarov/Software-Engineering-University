USE Gringotts
GO
SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum] 
FROM WizzardDeposits
WHERE MagicWandCreator LIKE 'Ollivander family'
GROUP BY DepositGroup