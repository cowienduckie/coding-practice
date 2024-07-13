;WITH #UNIQUE_PRODUCTS AS
          (
              SELECT  DISTINCT
     [product_id]    AS [product_id]
 FROM    Products
     )
SELECT   up.[product_id]        AS [product_id]
        ,ISNULL(r0.[price], 10) AS [price]
FROM    #UNIQUE_PRODUCTS up
    OUTER APPLY (
    SELECT  TOP 1
    p0.[new_price]  AS [price]
    FROM    Products p0
    WHERE   p0.[change_date] <= '2019-08-16'
    AND p0.[product_id] = up.[product_id]
    ORDER BY    [change_date] DESC
    ) r0