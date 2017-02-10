USE SoftUni
GO

SELECT TOP 50 e.EmployeeID, e.FirstName + ' ' + e.LastName AS EmployeeName, M.FirstName + ' ' + M.LastName AS ManagerName, d.Name
FROM Employees e
INNER JOIN Employees m ON e.ManagerID = m.EmployeeID
INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID ASC