;WITH #MOST_RATED_USER AS
(
    SELECT  TOP 1
            u0.[name]   AS [results]
    FROM    MovieRating mr
    JOIN    Users u0
        ON  mr.[user_id] = u0.[user_id]
    GROUP BY    u0.[user_id], u0.[name]
    ORDER BY    COUNT(*) DESC, u0.[name] ASC
)
,#HIGHEST_RATING_FEB_2020 AS
(
    SELECT  TOP 1
            m0.[title]  AS [results]
    FROM    MovieRating mr
    JOIN    Movies m0
        ON  mr.[movie_id] = m0.[movie_id]
    WHERE   mr.[created_at] BETWEEN '2020-02-01' AND '2020-02-29'
    GROUP BY    m0.[movie_id], m0.[title]
    ORDER BY    AVG(mr.[rating] * 1.0) DESC, m0.[title]
)
SELECT  *
FROM    #MOST_RATED_USER
UNION ALL
SELECT  *
FROM    #HIGHEST_RATING_FEB_2020