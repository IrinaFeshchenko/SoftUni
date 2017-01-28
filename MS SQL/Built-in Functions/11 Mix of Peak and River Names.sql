USE Geography
GO

SELECT PeakName,RiverName, 
LOWER(LEFT(PeakName,LEN(PeakName)-1)+RiverName) AS Mix
FROM Peaks,Rivers
WHERE LOWER(RIGHT(PeakName, 1)) = LOWER(LEFT(RiverName, 1))
ORDER BY Mix ASC