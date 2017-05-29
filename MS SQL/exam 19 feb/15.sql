
select *
from countries c


select CountryId, (select top 1 with ties DistributorId, count (i.id) as count
from Distributors d
join Ingredients i on i.DistributorId = d.Id
group by DistributorId
order by count desc) as rrr
from Countries
order by CountryId


select *
(select top 1 with ties DistributorId, count (i.id) as count
from Distributors d
join Ingredients i on i.DistributorId = d.Id
group by DistributorId
order by count desc) d
join Countries
