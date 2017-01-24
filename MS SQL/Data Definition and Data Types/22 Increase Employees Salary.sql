USE SoftUni
GO

SELECT Salary FROM Employees
GO
UPDATE Employees
SET Employees.Salary = Employees.Salary * 1.10
GO
SELECT Salary FROM Employees