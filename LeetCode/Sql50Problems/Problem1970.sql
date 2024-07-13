SELECT  [category]
        ,SUM(IIF([account_id] IS NOT NULL, 1, 0))   AS [accounts_count]
FROM    Accounts a0
CROSS APPLY (
    SELECT  CASE
                WHEN [income] < 20000 THEN 1
                WHEN [income] > 50000 THEN 3
                ELSE 2
            END [category_id]
)   sc
RIGHT JOIN (
    VALUES   (1, 'Low Salary')
            ,(2, 'Average Salary')
            ,(3, 'High Salary')
)   c0([id], [category])
    ON c0.[id] = sc.[category_id]
GROUP BY    [category]