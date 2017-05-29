select Nickname, Title, Latitude, Longitude
from users u
join Locations l on u.LocationId = l.Id
join UsersChats uc on uc.UserId = u.Id
join Chats c on c.Id = uc.ChatId
where (l.Latitude between 41.13999 and 44.12999) and (l.Longitude between 22.20999 and 28.35999)
order by title asc