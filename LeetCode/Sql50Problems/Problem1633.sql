SELECT  [contest_id]
        ,ROUND(
            COUNT(*) * 100.0 / [total_users]
            ,2
        )   AS [percentage]
FROM    Register
CROSS APPLY (
    SELECT  COUNT(*)    AS [total_users]
    FROM    Users
) TotalUsers
GROUP BY    [contest_id], [total_users]
ORDER BY    [percentage] DESC
            ,[contest_id] ASC