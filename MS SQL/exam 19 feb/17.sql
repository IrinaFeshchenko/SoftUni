create function udf_GetRating(@Name varchar(50))
returns varchar(50)
as
begin

declare @rate decimal(4,2) = (
select avg(Rate)
from Products p
join Feedbacks f on f.ProductId = p.Id 
where p.Name = @Name)

declare @result varchar(50)

if (@rate < 5) return 'Bad'
if (@rate <= 8) return 'Average'
if (@rate > 8) return 'Good'
if @rate is null return 'No rating'

return @result
end

go

SELECT TOP 5 Id, Name, dbo.udf_GetRating(Name)
  FROM Products
 ORDER BY Id


 select dbo.udf_GetRating('Root')
