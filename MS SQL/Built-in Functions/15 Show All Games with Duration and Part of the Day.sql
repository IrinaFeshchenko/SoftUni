USE Diablo
GO

SELECT 
Name AS Game, 

CASE
	WHEN DATEPART(hh, Start) <12 THEN 'Morning'
	WHEN DATEPART(hh, Start) <18 THEN 'Afternoon'
	WHEN DATEPART(hh, Start) <24 THEN 'Evening'
END AS [Part of the Day],

CASE
	WHEN Duration <=3 THEN 'Extra Short'
	WHEN Duration <=6 THEN 'Short'
	WHEN Duration >6 THEN 'Long'
	WHEN Duration IS NULL THEN 'Extra Long'
END AS Duration

FROM Games
ORDER BY Name ASC, Duration ASC, [Part of the Day] ASC