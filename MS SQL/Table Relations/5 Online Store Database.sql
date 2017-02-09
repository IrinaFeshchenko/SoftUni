CREATE DATABASE Store
GO
USE Store
GO

CREATE TABLE Cities(
	CityID int NOT NULL CONSTRAINT PK_Cities PRIMARY KEY(CityID),
	Name varchar(50) NOT NULL
)

CREATE TABLE Customers(
	CustomerID int NOT NULL CONSTRAINT PK_Customers PRIMARY KEY(CustomerID),
	Name varchar(50) NOT NULL,
	Birthdate date,
	CityID int NOT NULL CONSTRAINT FK_Customers_Cities FOREIGN KEY(CityID) REFERENCES Cities(CityID)
)

CREATE TABLE Orders(
	OrderID int NOT NULL CONSTRAINT PK_Orders PRIMARY KEY(OrderID),
	CustomerID int CONSTRAINT FK_Orders_Customers FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes(
	ItemTypeID int NOT NULL CONSTRAINT PK_ItemTypes PRIMARY KEY(ItemTypeID),
	Name varchar(50) NOT NULL
)

CREATE TABLE Items(
	ItemID int NOT NULL CONSTRAINT PK_Items PRIMARY KEY(ItemID),
	Name varchar(50) NOT NULL,
	ItemTypeID int CONSTRAINT FK_Items_ItemTypes FOREIGN KEY(ItemTypeID) REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems(
	OrderID int NOT NULL CONSTRAINT FK_OrderItems_Orders FOREIGN KEY(OrderID) REFERENCES Orders(OrderID),
	ItemID int NOT NULL CONSTRAINT FK_OrderItems_Items FOREIGN KEY(ItemID) REFERENCES Items(ItemID),
	CONSTRAINT PK_OrderItems PRIMARY KEY(OrderID, ItemID)
)