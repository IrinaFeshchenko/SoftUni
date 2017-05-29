USE SoftUni
GO

SELECT FirstName, LastName
FROM Employees
WHERE UPPER(LEFT(Firstname,2)) = 'SA'