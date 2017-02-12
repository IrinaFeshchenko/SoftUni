USE Geography
GO

SELECT COUNT(c.CountryCode)
FROM
(
SELECT c.CountryCode
FROM Countries c
WHERE c.CountryCode NOT IN (SELECT CountryCode FROM MountainsCountries)
) AS c