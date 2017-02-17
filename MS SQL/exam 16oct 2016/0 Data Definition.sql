create table Flights(
FlightID int primary key,
DepartureTime datetime not null,
ArrivalTime datetime not null,
Status varchar(9) check (Status in('Departing','Delayed', 'Arrived', 'Cancelled')),
OriginAirportID int foreign key references Airports(AirportID),
DestinationAirportID int foreign key references Airports(AirportID),
AirlineID int foreign key references Airlines(AirlineID),
)

create table Tickets(
TicketID int primary key,
Price decimal(8,2) not null,
Class varchar(6) check (Class in ('First', 'Second', 'Third')),
Seat varchar(5) not null,
CustomerID int foreign key references Customers(CustomerID),
FlightID int foreign key references Flights(FlightID)
)
