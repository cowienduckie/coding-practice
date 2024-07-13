SELECT   e0.[name]
     ,b0.[bonus]
FROM    Employee e0
            LEFT JOIN   Bonus b0
                        ON  e0.[empId] = b0.[empId]
WHERE   b0.[bonus] < 1000
   OR  b0.[bonus] IS NULL