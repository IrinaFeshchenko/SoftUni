create procedure udp_SendMessage(@userId int, @chatId int, @content varchar(200))
as
begin tran

	if ((select UserId from UsersChats where UserId = @userId and ChatId = @chatId) is null)
	begin
	ROLLBACK
	RAISERROR('There is no chat with that user!', 16, 1)
	RETURN
	end
insert into Messages(Content, SentOn, ChatId, UserId )
values 
(@content, '2016-12-15', @chatId, @userId)

commit

