use TheNerdHerd
go

insert into Messages(Content, SentOn, ChatId, UserId)
select 
concat(Age,'-',Gender,'-',Latitude,'-',Longitude) as Content, getdate() as SentOn, 
CASE
when Gender = 'F' then ceiling(sqrt(Age*2))
when Gender = 'M' then ceiling(power(Age/18,3))
END as ChatId,
Users.Id
from Users
join Locations on Users.LocationId = Locations.Id
where Users.Id between 10 and 20
