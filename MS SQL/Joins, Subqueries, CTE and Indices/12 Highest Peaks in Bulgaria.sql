USE Geography
GO

SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Countries c
INNER JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
INNER JOIN Mountains m ON mc.MountainId = m.Id
INNER JOIN Peaks p ON p.MountainId = m.Id
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC