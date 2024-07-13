;WITH #DATES AS
(
    SELECT  DISTINCT
            [visited_on]
            ,DENSE_RANK() OVER(ORDER BY [visited_on])   AS [rank]
    FROM    Customer
)
SELECT  d0.[visited_on]
        ,SUM(c0.[amount])   AS [amount]
        ,ROUND(
            SUM(c0.[amount]) / 7.0
            ,2
        )   AS [average_amount]
FROM    #DATES d0
JOIN    Customer c0
    ON  c0.[visited_on] BETWEEN DATEADD(DAY, -6, d0.[visited_on]) AND d0.[visited_on]
WHERE   [rank] >= 7
GROUP BY d0.[visited_on]
ORDER BY d0.[visited_on]
