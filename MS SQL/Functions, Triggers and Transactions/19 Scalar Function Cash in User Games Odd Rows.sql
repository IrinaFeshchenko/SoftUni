create function ufn_CashInUsersGames (@GameName nvarchar(50))
returns @SumCashTable table (SumCash money)
as
begin
insert into @SumCashTable (SumCash)
select sum(rn.Cash) as cash
from    (select GameId, Cash,
        ROW_NUMBER() over (order by Cash desc) as 'RowNumber'
        from UsersGames
        join Games on (UsersGames.GameId=Games.Id)
        where Games.Name=@GameName) as rn
        where (rn.RowNumber%2<>0)
return
end 
GO

select * from dbo.ufn_CashInUsersGames('Lily Stargazer')
