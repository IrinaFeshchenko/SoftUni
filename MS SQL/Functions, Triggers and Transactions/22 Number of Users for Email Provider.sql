
select u.email as [Email Provider],count(*) as [Number of Users]
from
(
select substring(email,
        charindex('@',email,1)+1,
        len(email)) as email
from users
) u
group by email
order by [Number of Users] desc, [Email Provider]