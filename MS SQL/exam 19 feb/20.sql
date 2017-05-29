

select
(select Name from Products where Id = g.id) as ProductName,
(select avg(Rate) from Feedbacks where ProductId = g.Id ) as ProductAverageRate,
(select top 1 Name from Distributors where Id = g.DistributorId) as DistributorName,
(select top 1 Name from Countries where Id = (select CountryId from Distributors where Id = g.DistributorId)) as DistributorCountry
from
(
select distinct * from
	(select p.Id as idd, cast(i.DistributorId as decimal(10,6)) as da
	from Products p
	join ProductsIngredients pi on pi.ProductId = p.Id
	join Ingredients i on i.Id = pi.IngredientId) a
join
	(select p.Id, avg(cast(i.DistributorId as decimal(10,6))) as DistributorId
	from Products p
	join ProductsIngredients pi on pi.ProductId = p.Id
	join Ingredients i on i.Id = pi.IngredientId
	group by p.Id) b
on a.Idd = b.Id 
where a.da = b.DistributorId
) g
order by g.Id asc


select * from products