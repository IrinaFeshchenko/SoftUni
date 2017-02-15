USE Bank
GO

CREATE FUNCTION ufn_CalculateFutureValue(@sum money, @interest float, @years int)
RETURNS money
AS
BEGIN
	DECLARE @fv money = 0
	SET @fv = @sum * POWER((1+@interest),@years)
	RETURN @fv
END
GO

SELECT dbo.ufn_CalculateFutureValue(1000,0.1,5)