;WITH HIGH_VISITS AS
(
    SELECT  [id]
            ,[visit_date]
            ,[people]
            ,[id] - ROW_NUMBER() OVER (ORDER BY [id]) AS [consecutive_group]
    FROM    Stadium
    WHERE   [people] >= 100
)
, RESULT AS
(
    SELECT  [consecutive_group]
    FROM    HIGH_VISITS
    GROUP BY    [consecutive_group]
    HAVING  COUNT(*) >= 3
)
SELECT  [id]
        ,[visit_date]
        ,[people]
FROM    HIGH_VISITS hv
JOIN    RESULT r0
    ON  r0.[consecutive_group] = hv.[consecutive_group]
ORDER BY [id]