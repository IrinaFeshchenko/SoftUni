USE MinionsDB

create table Countries(
Id int identity primary key,
Name varchar(20) not null
)

create table Towns(
Id int identity primary key,
Name varchar(20) not null,
CountryId int foreign key references Countries(Id)
)

create table Minions(
Id int identity primary key,
Name varchar(20) not null,
Age int not null,
TownId int foreign key references Towns(Id)
)

create table Villains(
Id int identity primary key,
Name varchar(20) not null,
Evilness varchar(10) check (Evilness in ('good', 'bad', 'evil', 'super evil')),
)

create table VillainsMinions(
VillainId int foreign key references Villains(Id),
MinionId int foreign key references Minions(Id),
constraint pk_VillainsMinions primary key(VillainId, MinionId)
)

insert into Countries(Name)
values
('Bahamas'),
('Brunei'),
('Haiti'),
('Aruba'),
('Grenada'),
('Bulgaria')

insert into Towns(Name, CountryId)
values
('Nassau',1),
('Freeport',1),
('Weat End',1),
('Kaula Belait',2),
('Bangar',2),
('Turtong',2),
('Abricots',3),
('Ennery',3),
('Ferrier',3),
('Boton',4),
('Bubali',4),
('Cashero',4),
('Belmont',5),
('Grenville',5),
('Tivoli',5),
('Sofia',6),
('Varna',6),
('Burgas',6)


insert into Villains(Name, Evilness)
values 
('Felonius Gru','good'),
('Vector','bad'),
('Mr. Perkins', 'evil'),
('Balthazar Bratt','super evil'),
('Eduardo Perez','good')

insert into Minions(Name,Age,TownId)
values
('Carl',20,1),
('Dave',21,2),
('Jerry',17,3),
('John',15,4),
('Kevin',23,5),
('Mark',27,1),
('Phill',19,2),
('Stuart',22,3),
('Tim',24,4),
('Lance',25,5),
('Tom',18,1),
('Ken',22,2),
('Mike',23,3),
('Chris',21,4),
('Eric',20,5)

insert into VillainsMinions(VillainId, MinionId)
values
(1,3),
(2,4),
(2,3),
(3,2),
(3,3),
(3,1),
(4,1),
(4,4),
(4,5),
(4,3),
(5,1),
(5,2),
(5,4),
(5,3),
(5,5)

