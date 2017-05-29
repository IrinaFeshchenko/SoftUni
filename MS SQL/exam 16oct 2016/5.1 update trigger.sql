create table ArrivedFlights(
FlightID int primary key,
ArrivalTime datetime not null,
Origin varchar(50) not null,
Destination varchar(50) not null,
Passengers int not null
)
go


CREATE TRIGGER tr_Flights_After_Update ON Flights FOR UPDATE
AS
BEGIN

		insert into ArrivedFlights(FlightID,ArrivalTime,Origin,Destination,Passengers)
		select f.FlightID, f.ArrivalTime, oa.AirportName, da.AirportName, (select count(*) from Tickets where FlightID = f.FlightID)
		from inserted f
		join Airports oa on f.OriginAirportID = oa.AirportID
		join Airports da on f.DestinationAirportID = da.AirportID
		where f.Status = 'Arrived'
END
