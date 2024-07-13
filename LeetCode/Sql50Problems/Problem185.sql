;WITH #EARNING_RANKS AS
          (
              SELECT   e0.[id]    AS [employeeId]
            ,DENSE_RANK() OVER (
                PARTITION BY e0.[departmentId]
                ORDER BY e0.[salary] DESC
            )           AS [salary_rank]
 FROM    Employee e0
     )
SELECT   d0.[name]      AS [Department]
        ,e0.[name]      AS [Employee]
        ,e0.[salary]    AS [Salary]
FROM    Employee e0
    JOIN    Department d0
ON  e0.[departmentId] = d0.[id]
    JOIN    #EARNING_RANKS er
    ON  er.[employeeId] = e0.[id]
WHERE   er.[salary_rank] <= 3