SELECT  [query_name]
        ,ROUND(
            AVG([rating] * 1.0 / [position])
            ,2
        ) AS [quality]
        ,ROUND(
            SUM(IIF([rating] < 3, 1, 0)) * 100.0 / COUNT(*)
            ,2
        ) AS [poor_query_percentage]
FROM    Queries
WHERE   [query_name] IS NOT NULL
GROUP BY [query_name]