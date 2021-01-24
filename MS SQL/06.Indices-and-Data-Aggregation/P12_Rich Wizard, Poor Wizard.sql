USE Gringotts
Go
SELECT SUM([Difference]) AS [SumDifference]
FROM(
	SELECT FirstName AS [Host Wizard],
						DepositAmount AS [Host Wizard Deposit],
						LEAD(FirstName) OVER (ORDER BY Id ASC) AS [Guest Wizard],
						LEAD(DepositAmount) OVER (ORDER BY Id ASC) AS [Guest Wizard Deposit],
						DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id ASC) AS [Difference]
	FROM WizzardDeposits AS [Differences]
	) AS [result]