CREATE DATABASE TheNerdHerd
GO

USE TheNerdHerd
GO

create table Locations(
Id int identity,
Latitude float,
Longitude float,
constraint pk_locations primary key(Id)
)

create table Credentials(
Id int identity,
Email varchar(30),
Password varchar(30),
constraint pk_credentials primary key(Id)
)

create table Users(
Id int identity,
Nickname varchar(25),
Gender char(1),
Age int,
LocationId int   ,
CredentialId int ,
constraint fkul foreign key(LocationId) references Locations(Id),
constraint fkuc foreign key(CredentialId) references Credentials(Id),
constraint pk_users primary key(Id),
constraint uku unique(CredentialId)
)

create table Chats(
Id int identity,
Title varchar(32),
StartDate date,
IsActive bit,
constraint pk_chats primary key(Id)
)

create table Messages(
Id int identity,
Content varchar(200),
SentOn date,
ChatId int ,
UserId int ,
constraint fkmcu foreign key(UserId) references Users(Id),
constraint fkmcc foreign key(ChatId) references Chats(Id),
constraint pk_messages primary key(Id)
)

create table UsersChats(
UserId int ,
ChatId int ,
constraint fkucu foreign key(UserId) references Users(Id),
constraint fkucc foreign key(ChatId) references Chats(Id),
constraint pk_UsersChats primary key(ChatId,UserId)
)
