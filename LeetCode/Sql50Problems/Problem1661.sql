SELECT   [machine_id]
        ,ROUND(
    AVG(
    CASE
    WHEN [activity_type] = 'start'  THEN -[timestamp]
    WHEN [activity_type] = 'end'    THEN [timeStamp]
    END
    ) * 2
        ,3
    )   AS [processing_time]
FROM    Activity
GROUP BY    machine_id