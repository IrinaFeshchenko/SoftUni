CREATE DATABASE TableRelations
GO

CREATE TABLE Students(
	StudentID int IDENTITY(1,1) CONSTRAINT PK_Students PRIMARY KEY NOT NULL,
	Name varchar(50) NOT NULL
)

CREATE TABLE Exams(
	ExamID int IDENTITY(101,1) CONSTRAINT PK_Exams PRIMARY KEY NOT NULL,
	Name varchar(50) NOT NULL
)

CREATE TABLE StudentsExams(
	StudentID int NOT NULL CONSTRAINT FK_StudentsExams_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
	ExamID int NOT NULL CONSTRAINT FK_StudentsExams_Exams FOREIGN KEY(ExamID) REFERENCES Exams(ExamID),
	CONSTRAINT PK_StudentsExams PRIMARY KEY(StudentID, ExamID)
)

INSERT INTO Students(Name)
VALUES('Mila')
INSERT INTO Students(Name)
VALUES('Toni')
INSERT INTO Students(Name)
VALUES('Ron')

INSERT INTO	Exams(Name)
VALUES('SpringMVC')
INSERT INTO	Exams(Name)
VALUES('Neo4j')
INSERT INTO	Exams(Name)
VALUES('Oracle 11g')

INSERT INTO StudentsExams(StudentID,ExamID)
VALUES(1,101)
INSERT INTO StudentsExams(StudentID,ExamID)
VALUES(1,102)
INSERT INTO StudentsExams(StudentID,ExamID)
VALUES(2,101)
INSERT INTO StudentsExams(StudentID,ExamID)
VALUES(3,103)
INSERT INTO StudentsExams(StudentID,ExamID)
VALUES(2,102)
INSERT INTO StudentsExams(StudentID,ExamID)
VALUES(2,103)