SELECT DISTINCT LEFT(FirstName, 1) AS [FirstLetter]
FROM WizzardDeposits
WHERE DepositGroup LIKE 'Troll Chest'
GROUP BY DepositGroup, FirstName
ORDER BY [FirstLetter]