USE SoftUni
GO

SELECT TOP(10) FirstName, LastName, DepartmentID
FROM Employees a
WHERE Salary > (SELECT AverageSalary FROM
(SELECT DepartmentID, AVG(Salary) AS AverageSalary FROM Employees WHERE DepartmentID = a.DepartmentID GROUP BY DepartmentID) S)