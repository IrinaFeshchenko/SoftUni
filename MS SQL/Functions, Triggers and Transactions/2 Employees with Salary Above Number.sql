USE SoftUni
GO

CREATE PROC usp_GetEmployeesSalaryAboveNumber (@number MONEY)
AS
SELECT FirstName, LastName
FROM Employees
WHERE Salary >= @number
GO

EXEC usp_GetEmployeesSalaryAboveNumber 48100