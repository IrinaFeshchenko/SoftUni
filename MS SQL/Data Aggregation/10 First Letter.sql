USE Gringotts
GO

SELECT FirstLetter
FROM(
	SELECT LEFT(FirstName,1) AS FirstLetter
	FROM WizzardDeposits
	WHERE DepositGroup = 'Troll Chest'
	) s
GROUP BY FirstLetter
ORDER BY FirstLetter ASC