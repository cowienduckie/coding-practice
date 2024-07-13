;WITH #REQUESTS AS 
(
    SELECT  [requester_id]  AS [id]  
    FROM    RequestAccepted
    UNION ALL
    SELECT  [accepter_id]   AS [id]
    FROM    RequestAccepted
)
SELECT  TOP 1
        [id]
        ,COUNT(*) AS [num]
FROM    #REQUESTS
GROUP BY    [id]
ORDER BY    [num] DESC