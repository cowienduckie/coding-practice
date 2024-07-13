;WITH #MANAGERS AS
(
    SELECT   [ManagerId]    AS Id
            ,COUNT(*)       AS DirectReports
    FROM    Employee
    GROUP BY    [ManagerId]
 )
SELECT  [Name]      AS [name]
FROM    Employee    e0
    JOIN    #MANAGERS   m0
ON  m0.[Id] = e0.[Id]
WHERE   m0.DirectReports >= 5