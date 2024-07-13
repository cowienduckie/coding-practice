;WITH #TOTAL_PLAYERS AS
(
    SELECT  COUNT(DISTINCT [player_id])  AS [total_players]
    FROM    Activity
)
, #FIRST_LOGIN AS 
(
    SELECT  [player_id]
            ,MIN([event_date])  AS [first_login]
    FROM    Activity
    GROUP BY    [player_id]
)
, #LOGIN_AGAIN AS 
(
    SELECT  COUNT(DISTINCT a0.[player_id]) AS [login_again]
    FROM    Activity a0
    JOIN    #FIRST_LOGIN fl
        ON  a0.[player_id] = fl.[player_id]
        AND a0.[event_date] = DATEADD(DAY, 1, fl.[first_login])
    
)
SELECT  ROUND(
            [login_again] * 1.0 / [total_players] 
            ,2
        ) AS [fraction]
FROM    #TOTAL_PLAYERS, #LOGIN_AGAIN