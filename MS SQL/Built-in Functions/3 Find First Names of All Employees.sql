USE SoftUni
GO

SELECT FirstName
FROM Employees
WHERE DepartmentID IN(3,10) AND (HireDate >='19950101' AND HireDate <='20051212')