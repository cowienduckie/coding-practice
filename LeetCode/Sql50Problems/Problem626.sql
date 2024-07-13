SELECT  [id]
        ,ISNULL([new_student], [student])  AS [student]
FROM    Seat s0
OUTER APPLY (
    SELECT  s1.[student] AS [new_student]
    FROM    Seat s1
    WHERE   (s0.[id] % 2 = 1 AND s1.[id] = s0.[id] + 1)
        OR  (s0.[id] % 2 = 0 AND s1.[id] = s0.[id] - 1)
) NewStudents

-- ;WITH #ODD_STUDENTS AS
-- (
--     SELECT  [id] - 1 AS [id]
--             ,[student]
--     FROM    Seat
--     WHERE   [id] % 2 = 0
-- )
-- ,#EVEN_STUDENTS AS
-- (
--     SELECT  [id] + 1 AS [id]
--             ,[student]
--     FROM    Seat
--     WHERE   [id] % 2 = 1
-- )
-- SELECT  s0.[id]
--         ,CASE
--             WHEN s0.[id] % 2 = 0 THEN es.[student]
--             ELSE
--                 COALESCE(os.[student], s0.[student])
--         END AS [student]
-- FROM    Seat s0
-- LEFT JOIN   #ODD_STUDENTS os
--         ON  s0.[id] = os.[id]
-- LEFT JOIN   #EVEN_STUDENTS es
--         ON  s0.[id] = es.[id]