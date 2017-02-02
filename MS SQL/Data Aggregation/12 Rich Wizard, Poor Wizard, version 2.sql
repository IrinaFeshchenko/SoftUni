USE Gringotts
GO

SELECT SUM(NewTable.Diff) AS Total
FROM 
(SELECT 
FirstName,
DepositAmount,
LEAD(FirstName) OVER (ORDER BY Id) AS GuestWizzard,
LEAD(DepositAmount) OVER (ORDER BY Id) AS GuestDeposit,
DepositAmount - (LEAD(DepositAmount) OVER (ORDER BY Id)) AS Diff
FROM WizzardDeposits) AS NewTable