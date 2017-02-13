USE SoftUni
GO

CREATE PROC usp_GetTownsStartingWith(@match varchar(50))
AS
SELECT Name
FROM towns
WHERE Name LIKE @match+'%'
GO

EXEC usp_GetTownsStartingWith b