create database TableRelations
go 

USE TableRelations
GO

CREATE TABLE Passports(
	PassportID int IDENTITY(101,1) CONSTRAINT PK_Passports PRIMARY KEY,
	PassportNumber varchar(10)
)

CREATE TABLE Persons(
	PersonID int IDENTITY(1,1) CONSTRAINT PK_Persons PRIMARY KEY,
	FirstName nvarchar(20),
	Salary decimal(8,2),
	PassportID int
)

INSERT INTO Passports( PassportNumber)
VALUES ( 'N34FG21B')
INSERT INTO Passports( PassportNumber)
VALUES ('K65LO4R7')
INSERT INTO Passports( PassportNumber)
VALUES ('ZE657QP2')

INSERT INTO Persons(FirstName, Salary, PassportID)
VALUES ('Roberto', 43300.00, 102)
INSERT INTO Persons(FirstName, Salary, PassportID)
VALUES ('Tom', 56100.00, 103)
INSERT INTO Persons(FirstName, Salary, PassportID)
VALUES ('Yana', 60200.00, 101)

ALTER TABLE Persons
ADD CONSTRAINT FK_Persons_Passports FOREIGN KEY(PassportID) REFERENCES Passports(PassportID)