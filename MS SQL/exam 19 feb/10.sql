select concat(c.FirstName,' ', c.LastName) as CustomerName, PhoneNumber, Gender
from Customers c
left join Feedbacks f on f.CustomerId = c.Id
where f.ProductId is null
order by c.Id asc