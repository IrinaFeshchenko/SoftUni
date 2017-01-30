USE Gringotts
GO

SELECT DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
HAVING AVG(MagicWandSize) =
(
    SELECT A.MWS FROM 
	(
		SELECT TOP(1) DepositGroup, AVG(MagicWandSize) AS MWS
		FROM WizzardDeposits
		GROUP BY DepositGroup
		ORDER BY MWS
	) AS A
)