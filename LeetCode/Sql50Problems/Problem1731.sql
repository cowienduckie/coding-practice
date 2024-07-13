;WITH #MANAGERS AS
    (
        SELECT   [reports_to]   AS [employee_id]
    ,COUNT(*)       AS [reports_count]
    ,ROUND(
     AVG(CAST([age] AS DECIMAL(18, 6)))
    ,0
     )               AS [average_age]
 FROM    Employees
 GROUP BY    [reports_to]
     )
SELECT   m0.[employee_id]   AS [employee_id]
        ,e0.[name]          AS [name]
        ,m0.[reports_count] AS [reports_count]
        ,m0.[average_age]   AS [average_age]
FROM    #MANAGERS m0
    JOIN    Employees e0
ON  m0.[employee_id] = e0.[employee_id]
WHERE   [reports_count] > 0