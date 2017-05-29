USE SoftUni
GO

CREATE PROC usp_GetEmployeesFromTown (@TownName varchar(50))
AS
SELECT FirstName, LastName
FROM Employees e
INNER JOIN Addresses a ON e.AddressID = a.AddressID
INNER JOIN Towns t ON t.TownID = a.TownID
WHERE t.Name = @TownName
GO

EXEC usp_GetEmployeesFromTown Sofia
