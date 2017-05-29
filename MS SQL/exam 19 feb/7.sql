select top 15 i.Name, i.Description ,  c.Name as CountryName
from Ingredients i
join Countries c on c.Id = i.OriginCountryId
where c.Name in ('Bulgaria', 'Greece')
order by i.Name asc, c.Name asc
