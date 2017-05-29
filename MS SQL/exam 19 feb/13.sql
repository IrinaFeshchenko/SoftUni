select d.name, i.Name, p.Name, avg(f.Rate )  as AverageRate
from
(select * from feedbacks f
where f.Rate between 5 and 8) as f
join Products p on p.Id = f.ProductId
left join ProductsIngredients pi on pi.ProductId = p.Id
join Ingredients i on i.Id = pi.IngredientId
join Distributors d on d.Id = i.DistributorId
Group by d.Name , i.Name , p.Name 
order by d.Name asc, i.Name asc, p.Name asc