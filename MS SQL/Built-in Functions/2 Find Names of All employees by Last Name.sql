USE SoftUni
GO

SELECT FirstName, LastName
FROM Employees
WHERE CHARINDEX('ei',LOWER(LastName)) != 0 