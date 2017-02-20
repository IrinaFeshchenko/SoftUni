select f.ProductId, f.Rate, f.Description, f.CustomerId, c.Age, c.Gender
from Customers c
join Feedbacks f on f.CustomerId = c.Id
where f.Rate < 5
order by f.ProductId desc, f.Rate asc