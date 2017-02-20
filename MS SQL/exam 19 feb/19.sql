create trigger tr_products_delete on Products instead of delete
as
begin
	if @@rowcount = 0 return;

	begin tran

	declare @id int = (select Id from deleted)

	delete from ProductsIngredients
	where ProductId = @id

	delete from Feedbacks
	where ProductId = @id

	if (@@rowcount < 1)
	begin
	rollback
	RAISERROR('error', 16, 1)
	return
	end
		
	delete from Products
	where Id = @id
	commit
end

DELETE FROM Products WHERE Id = 7