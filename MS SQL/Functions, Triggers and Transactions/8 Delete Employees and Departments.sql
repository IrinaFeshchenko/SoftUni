ALTER TABLE Departments
ALTER COLUMN ManagerID INT NULL

DELETE FROM EmployeesProjects
WHERE EmployeeID IN (
	SELECT EmployeeID
	FROM Employees e
	INNER JOIN Departments d ON d.DepartmentID = e.DepartmentID
	WHERE d.Name IN ('Production', 'Production Control')
) 

UPDATE Employees
SET ManagerID = NULL
WHERE ManagerID IN (
	SELECT EmployeeID
	FROM Employees e
	INNER JOIN Departments d ON d.DepartmentID = e.DepartmentID
	WHERE d.Name IN ('Production', 'Production Control')
) 

UPDATE Departments
SET ManagerID = NULL
WHERE ManagerID IN (
	SELECT EmployeeID
	FROM Employees e
	INNER JOIN Departments d ON d.DepartmentID = e.DepartmentID
	WHERE d.Name IN ('Production', 'Production Control')
) 

DELETE FROM Employees
WHERE EmployeeID IN (
	SELECT EmployeeID
	FROM Employees e
	INNER JOIN Departments d ON d.DepartmentID = e.DepartmentID
	WHERE d.Name IN ('Production', 'Production Control')
) 

DELETE FROM Departments
WHERE Name IN ('Production', 'Production Control')