USE Bank
GO

CREATE PROC usp_WithdrawMoney (@AccountId INT, @moneyAmount MONEY)
AS
BEGIN TRAN
UPDATE Accounts SET Balance = Balance - @moneyAmount
WHERE Id = @AccountId
IF @@ROWCOUNT <> 1 OR (SELECT Balance FROM Accounts WHERE Id = @AccountId) < 0
BEGIN
	ROLLBACK
	RAISERROR('Error!', 16, 1)
	RETURN
END
COMMIT