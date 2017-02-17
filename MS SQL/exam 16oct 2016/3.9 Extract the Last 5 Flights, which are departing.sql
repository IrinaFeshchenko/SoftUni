
select *
from
(
select top 5 FlightID, DepartureTime, ArrivalTime, ao.AirportName as Origin, ad.AirportName as Destination
from Flights
join Airports ao on ao.AirportID = Flights.OriginAirportID
join Airports ad on ad.AirportID = Flights.DestinationAirportID
where Status = 'Departing'
order by DepartureTime desc, FlightID asc
) s
order by DepartureTime asc