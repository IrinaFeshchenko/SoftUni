CREATE TABLE People
(
	Id int PRIMARY KEY IDENTITY,
	Name nvarchar(200) NOT NULL,
	Picture varbinary(2048),
	Height DECIMAL(10,2),
	[Weight] DECIMAL(10,2),
	Gender CHAR NOT NULL,
	Birthdate DATE NOT NULL,
	Biography nvarchar(max)
)

INSERT INTO People ([Name],[Gender],[Birthdate]) VALUES ('Jon','m','2011-03-12' )
INSERT INTO People ([Name],[Gender],[Birthdate]) VALUES ('Jack','m','2011-03-12' )
INSERT INTO People ([Name],[Gender],[Birthdate]) VALUES ('Maria','f','2011-03-12' )
INSERT INTO People ([Name],[Gender],[Birthdate]) VALUES ('Ben','m','2011-03-12' )
INSERT INTO People ([Name],[Gender],[Birthdate]) VALUES ('Jana','f','2011-03-12' )