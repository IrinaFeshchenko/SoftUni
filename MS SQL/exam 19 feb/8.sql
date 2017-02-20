select top 10 r.Name,p.Description, AverageRate, FeedbacksAmount
 from
(select p.Name, AVG(Rate) as AverageRate, count(*) as FeedbacksAmount
from Products p
join Feedbacks f on f.ProductId = p.Id
group by p.Name
) r
join Products p on p.Name = r.Name
order by AverageRate desc

