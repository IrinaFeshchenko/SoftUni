USE Bank
GO

CREATE PROC usp_DepositMoney(@AccountId int, @moneyAmount money)
AS
BEGIN TRAN
UPDATE Accounts SET Balance = Balance + @moneyAmount
WHERE Id = @AccountId
IF @@ROWCOUNT <> 1
BEGIN
	ROLLBACK
	RAISERROR('Invalid account!', 16, 1)
	RETURN
END
COMMIT