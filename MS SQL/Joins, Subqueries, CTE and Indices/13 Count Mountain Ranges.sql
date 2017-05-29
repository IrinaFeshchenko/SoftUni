USE Geography
GO

WITH cte_MountainRanges
(CountryCode, MountainRange)
AS
(
	SELECT c.CountryCode, m.MountainRange
	FROM Countries c
	INNER JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	INNER JOIN Mountains m ON m.Id = mc.MountainId
	WHERE c.CountryCode IN ('US','BG','RU')
)

SELECT CountryCode, COUNT(MountainRange) AS MountainRanges
FROM cte_MountainRanges
GROUP BY CountryCode