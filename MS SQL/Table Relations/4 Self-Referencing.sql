CREATE DATABASE TableRelations
GO
USE TableRelations
GO

CREATE TABLE Teachers(
	TeacherID int NOT NULL CONSTRAINT PK_Teachers PRIMARY KEY,
	Name varchar(50) NOT NULL,
	ManagerID int NULL
)

INSERT INTO Teachers(TeacherID, Name, ManagerID)
VALUES(101, 'John', NULL)
INSERT INTO Teachers(TeacherID, Name, ManagerID)
VALUES(102, 'Maya', 106)
INSERT INTO Teachers(TeacherID, Name, ManagerID)
VALUES(103, 'Silvia', 106)
INSERT INTO Teachers(TeacherID, Name, ManagerID)
VALUES(104, 'Ted', 105)
INSERT INTO Teachers(TeacherID, Name, ManagerID)
VALUES(105, 'Mark', 101)
INSERT INTO Teachers(TeacherID, Name, ManagerID)
VALUES(106, 'Greta', 101)

ALTER TABLE Teachers
ADD CONSTRAINT SFK_Teachers FOREIGN KEY(ManagerID) REFERENCES Teachers(TeacherID)