select Name, Description, OriginCountryId
from Ingredients
where OriginCountryId in (1,10,20)
order by Id asc