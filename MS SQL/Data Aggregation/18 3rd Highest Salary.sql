USE SoftUni
GO

SELECT Ranks.DepartmentID, Ranks.Salary AS ThirdHighestSalary
FROM
(
	SELECT 
	DepartmentID,
	MAX(Salary) AS Salary,
	DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS Rank
	FROM
	Employees
	GROUP BY DepartmentID, Salary
) Ranks
WHERE Rank = 3