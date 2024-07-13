SELECT  TOP 1 WITH TIES
        [num]
FROM (
    SELECT  TOP 1
            [num]
            ,1  AS [priority]
    FROM    MyNumbers
    GROUP BY    [num]
    HAVING  COUNT(*) = 1
    ORDER BY    [num] DESC
    UNION ALL
    SELECT  NULL    AS [num]
            ,2      AS [priority]
) Results
ORDER BY [priority]