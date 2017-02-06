create database TableRelations
go 

USE TableRelations
GO

CREATE TABLE Manufacturers(
	ManufacturerID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name varchar(20) NOT NULL,
	EstablishedOn date NOT NULL
)

CREATE TABLE Models(
	ModelID int IDENTITY(101,1) PRIMARY KEY NOT NULL,
	Name varchar(20) NOT NULL,
	ManufacturerID int CONSTRAINT FK_Models_Manufacturers FOREIGN KEY(ManufacturerID) REFERENCES Manufacturers(ManufacturerID) NOT NULL
)

INSERT INTO Manufacturers(Name,EstablishedOn)
VALUES ('BMW','07/03/1916')
INSERT INTO Manufacturers(Name,EstablishedOn)
VALUES ('Tesla','01/01/2003')
INSERT INTO Manufacturers(Name,EstablishedOn)
VALUES ('Lada','01/05/1966')

INSERT INTO Models(Name,ManufacturerID)
VALUES ('X1',1)
INSERT INTO Models(Name,ManufacturerID)
VALUES ('I6',1)
INSERT INTO Models(Name,ManufacturerID)
VALUES ('Model S',2)
INSERT INTO Models(Name,ManufacturerID)
VALUES ('Model X',2)
INSERT INTO Models(Name,ManufacturerID)
VALUES ('Model Z',2)
INSERT INTO Models(Name,ManufacturerID)
VALUES ('Nova',3)