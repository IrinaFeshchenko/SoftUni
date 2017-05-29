select FlightID, DepartureTime, ArrivalTime
from flights
where Status = 'Delayed'