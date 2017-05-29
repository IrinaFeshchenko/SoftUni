update tickets
set Price = Price * 1.5
where FlightID in 
(
select f.FlightID
from Airlines a
join Flights f on f.AirlineID = a.AirlineID
join Tickets t on t.FlightID = f.FlightID
where a.Rating = (select top 1 rating from Airlines order by Rating desc)
)
