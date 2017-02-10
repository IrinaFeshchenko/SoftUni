USE SoftUni
GO

SELECT TOP 5 e.EmployeeID, e.FirstName, e.Salary, d.Name
FROM Employees e
INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE Salary > 15000
ORDER BY e.DepartmentID ASC