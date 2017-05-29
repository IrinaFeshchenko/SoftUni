create procedure usp_PurchaseTicket(@CustomerID int, @FlightID int, @TicketPrice decimal(8,2), @Class varchar(6),@Seat varchar(5))
as
begin tran

declare @newBalance decimal(10,2) = (select Balance from CustomerBankAccounts where CustomerID = @CustomerID) - @TicketPrice

IF (@newBalance < 0 or @newBalance is null)
BEGIN
	ROLLBACK
	RAISERROR('Insufficient bank account balance for ticket purchase.', 16, 1)
	RETURN
END

update CustomerBankAccounts
set Balance = @newBalance

declare @TicketID int = isnull((select max(TicketID) from Tickets) + 1,1)

insert into Tickets(TicketID,Price, Class, Seat, CustomerID, FlightID)
values
(@TicketID, @TicketPrice,@Class, @Seat, @CustomerID, @FlightID)

COMMIT