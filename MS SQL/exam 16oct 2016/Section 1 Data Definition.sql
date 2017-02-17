use Airport
go

create table Flights(
FlightID int identity,
DepartureTime date not null,
ArrivalTime date not null,
Status varchar(9) constraint chk_status check (Status in('Departing','Delayed', 'Arrived', 'Cancelled')),
OriginAirportID int constraint fk_flights_airportsOrigin foreign key(OriginAirportID) references Airports(AirportID),
DestinationAirportID int constraint fk_flights_airportsDestination foreign key(DestinationAirportID) references Airports(AirportID),
AirlineID int constraint fk_flights_airlines foreign key(AirlineID) references Airlines(AirlineID),
)

