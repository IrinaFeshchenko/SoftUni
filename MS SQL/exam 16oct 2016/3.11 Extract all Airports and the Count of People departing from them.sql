


select a.AirportID, a.AirportName, count(*) as Passengers
from Flights f
join Airports a on a.AirportID = f.OriginAirportID
join Tickets t on t.FlightID = f.FlightID
where f.Status = 'Departing'
group by a.AirportID, a.AirportName