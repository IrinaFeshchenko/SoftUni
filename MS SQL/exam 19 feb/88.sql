

select top 10
(select Name from Products where Id = s.ProductId) as Name,
(select Description from Products where Id = s.ProductId) as Description,
rate as AverageRate,
(select count(*) from Feedbacks where ProductId = s.ProductId) as FeedbacksAmount
from 
(
select ProductId,avg(Rate) as rate
from Feedbacks
group by ProductId
) s
order by AverageRate desc, FeedbacksAmount desc