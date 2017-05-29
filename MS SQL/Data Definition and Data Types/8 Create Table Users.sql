USE Minions
GO

CREATE TABLE Users
(
	Id bigint IDENTITY,
	CONSTRAINT PK_Users PRIMARY KEY(Id),
	Name varchar(30) NOT NULL,
	[Password] varchar(26) NOT NULL,
	Picture varbinary(MAX)
	CONSTRAINT CH_Picture CHECK(DATALENGTH(Picture)> 900 * 1024 ),
	LastLoginTime date,
	IsDeleted bit
)

INSERT INTO Users ([Name],[Password]) VALUES ('Jon','password')
INSERT INTO Users ([Name],[Password]) VALUES ('Jack','password')
INSERT INTO Users ([Name],[Password]) VALUES ('Maria','password')
INSERT INTO Users ([Name],[Password]) VALUES ('Ben','password')
INSERT INTO Users ([Name],[Password]) VALUES ('Jim','password')