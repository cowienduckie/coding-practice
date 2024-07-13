SELECT   s0.[user_id]   AS [user_id]
        ,CASE
            WHEN r0.[RequestedNo] = 0 THEN 0
            ELSE
                ROUND(
                    CAST([ConfirmNo] AS DECIMAL(18, 2)) / [RequestedNo]
                    ,2
                )
        END             AS [confirmation_rate]
FROM    Signups s0
CROSS APPLY (
    SELECT   SUM(IIF([action] = 'confirmed', 1, 0)) AS [ConfirmNo]
            ,COUNT(*)                               AS [RequestedNo]
    FROM    Confirmations c0
    WHERE   c0.[user_id] = s0.[user_id]
) r0