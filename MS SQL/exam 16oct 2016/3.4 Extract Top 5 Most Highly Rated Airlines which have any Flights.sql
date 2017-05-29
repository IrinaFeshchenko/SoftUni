select top 5 *
from airlines
where AirlineID in (select AirlineId from Flights)
order by Rating desc, AirlineID asc