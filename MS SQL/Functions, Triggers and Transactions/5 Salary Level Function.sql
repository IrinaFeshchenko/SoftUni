USE SoftUni
GO

CREATE FUNCTION ufn_GetSalaryLevel(@salary MONEY)
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @ReturnValue VARCHAR(10)

	IF (@salary < 30000)
	SET @ReturnValue = 'Low'
	ELSE IF (@salary BETWEEN 30000 AND 50000)
	SET @ReturnValue = 'Average'
	ELSE IF (@salary > 50000)
	SET @ReturnValue = 'High'

	RETURN @ReturnValue
END