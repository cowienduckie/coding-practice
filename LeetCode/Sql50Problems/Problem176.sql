-- SELECT  TOP 1
--         WITH TIES
--         [salary]    AS [SecondHighestSalary]
-- FROM (
--     SELECT  [salary]
--             ,1  AS [priority]
--     FROM    (
--         SELECT  DISTINCT
--                 [salary]
--                 ,DENSE_RANK() OVER (ORDER BY [salary] DESC) AS [rank]
--         FROM    Employee
--     ) AS SalaryRanks
--     WHERE   [rank] = 2
--     UNION ALL
--     SELECT  NULL    AS [salary]
--             ,2      AS [priority]
-- ) Results
-- ORDER BY [priority]

;WITH SalaryRanks AS
(
    SELECT   DISTINCT
             [salary]
            ,DENSE_RANK() OVER (ORDER BY [salary] DESC) AS [rank]
    FROM    Employee
)
SELECT  sr1.[salary]    AS [SecondHighestSalary]
FROM    SalaryRanks sr0
LEFT JOIN   SalaryRanks sr1
        ON  sr0.[rank] = sr1.[rank] - 1
WHERE   sr0.[rank] = 1