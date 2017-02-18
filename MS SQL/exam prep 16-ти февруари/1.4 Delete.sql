
delete from Locations
where Id not in (select LocationId from Users where LocationId is not null)

