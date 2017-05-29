select FirstName, Age, PhoneNumber
from Customers
where (Age>=21 and (FirstName like '%an%')) or ((PhoneNumber like '%38') and 
CountryId not in (select Id
from Countries
where Name = 'Greece' and Id is not null)
)
order by FirstName asc, Age desc
