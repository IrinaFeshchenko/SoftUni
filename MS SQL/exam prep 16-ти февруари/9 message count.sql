select top 5 c.Id, count(*) as TotalMessages
from Chats c
left join Messages m on m.ChatId = c.Id
where m.Id < 90
group by c.Id
order by TotalMessages desc, c.Id asc

