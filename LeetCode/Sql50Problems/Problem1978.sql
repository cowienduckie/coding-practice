SELECT  e0.[employee_id]
FROM    Employees   e0
LEFT JOIN   Employees m0
    ON  e0.[manager_id] = m0.[employee_id]
WHERE   e0.[manager_id] IS NOT NULL
    AND m0.[employee_id] IS NULL
    AND e0.[salary] < 30000
ORDER BY    e0.[employee_id]