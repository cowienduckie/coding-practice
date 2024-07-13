SELECT  *
FROM    Triangle
CROSS APPLY (
    SELECT  CASE
                WHEN    x + y > z
                    AND x + z > y
                    AND y + z > x
                THEN 'Yes'
                ELSE 'No'
            END AS [triangle]
) SegmentCheck