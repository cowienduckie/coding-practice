SELECT   [student_id]
        ,[student_name]
        ,[subject_name]
        ,[attended_exams]
FROM    Students s0
    CROSS JOIN  Subjects s1
    CROSS APPLY (
    SELECT  COUNT(*)    AS [attended_exams]
    FROM    Examinations e0
    WHERE   s0.[student_id] = e0.[student_id]
    AND s1.[subject_name] = e0.[subject_name]
    ) r0
ORDER BY [student_id], [subject_name]