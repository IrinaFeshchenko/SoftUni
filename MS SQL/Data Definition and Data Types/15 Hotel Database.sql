CREATE DATABASE Hotel
GO
USE Hotel
GO

CREATE TABLE Employees (
	Id INT IDENTITY NOT NULL CONSTRAINT PK_Employees PRIMARY KEY(Id),
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Title NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(20)
)

CREATE TABLE Customers (
	AccountNumber INT NOT NULL CONSTRAINT PK_Customers PRIMARY KEY(AccountNumber),
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	PhoneNumber NVARCHAR(20) NOT NULL,
	EmergencyName NVARCHAR(20) NOT NULL, 
	EmergencyNumber NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(20)
)

CREATE TABLE RoomStatus (
	RoomStatus NVARCHAR(20) PRIMARY KEY NOT NULL, 
	Notes NVARCHAR(200)
)

CREATE TABLE RoomTypes (
	RoomType NVARCHAR(20) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(200)
)

CREATE TABLE BedTypes (
	BedType  NVARCHAR(20) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(200)
)

CREATE TABLE Rooms (
	RoomNumber NVARCHAR(10) PRIMARY KEY NOT NULL,
	RoomType NVARCHAR(20) NOT NULL CONSTRAINT FK_Rooms_RoomTypes FOREIGN KEY(RoomType) REFERENCES RoomTypes, 
	BedType NVARCHAR(20) NOT NULL CONSTRAINT FK_Rooms_BedTypes FOREIGN KEY(BedType) REFERENCES BedTypes, 
	Rate MONEY NOT NULL, 
	RoomStatus NVARCHAR(20) NOT NULL CONSTRAINT FK_Rooms_RoomStatus FOREIGN KEY(RoomStatus) REFERENCES RoomStatus, 
	Notes NVARCHAR(200)
)

CREATE TABLE Payments (
	Id INT IDENTITY NOT NULL CONSTRAINT PK_Payments PRIMARY KEY(Id),
	EmployeeId INT NOT NULL CONSTRAINT FK_Payments_Employees FOREIGN KEY (EmployeeId) REFERENCES Employees, 
	PaymentDate DATE NOT NULL, 
	AccountNumber INT NOT NULL CONSTRAINT FK_Payments_Customers FOREIGN KEY(AccountNumber) REFERENCES Customers, 
	FirstDateOccupied DATE NOT NULL, 
	LastDateOccupied DATE NOT NULL, 
	TotalDays INT NOT NULL, 
	AmountCharged MONEY NOT NULL, 
	TaxRate NUMERIC(3,1) NOT NULL, 
	TaxAmount MONEY NOT NULL, 
	PaymentTotal MONEY NOT NULL, 
	Notes NVARCHAR(200)
)

CREATE TABLE Occupancies (
	Id INT IDENTITY NOT NULL CONSTRAINT PK_Occupancies PRIMARY KEY(Id), 
	EmployeeId INT NOT NULL CONSTRAINT FK_Employees FOREIGN KEY(EmployeeId) REFERENCES Employees, 
	DateOccupied DATE NOT NULL, 
	AccountNumber INT NOT NULL CONSTRAINT FK_Occupancies_Customers FOREIGN KEY(AccountNumber) REFERENCES Customers, 
	RoomNumber NVARCHAR(10) NOT NULL CONSTRAINT FK_Occupancies_RoomNumber FOREIGN KEY(RoomNumber) REFERENCES Rooms, 
	RateApplied NUMERIC(3,1) NOT NULL, 
	PhoneCharge MONEY NOT NULL,
	Notes NVARCHAR(200)
)

INSERT INTO Employees (FirstName, LastName, Title)
VALUES				  ('John', 'Jonson','Desk Operator')
INSERT INTO Employees (FirstName, LastName, Title)
VALUES				  ('Ben', 'Jones','Manager')
INSERT INTO Employees (FirstName, LastName, Title)
VALUES				  ('Piter', 'Collins','Accountant')

INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber)
VALUES                (123123123, 'John', 'Collins', 098789978, 'Piter Jones', 095377263)
INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber)
VALUES                (645645645, 'Ben', 'Collins', 099348394, 'Tim Jones', 0918283939)
INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber)
VALUES                (426645345, 'Tim', 'Collins', 092344223, 'John Jones', 0973847568)

INSERT INTO RoomStatus (RoomStatus)
VALUES                 ('Free')
INSERT INTO RoomStatus (RoomStatus)
VALUES                 ('Occupied')
INSERT INTO RoomStatus (RoomStatus)
VALUES                 ('Under Maintenance')

INSERT INTO RoomTypes (RoomType)
VALUES                ('Family')
INSERT INTO RoomTypes (RoomType)
VALUES                ('Double')
INSERT INTO RoomTypes (RoomType)
VALUES                ('Single')

INSERT INTO BedTypes (BedType)
VALUES               ('King')
INSERT INTO BedTypes (BedType)
VALUES               ('Double')
INSERT INTO BedTypes (BedType)
VALUES               ('Single')

INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus)
VALUES            ('A12','Family','King', 50, 'Free')
INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus)
VALUES            ('B14','Double','Double', 40, 'Occupied')
INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus)
VALUES            ('C15','Single','Single', 30, 'Free')

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal)
VALUES               (1,'10/01/2017', 123123123, '01/01/2017', '10/01/2017', 10, 500, 10, 50, 550)
INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal)
VALUES               (1,'11/01/2017', 645645645, '02/01/2017', '11/01/2017', 10, 400, 10, 40, 440)
INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal)
VALUES               (1,'12/01/2017', 426645345, '03/01/2017', '12/01/2017', 10, 300, 10, 30, 330)

INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge)
VALUES                  (1,'01/01/2017',123123123,'A12',50,0)
INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge)
VALUES                  (2,'02/01/2017',645645645,'B14',40,0)
INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge)
VALUES                  (3,'03/01/2017',426645345,'C15',30,0)