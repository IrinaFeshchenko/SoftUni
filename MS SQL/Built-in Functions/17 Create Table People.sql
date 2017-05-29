CREATE TABLE People(
	Id int IDENTITY CONSTRAINT PK_People PRIMARY KEY(Id),
	Name nvarchar(20),
	Birthdate date
)
GO

INSERT INTO People(Name,Birthdate)
VALUES ('Victor','2000-12-07 00:00:00.000')
INSERT INTO People(Name,Birthdate)
VALUES ('Steven','1992-09-10 00:00:00.000')
INSERT INTO People(Name,Birthdate)
VALUES ('Stephen','1910-09-19 00:00:00.000')
INSERT INTO People(Name,Birthdate)
VALUES ('John','2010-01-06 00:00:00.000')