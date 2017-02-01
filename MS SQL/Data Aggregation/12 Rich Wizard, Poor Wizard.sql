USE Gringotts
GO

SELECT SUM(diff) AS SumDifference
FROM(
	SELECT
		 COALESCE(
		 a.DepositAmount - 
		(SELECT b.DepositAmount FROM WizzardDeposits b WHERE b.Id = a.Id+1 ), null
		) AS diff
	FROM WizzardDeposits a
) S
