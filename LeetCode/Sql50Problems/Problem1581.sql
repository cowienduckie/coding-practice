SELECT   v0.[customer_id]   AS [customer_id]
        ,COUNT(*)           AS [count_no_trans]
FROM    Visits v0
    LEFT JOIN   Transactions t0
ON  v0.[visit_id] = t0.[visit_id]
WHERE   t0.[visit_id] IS NULL
GROUP BY    v0.[customer_id]