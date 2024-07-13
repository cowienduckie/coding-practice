SELECT  [month]
        ,[country]
        ,COUNT(*)                                      AS [trans_count]
        ,SUM(IIF([state] = 'approved', 1, 0))          AS [approved_count]
        ,SUM([amount])                                 AS [trans_total_amount]
        ,SUM(IIF([state] = 'approved', [amount], 0))   AS [approved_total_amount]
FROM    Transactions t0
CROSS APPLY (
    SELECT  FORMAT([trans_date], 'yyyy-MM') AS [month]
    FROM    Transactions t1
    WHERE   t1.[id] = t0.[id]
) MonthStrings
GROUP BY    [country], [month]