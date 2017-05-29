USE Geography
GO

SELECT TOP 5 c.CountryName, r.RiverName
FROM Countries c
JOIN Continents co ON co.ContinentCode = c.ContinentCode
LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers r ON r.Id = cr.RiverId
WHERE co.ContinentName = 'Africa'
ORDER BY c.CountryName ASC