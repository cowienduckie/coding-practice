SELECT  [request_at]    AS [Day]
        ,ROUND(
            SUM(IIF([status] <> 'completed', 1, 0)) * 1.0
            / COUNT(*)
            ,2
        )   AS [Cancellation Rate]
FROM    Trips t0
LEFT JOIN   Users drv
        ON  t0.[driver_id] = drv.[users_id]
LEFT JOIN   Users cln
        ON  t0.[client_id] = cln.[users_id]
WHERE   [request_at] BETWEEN '2013-10-01' AND '2013-10-03'
    AND drv.[banned] = 'No'
    AND cln.[banned] = 'No'
GROUP BY [request_at]