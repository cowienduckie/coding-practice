-- ;WITH #EMPLOYEES AS 
-- (
--     SELECT  [employee_id]
--             ,[department_id]
--             ,RANK() OVER (
--                 PARTITION BY [employee_id] 
--                 ORDER BY [primary_flag] DESC
--             ) AS [department_rank]
--     FROM    Employee
-- )
-- SELECT  [employee_id]
--         ,[department_id]
-- FROM    #EMPLOYEES
-- WHERE   [department_rank] = 1

;WITH #EMPLOYEES AS 
(
    SELECT  [employee_id]
            ,[department_id]
            ,RANK() OVER (
                PARTITION BY [employee_id] 
                ORDER BY [primary_flag] DESC
            ) AS [department_rank]
    FROM    Employee
)
SELECT  [employee_id]
        ,[department_id]
FROM    #EMPLOYEES e0
CROSS APPLY (
    SELECT  COUNT(*)    AS [primary_count]
    FROM    #EMPLOYEES e1
    WHERE   e0.[employee_id] = e1.[employee_id]
        AND e1.[department_rank] = 1
) DuplicatedCheck
WHERE   [department_rank] = 1
    AND [primary_count] = 1