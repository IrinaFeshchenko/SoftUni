create procedure usp_SendFeedback(@CustomerId int, @ProductId int, @Rate decimal(4,2), @Description  nvarchar(250))
as
BEGIN TRAN
 declare @feedbackCount int = (select count(*) from Feedbacks where CustomerId = @CustomerId)

IF (@feedbackCount > 3)
BEGIN
	ROLLBACK
	RAISERROR('You are limited to only 3 feedbacks per product!', 16, 1)
	RETURN
END

insert into Feedbacks(Description, Rate, ProductId, CustomerId)
values (@Description, @Rate, @ProductId, @CustomerId)

COMMIT

select * from Feedbacks

EXEC usp_SendFeedback 1, 5, 7.50, 'Average experience';
SELECT COUNT(*) FROM Feedbacks WHERE CustomerId = 1 AND ProductId = 5;
