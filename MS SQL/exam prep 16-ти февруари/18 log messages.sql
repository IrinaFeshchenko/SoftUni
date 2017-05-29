CREATE TRIGGER tr_delete_message ON Messages FOR DELETE
AS
BEGIN
	INSERT INTO MessageLogs(id,Content, SentOn, ChatId, UserId)
	SELECT Id, Content, SentOn, ChatId, UserId
	FROM deleted
END