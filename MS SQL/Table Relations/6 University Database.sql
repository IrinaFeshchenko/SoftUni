CREATE DATABASE University
GO
USE University
GO

CREATE TABLE Majors(
	MajorID int CONSTRAINT PK_Majors PRIMARY KEY,
	Name varchar(50) NOT NULL
)

CREATE TABLE Subjects(
	SubjectID int CONSTRAINT PK_Subjects PRIMARY KEY,
	SubjectName varchar(50) NOT NULL
)

CREATE TABLE Students(
	StudentID int CONSTRAINT PK_Students PRIMARY KEY,
	StudentNumber varchar(50) NOT NULL,
	StudentName varchar(50) NOT NULL,
	MajorID int NOT NULL CONSTRAINT FK_Students_Majors FOREIGN KEY(MajorID) REFERENCES Majors(MajorID)
)

CREATE TABLE Payments(
	PaymentID int CONSTRAINT PK_Payments PRIMARY KEY,
	PaymentDate date NOT NULL,
	PaymentAmount decimal(8,2) NOT NULL,
	StudentID int NOT NULL CONSTRAINT FK_Payments_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID)
)

CREATE TABLE Agenda(
	StudentID int CONSTRAINT FK_Agenda_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
	SubjectID int CONSTRAINT FK_Agenda_Subjects FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID),
	CONSTRAINT PK_Agenda PRIMARY KEY(StudentID, SubjectID)
)