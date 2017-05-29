USE Diablo
GO

SELECT TOP(50) 
	Name, 
	CONCAT(	
				DATEPART(yyyy,Start),
				'-', 
				RIGHT('0' + CONVERT(VARCHAR,DATEPART(m,Start)),2),
				'-',
				RIGHT('0' + CONVERT(VARCHAR,DATEPART(dd,Start)),2)
			)
FROM Games
WHERE DATEPART(year,Start) IN (2011, 2012)
ORDER BY Start, Name