CREATE DATABASE Movies
GO

USE Movies
GO

CREATE TABLE dbo.Directors(
	Id int IDENTITY NOT NULL
	CONSTRAINT PK_Directors PRIMARY KEY(Id),
	DirectorName nvarchar(50) NOT NULL,
	Notes nvarchar(MAX) 
)
GO
INSERT INTO Directors (DirectorName) VALUES ('Jon')
INSERT INTO Directors (DirectorName) VALUES ('jack')
INSERT INTO Directors (DirectorName) VALUES ('Ben')
INSERT INTO Directors (DirectorName) VALUES ('Pit')
INSERT INTO Directors (DirectorName) VALUES ('Tom')

CREATE TABLE dbo.Genres(
	Id int IDENTITY NOT NULL
	CONSTRAINT PK_Genres PRIMARY KEY(Id),
	GenreName nvarchar(50) NOT NULL,
	Notes nvarchar(MAX)
)
GO
INSERT INTO Genres (GenreName) VALUES ('Action')
INSERT INTO Genres (GenreName) VALUES ('Adventure')
INSERT INTO Genres (GenreName) VALUES ('Animation')
INSERT INTO Genres (GenreName) VALUES ('Comedy')
INSERT INTO Genres (GenreName) VALUES ('Documentary')

CREATE TABLE dbo.Categories(
	Id int IDENTITY NOT NULL
	CONSTRAINT PK_Categories PRIMARY KEY(Id),
	GenreName nvarchar(50) NOT NULL,
	Notes nvarchar(MAX)
)
GO
INSERT INTO Categories (GenreName) VALUES ('Cat1')
INSERT INTO Categories (GenreName) VALUES ('Cat2')
INSERT INTO Categories (GenreName) VALUES ('Cat3')
INSERT INTO Categories (GenreName) VALUES ('Cat4')
INSERT INTO Categories (GenreName) VALUES ('Cat5')

CREATE TABLE dbo.Movies(
	Id int IDENTITY NOT NULL
	CONSTRAINT PK_Movies PRIMARY KEY(Id),
	Title nvarchar(20) NOT NULL,
	DirectorId int NOT NULL
	CONSTRAINT FK_Movies_Directors FOREIGN KEY (DirectorID) REFERENCES dbo.Directors(Id),
	CopyrightYear DATE,
	[Length] int NOT NULL,
	GenreId int NOT NULL
	CONSTRAINT FK_Movies_Genres FOREIGN KEY (GenreID) REFERENCES dbo.Genres(Id),
    CategoryId int NOT NULL
	CONSTRAINT FK_Movies_Categories FOREIGN KEY (CategoryID) REFERENCES dbo.Categories(Id),
	Rating int,
	Notes nvarchar(MAX)
)
GO
INSERT INTO Movies (Title,DirectorId,[Length],GenreId,CategoryId) VALUES ('Movie1',1,120,1,1)
INSERT INTO Movies (Title,DirectorId,[Length],GenreId,CategoryId) VALUES ('Movie2',2,120,2,2)
INSERT INTO Movies (Title,DirectorId,[Length],GenreId,CategoryId) VALUES ('Movie3',3,120,3,3)
INSERT INTO Movies (Title,DirectorId,[Length],GenreId,CategoryId) VALUES ('Movie4',3,120,4,4)
INSERT INTO Movies (Title,DirectorId,[Length],GenreId,CategoryId) VALUES ('Movie5',4,120,5,5)