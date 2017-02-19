USE Bank
GO


CREATE TABLE Logs (
	LogId int IDENTITY CONSTRAINT PK_Logs PRIMARY KEY, 
	AccountId INT NOT NULL CONSTRAINT FK_Logs_Accounts FOREIGN KEY(AccountId) REFERENCES Accounts(Id), 
	OldSum money,
	NewSum money
)
GO

CREATE TRIGGER tr_Accounts_After_Update ON Accounts FOR UPDATE
AS
BEGIN
	INSERT INTO Logs(AccountId, OldSum, NewSum)
	SELECT i.id, d.Balance, i.Balance
	FROM inserted i
	INNER JOIN deleted d ON d.Id = i.Id
END
