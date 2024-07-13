;WITH #SAME_TIV_2015 AS
(
    SELECT  [tiv_2015]
    FROM    Insurance
    GROUP BY    [tiv_2015]
    HAVING  COUNT(*) > 1
)
, #UNIQUE_LOCATION AS
(
    SELECT  [lat]
            ,[lon]
    FROM    Insurance
    GROUP BY    [lat], [lon]
    HAVING  COUNT(*) = 1
)
SELECT  ROUND(
            SUM([tiv_2016])
            ,2
        ) AS [tiv_2016]
FROM    Insurance i0
JOIN    #SAME_TIV_2015 st
    ON  i0.[tiv_2015] = st.[tiv_2015]
JOIN    #UNIQUE_LOCATION ul
    ON  i0.[lat] = ul.[lat]
    AND i0.[lon] = ul.[lon]