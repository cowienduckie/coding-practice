;WITH #SALES AS
    (
        SELECT   [product_id]
    ,[year]
    ,[quantity]
    ,[price]
    ,RANK() OVER(PARTITION BY [product_id] ORDER BY [year]) AS [sale_year_rank]
 FROM    Sales
     )
SELECT   [product_id]    AS [product_id]
        ,[year]         AS [first_year]
        ,[quantity]     AS [quantity]
        ,[price]        AS [price]
FROM    #SALES
WHERE   [sale_year_rank] = 1