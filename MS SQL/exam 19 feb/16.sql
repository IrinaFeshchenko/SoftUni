create view v_UserWithCountries 
as
select concat(FirstName,' ',LastName) as CustomerName, Age, Gender, ct.Name as CountryName
from Customers c
join Countries ct on ct.Id = c.CountryId



SELECT TOP 5 *
  FROM v_UserWithCountries
 ORDER BY Age
