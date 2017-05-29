USE Bank
GO

CREATE PROC usp_TransferMoney(@senderId int, @receiverId int, @amount money)
AS
IF (@amount > 0)
BEGIN
	EXEC usp_WithdrawMoney @senderId, @amount
	EXEC usp_DepositMoney @receiverId, @amount
END
IF (@amount < 0)
BEGIN
	EXEC usp_WithdrawMoney @receiverId, @amount
	EXEC usp_DepositMoney @senderId, @amount
END
