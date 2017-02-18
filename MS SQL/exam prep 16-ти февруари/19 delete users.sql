create trigger tr_users_delete on Users instead of delete
as
begin
	if @@rowcount = 0 return;

	begin tran

	declare @id int = (select Id from deleted)

	delete from UsersChats
	where UserId = @id

	update Messages
	set UserId = null
	where UserId= @id

	delete from Users
	where Id = @id

	if (@@rowcount < 1)
	begin
	rollback
	RAISERROR('error', 16, 1)
	return
	end
end