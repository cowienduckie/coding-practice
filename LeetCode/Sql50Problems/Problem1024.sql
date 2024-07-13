SELECT  TOP 1
        [person_name]
FROM    [Queue] q1
CROSS APPLY (
    SELECT  SUM(q2.[weight])    AS [bus_weight]
    FROM    [Queue] q2
    WHERE   q2.[turn] <= q1.[turn]
)   Weights
WHERE   [bus_weight] <= 1000
ORDER BY    [turn] DESC