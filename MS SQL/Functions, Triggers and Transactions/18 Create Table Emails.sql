USE Bank
GO

CREATE TABLE NotificationEmails(
Id INT IDENTITY,
Recipient  VARCHAR(100),
Subject VARCHAR(100), 
Body VARCHAR(2000)
)
GO

CREATE TRIGGER tr_Logs_for_insert ON Logs FOR INSERT
AS
BEGIN 
	INSERT INTO NotificationEmails(Recipient,Subject, Body)
	SELECT 
	AccountId,

	CONCAT('Balance change for account: ',CAST(AccountId AS VARCHAR)),

	'On '+ CONCAT(LEFT(
		DATENAME(M,GETDATE()),3),
		' ',
		FORMAT(GETDATE(), 'dd yyyy hh:mmtt')
)
+ ' your balance was changed from ' 
+ CAST(OldSum AS VARCHAR)+ ' to ' + CAST(NewSum AS VARCHAR) + '.'
	FROM Logs
END
GO

CREATE TRIGGER tr_Accounts_After_Update ON Accounts FOR UPDATE
AS
BEGIN
	INSERT INTO Logs(AccountId, OldSum, NewSum)
	SELECT i.id, d.Balance, i.Balance
	FROM inserted i
	INNER JOIN deleted d ON d.Id = i.Id
END

SELECT CONCAT(LEFT(
DATENAME(M,GETDATE()),3),
' ',
FORMAT(GETDATE(), 'dd yyyy hh:mmtt')
) AS DATETIME

SELECT CONCAT(DATENAME(M,GETDATE()),3),FORMAT(GETDATE(), 'dd yyyy hh:mmtt')