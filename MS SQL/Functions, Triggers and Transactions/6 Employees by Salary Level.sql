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
GO

CREATE PROCEDURE usp_EmployeesBySalaryLevel(@salaryLevel VARCHAR(10))
AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE  dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
END
GO

EXEC usp_EmployeesBySalaryLevel 'High'