CREATE DATABASE Minions
GO
CREATE TABLE Minions.dbo.Minions
(
	Id int NOT NULL,
	Name nvarchar(50),
	Age int,
	CONSTRAINT PK_Minions PRIMARY KEY CLUSTERED (Id ASC)
)

CREATE TABLE Minions.dbo.Towns
(
	Id int NOT NULL,
	Name nvarchar(50),
	CONSTRAINT PK_Towns PRIMARY KEY CLUSTERED (Id ASC)
)