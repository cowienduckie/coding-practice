SELECT  DISTINCT
    l1.[num]    AS [ConsecutiveNums]
FROM    Logs l0, Logs l1, Logs l2
WHERE   l0.num = l1.num
  AND l1.num = l2.num
  AND l0.id = l1.id - 1
  AND l2.id = l1.id + 1