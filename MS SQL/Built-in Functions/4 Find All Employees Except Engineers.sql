USE SoftUni
GO

SELECT FirstName, LastName
FROM Employees
WHERE CHARINDEX('engineer',LOWER(JobTitle),1) = 0