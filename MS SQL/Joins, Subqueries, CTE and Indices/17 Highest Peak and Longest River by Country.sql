USE Geography
GO

SELECT TOP 5 Peaks.CountryName, Peaks.maxHeigth AS HighestPeakElevation, Rivers.maxLength AS LongestRiverLength
FROM

(
	SELECT c.CountryName, MAX(p.Elevation) AS maxHeigth
	FROM Countries c
	LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains m ON m.Id = mc.MountainId
	LEFT JOIN Peaks p ON p.MountainId = m.Id
	GROUP BY c.CountryName
) AS Peaks
INNER JOIN
(
	SELECT c.CountryName, MAX(r.Length) AS maxLength
	FROM Countries c
	LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers r ON r.Id = cr.RiverId
	GROUP BY c.CountryName
) AS Rivers
ON Peaks.CountryName = Rivers.CountryName
ORDER BY Peaks.maxHeigth DESC, Rivers.maxLength DESC, Peaks.CountryName ASC