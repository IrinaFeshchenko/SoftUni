select f.ProductId, concat(c.FirstName,' ',c.LastName) as CustomerName, f.Description as FeedbacksDescription
from
(select CustomerId, count(CustomerId) as count
from Feedbacks
group by CustomerId
having count(*) > 2
) r
join Feedbacks f on f.CustomerId = r.CustomerId
join Customers c on f.CustomerId = c.Id
order by f.ProductId asc, CustomerName asc, f.Id asc

select * from Feedbacks
where CustomerId = 14