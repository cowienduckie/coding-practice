SELECT   [sell_date]                AS [sell_date]
        ,COUNT(*)                   AS [num_sold]
        ,STRING_AGG([product], ',') AS [products]
FROM    (
    SELECT   [sell_date]
        ,[product]
    FROM    Activities
    GROUP BY [sell_date], [product]
    ) [DistinctActivities]
GROUP BY    [sell_date]
ORDER BY    [sell_date]