USE Bank
GO

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@value MONEY)
AS
SELECT ah.FirstName, ah.LastName
FROM 
(
	SELECT AccountHolderId, SUM(Balance) AS Total
	FROM Accounts
	GROUP BY AccountHolderId
	HAVING SUM(Balance)  > @value
) a
INNER JOIN AccountHolders ah ON a.AccountHolderId = ah.Id
GO

EXEC usp_GetHoldersWithBalanceHigherThan 10000

------------------
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@value MONEY)
AS
SELECT ah.FirstName, ah.LastName
FROM Accounts a
INNER JOIN AccountHolders ah ON a.AccountHolderId = ah.Id
GROUP BY ah.FirstName, ah.LastName
HAVING SUM(Balance)  > @value