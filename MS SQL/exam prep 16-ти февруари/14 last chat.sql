select top 1 with ties c.Title, m.Content
from Chats c
left join Messages m on m.ChatId = c.Id
order by c.StartDate desc, m.SentOn asc
