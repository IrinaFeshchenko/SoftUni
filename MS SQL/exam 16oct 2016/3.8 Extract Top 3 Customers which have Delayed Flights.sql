select top 3 c.CustomerID, c.FirstName+' '+c.LastName, t.Price, a.AirportName as destination
from Customers c
join Tickets t on t.CustomerID = c.CustomerID
join Flights f on f.FlightID = t.FlightID
join Airports a on a.AirportID = f.DestinationAirportID
where f.Status = 'Delayed'
order by t.Price desc