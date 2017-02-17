select distinct c.CustomerID, c.FirstName + ' ' + c.LastName as FullName, DATEDIFF(YEAR,DateOfBirth,'20160101') as Age
from Customers c
join Tickets t on t.CustomerID = c.CustomerID
join Flights f on f.FlightID = t.FlightID

where DATEDIFF(YEAR,DateOfBirth,'20160101')<21 and f.Status = 'Arrived'
order by Age desc, c.CustomerID asc