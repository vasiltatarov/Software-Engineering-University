USE Gringotts
GO
SELECT DepositGroup, SUM(DepositAmount) FROM WizzardDeposits
GROUP BY DepositGroup