select distinct c.CustomerID, c.FirstName + ' ' + c.LastName as FullName, tw.TownName as HomeTown
from Customers c
join tickets t on t.CustomerID = c.CustomerID
join Flights f on f.FlightID = t.FlightID
join Airports a on a.AirportID = f.OriginAirportID
join Towns tw on tw.TownID = c.HomeTownID
where c.HomeTownID = a.TownID
order by c.CustomerID asc
