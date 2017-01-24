CREATE DATABASE CarRental
GO
USE CarRental
GO

CREATE TABLE Categories(
	Id int IDENTITY PRIMARY KEY NOT NULL, 
	CategoryName nvarchar(20) NOT NULL,
	DailyRate money NOT NULL, 
	WeeklyRate money NOT NULL,
	MonthlyRate money NOT NULL,
	WeekendRate money NOT NULL
)

CREATE TABLE Cars(
	Id int IDENTITY PRIMARY KEY NOT NULL,
	PlateNumber nvarchar(10) NOT NULL,
	Manufacturer nvarchar(20) NOT NULL, 
	Model nvarchar(20)  NOT NULL,
	CarYear Date  NOT NULL,
	CategoryId int  NOT NULL CONSTRAINT FK_Cars_Categories FOREIGN KEY(CategoryId) REFERENCES Categories,
	Doors int  NOT NULL,
	Picture varbinary(MAX) NULL,
	Condition nvarchar(50) NULL,
	Available bit NOT NULL
)

CREATE TABLE Employees(
	Id int IDENTITY PRIMARY KEY NOT NULL, 
	FirstName nvarchar(20) NOT NULL, 
	LastName nvarchar(20) NOT NULL, 
	Title nvarchar(20) NOT NULL, 
	Notes nvarchar(200),
)

CREATE TABLE Customers(
	Id int IDENTITY PRIMARY KEY NOT NULL, 
	DriverLicenseNumber nvarchar(10) NOT NULL, 
	FullName nvarchar(50) NOT NULL,
	[Address] nvarchar(50),
	City nvarchar(20),
	ZIPCode nvarchar(10),
	Notes nvarchar(200),
)

CREATE TABLE RentalOrders(
	Id int IDENTITY PRIMARY KEY NOT NULL,
	EmployeeId int NOT NULL CONSTRAINT FK_RentalOrders_Employees FOREIGN KEY(EmployeeId) REFERENCES Employees, 
	CustomerId int NOT NULL CONSTRAINT FK_RentalOrders_Customers FOREIGN KEY(CustomerId) REFERENCES Customers,
	CarId int NOT NULL CONSTRAINT FK_RentalOrders_Cars FOREIGN KEY(CarId) REFERENCES Cars,
	TankLevel nvarchar(20), 
	KilometrageStart float, 
	KilometrageEnd float, 
	TotalKilometrage float,
	StartDate date,
	EndDate date,
	TotalDays int, 
	RateApplied money,
	TaxRate numeric(3,1),
	OrderStatus nvarchar(20), 
	Notes nvarchar(200)
)

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES                 ('Economy', 25,100,2000,40)
INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES                 ('Standart', 25,100,2000,40)
INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES                 ('Lux', 25,100,2000,40)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Available)
VALUES           ('BF3467NS','Ford','Focus','2015',1,2,1)
INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Available)
VALUES           ('NJ9463SK','Ford','Fiesta','2015',2,2,1)
INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Available)
VALUES           ('IR4783OU','Ford','F250','2015',3,2,1)

INSERT INTO Employees (FirstName, LastName, Title)
VALUES                ('Jon', 'Jonson', 'Desk Officer')
INSERT INTO Employees (FirstName, LastName, Title)
VALUES                ('Ben', 'Jones', 'Manager')
INSERT INTO Employees (FirstName, LastName, Title)
VALUES                ('Piter', 'Colins', 'Accountant')

INSERT INTO Customers (DriverLicenseNumber, FullName)
VALUES                ('9AD99AD9FU', 'Jon Jonson') 
INSERT INTO Customers (DriverLicenseNumber, FullName)
VALUES                ('9AD99AD9FU', 'Tim Jonson') 
INSERT INTO Customers (DriverLicenseNumber, FullName)
VALUES                ('9AD99AD9FU', 'Moris Jonson') 

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel)
VALUES                   (1,1,1,'Full')
INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel)
VALUES                   (2,2,2,'Full')
INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel)
VALUES                   (3,3,3,'Full')