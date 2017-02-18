select c.Id, Title, m.Id
from Messages m
join Chats c on c.Id = m.ChatId
where SentOn < '2012.03.26' and right(Title,1)  = 'x'
order by c.Id asc, m.Id asc