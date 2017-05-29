select TicketID, a.AirportName, c.FirstName + ' ' + c.LastName as CustomerName
from tickets t
join flights f on f.FlightID = t.FlightID
join Airports a on a.AirportID = f.DestinationAirportID
join Customers c on c.CustomerID = t.CustomerID
where price < 5000 and Class = 'First'