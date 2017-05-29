select Id, ChatId, UserId
from Messages m
where ChatId = 17 and (userId not in (select UserId from UsersChats where ChatId = 17)or m.UserId is null)
ORDER BY m.Id DESC