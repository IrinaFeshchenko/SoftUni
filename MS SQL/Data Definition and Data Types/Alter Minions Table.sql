ALTER TABLE Minions.dbo.Minions
ADD TownId int NOT NULL
GO
ALTER TABLE Minions.dbo.Minions
ADD CONSTRAINT FK_Minions_Towns FOREIGN KEY(TownId)
REFERENCES Towns(Id)