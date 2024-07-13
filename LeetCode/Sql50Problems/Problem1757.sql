SELECT  [project_id]
        ,ROUND(
    AVG(CAST(experience_years AS DECIMAL(18, 6)))
        ,2
    ) AS [average_years]
FROM    Project p0
    JOIN    Employee e0
ON  p0.[employee_id] = e0.[employee_id]
GROUP BY   [project_id]