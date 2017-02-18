create procedure udp_ChangePassword(@email varchar(30), @password varchar(30))
as
begin tran
 declare @id int = (select Id from Credentials where Email = @email)
 
if (@id is null)
begin
rollback
	RAISERROR('The email does''t exist!', 16, 1)
return
end
 update Credentials
 set Password = @password
 where Id = @id
commit