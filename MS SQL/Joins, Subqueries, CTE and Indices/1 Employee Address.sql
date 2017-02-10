USE SoftUni
GO

SELECT TOP 5 e.EmployeeID, e.JobTitle, a.AddressID, AddressText
FROM Employees e
INNER JOIN Addresses a ON e.AddressID = a.AddressID
ORDER BY AddressID ASC