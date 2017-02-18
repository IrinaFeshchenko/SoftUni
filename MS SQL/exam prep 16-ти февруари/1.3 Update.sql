
update c
set c.StartDate = x.FirstSentOn
from Chats as c
join 
(
select c.Id, c.StartDate, min(m.SentOn) as FirstSentOn
from Chats c
join Messages m on m.ChatId = c.Id
where c.StartDate > m.SentOn
group by c.Id, c.StartDate
) as x on x.Id = c.Id
