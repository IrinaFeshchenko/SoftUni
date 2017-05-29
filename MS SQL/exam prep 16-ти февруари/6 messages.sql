select Content, SentOn
from Messages
where SentOn > '2014.05.12' and Content like '%just%'
order by Id desc