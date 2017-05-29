USE Bank
GO

CREATE PROC usp_CalculateFutureValueForAccount(@id int, @interest float)
AS
SELECT a.Id AS [Account id], ah.FirstName AS [First Name], ah.LastName AS [Last Name], a.Balance AS [Current Balance], 
(
	SELECT dbo.ufn_CalculateFutureValue(a.Balance,@interest,5)
) AS [Balance in 5 years]
FROM Accounts a
INNER JOIN AccountHolders ah ON ah.Id = a.AccountHolderId
WHERE a.Id = @id