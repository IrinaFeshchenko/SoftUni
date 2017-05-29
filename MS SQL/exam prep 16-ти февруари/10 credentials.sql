select distinct u.Nickname, c.Email, c.Password
from Users u
join Credentials c on c.Id = u.CredentialId
where c.Email like '%co.uk'
order by c.Email asc