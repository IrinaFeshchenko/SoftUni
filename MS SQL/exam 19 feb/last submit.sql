

select d.Name as DistributorName, i.Name as IngredientName,
(select Name from Products where id = p.ProductId) as ProductName,
p.rate as AverageRate
from
(
select ProductId, avg(Rate) as rate
from Feedbacks
group by ProductId
having avg(Rate) between 5 and 8
) p
join 
ProductsIngredients pi on p.ProductId = pi.ProductId
join Ingredients i on i.Id = pi.IngredientId
join Distributors d on d.Id = i.DistributorId
order by d.Name asc, i.Name asc, ProductName asc