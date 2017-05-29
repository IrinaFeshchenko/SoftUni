create procedure usp_SubmitReview(@CustomerID int, @ReviewContent varchar(255), @ReviewGrade int, @AirlineName varchar(30))
as
begin tran
	insert into CustomerReviews(ReviewID,ReviewContent,ReviewGrade,AirlineID,CustomerID)
	values(isnull((select max(ReviewID) from CustomerReviews),0)+1 ,@ReviewContent,@ReviewGrade, (select AirlineID from Airlines  where AirlineName = @AirlineName),@CustomerID)

if (@AirlineName not in (select AirlineName from Airlines))
BEGIN
	ROLLBACK
	RAISERROR('Airline does not exist.', 16, 1)
	RETURN
END
COMMIT