BEGIN TRAN
declare @Cost money = (select sum(Price) from Items where MinLevel between 19 and 21)
declare @userID int = (select Id from Users where Username = 'Stamat')
declare @gameId int = (select Id from games where Name = 'Safflower' )
declare @usergameID int = (select Id from UsersGames where UserId = @userID and GameId = @gameId)

IF (((select Cash from UsersGames where Id = @usergameID) - @Cost)< 0 )
BEGIN
	ROLLBACK
	select i.Name as [Item Name]
	from Items i join
	UserGameItems ugi on ugi.ItemId = i.Id
	where UserGameId = (select Id from games where Name = 'Safflower' )
	order by i.Name asc
	return
END
update UsersGames
set Cash -= @Cost
where Id = @usergameID

insert into UserGameItems(ItemId, UserGameId)
select i.Id, ug.Id
from Items i
cross join UsersGames ug 
where MinLevel between 19 and 21 and ug.id = @usergameID
COMMIT


BEGIN TRAN
set @Cost = (select sum(Price) from Items where MinLevel between 11 and 12)
set @userID  = (select Id from Users where Username = 'Stamat')
set @gameId = (select Id from games where Name = 'Safflower' )
set @usergameID  = (select Id from UsersGames where UserId = @userID and GameId = @gameId)

IF (((select Cash from UsersGames where Id = @usergameID) -@Cost)< 0 or @usergameID is null)
BEGIN
	ROLLBACK
	select i.Name as [Item Name]
	from Items i join
	UserGameItems ugi on ugi.ItemId = i.Id
	where UserGameId = (select Id from games where Name = 'Safflower' )
	order by i.Name asc
	RETURN
END

update UsersGames
set Cash -= @Cost
where Id = @usergameID

insert into UserGameItems(ItemId, UserGameId)
select i.Id, ug.Id
from Items i
cross join UsersGames ug 
where MinLevel between 11 and 12 and ug.id = @usergameID
COMMIT