select distinct c.CustomerID, concat(FirstName,' ', LastName) as FullName, datediff(year,c.DateOfBirth,'2016') as Age
from Customers c
join Tickets t on t.CustomerID = c.CustomerID
join Flights f on f.FlightID = t.FlightID
where Status = 'Departing'
order by Age asc, c.CustomerID asc