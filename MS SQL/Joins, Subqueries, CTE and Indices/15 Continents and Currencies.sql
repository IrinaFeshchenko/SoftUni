USE Geography
GO

SELECT maxUsages.ContinentCode, a.CurrencyCode, maxUsages.maxUsage AS CurrencyUsage
FROM
(
	SELECT u.ContinentCode, MAX(u.Usage) AS maxUsage
	FROM
	(
		SELECT c.ContinentCode, c.CurrencyCode, COUNT(*) AS Usage
		FROM  Countries c
		GROUP BY c.ContinentCode,c.CurrencyCode
	) AS u
	GROUP BY ContinentCode
) AS maxUsages

INNER JOIN
(
SELECT c.ContinentCode, c.CurrencyCode, COUNT(*) AS Usage
FROM  Countries c
GROUP BY c.ContinentCode,c.CurrencyCode
) AS a
ON maxUsages.ContinentCode = a.ContinentCode AND maxUsages.maxUsage = a.Usage
WHERE a.Usage != 1
ORDER BY maxUsages.ContinentCode