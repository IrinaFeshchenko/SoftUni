USE Geography
GO

SELECT TOP 5 Peaks.CountryName, 
CASE
	WHEN PeakNames.PeakName IS NULL THEN '(no highest peak)'
	ELSE PeakNames.PeakName
END AS HighestPeakName, 
CASE
	WHEN Peaks.maxHeigth IS NULL THEN 0
	ELSE Peaks.maxHeigth
END AS HighestPeakElevation, 
CASE
	WHEN PeakNames.MountainRange IS NULL THEN '(no mountain)'
	ELSE PeakNames.MountainRange
END AS Mountain
FROM

(
	SELECT c.CountryName, MAX(p.Elevation) AS maxHeigth
	FROM Countries c
	LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains m ON m.Id = mc.MountainId
	LEFT JOIN Peaks p ON p.MountainId = m.Id
	GROUP BY c.CountryName
) AS Peaks
LEFT JOIN
(
	SELECT c.CountryName, p.PeakName, m.MountainRange, p.Elevation
	FROM Countries c
	LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains m ON m.Id = mc.MountainId
	LEFT JOIN Peaks p ON p.MountainId = m.Id
) AS PeakNames
ON Peaks.CountryName = PeakNames.CountryName AND Peaks.maxHeigth = PeakNames.Elevation
ORDER BY Peaks.CountryName ASC, PeakNames.PeakName ASC

