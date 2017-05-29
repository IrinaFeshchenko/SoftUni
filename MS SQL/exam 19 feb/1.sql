create database Bakery
go
use Bakery
go

create table Countries(
Id int identity,
Name nvarchar(50),
constraint pk_Countries primary key(Id),
constraint uk_CountriesName unique(Name)
)

create table Distributors(
Id int identity,
Name nvarchar(25),
AddressText nvarchar(30),
Summary nvarchar(200),
CountryId int,
constraint pk_Distributors primary key(Id),
constraint fk_DistributordCountries foreign key(CountryId) references Countries(Id),
constraint uk_DistributorsName unique(Name)
)

create table Ingredients(
Id int identity,
Name nvarchar(30),
Description nvarchar(200),
OriginCountryId int,
DistributorId int,
constraint pk_Ingredients primary key(Id),
constraint fk_IngredientsCountries foreign key(OriginCountryId) references Countries(Id),
constraint fk_IngredientsDistributors foreign key(DistributorId) references Distributors(Id)
)

create table Products(
Id int identity,
Name nvarchar(25),
Description nvarchar(250),
Recipe nvarchar(max),
Price money,
constraint chk_Price check (Price>=0),
constraint pk_Products primary key(Id),
constraint uk_ProductsName unique(Name)
)

create table Customers(
Id int identity,
FirstName nvarchar(25),
LastName nvarchar(25),
Gender char,
Age int,
PhoneNumber char(10),
CountryId int,
constraint chk_Gender check (Gender in ('M','F')),
constraint pk_Customers primary key(Id),
constraint fk_CustomersCountries foreign key(CountryId) references Countries(Id)
)

create table Feedbacks(
Id int identity,
Description nvarchar(255),
Rate decimal(4,2),
ProductId int,
CustomerId int,
constraint pk_Feedback primary key(Id),
constraint fk_Feedback_Products foreign key (ProductId) references Products(Id),
constraint fk_Feedback_Customers foreign key (CustomerId) references Customers(Id)
)

create table ProductsIngredients(
ProductId int,
IngredientId int,
constraint fk_PI_Products foreign key(ProductId) references Products(Id),
constraint fk_PI_Ingredients foreign key(IngredientId) references Ingredients(Id),
constraint pk_ProductsIngredients primary key(ProductId,IngredientId)
)