;
WITH #REVENUES AS
    (SELECT
   [product_id]
   , SUM ([price] * [units]) AS [revenue]
   , SUM (ISNULL([units]
   , 0)) AS [total_units]
FROM Prices p0
    CROSS APPLY (
    SELECT SUM (units) AS [units]
    FROM UnitsSold us
    WHERE us.[product_id] = p0.[product_id]
    AND us.[purchase_date] BETWEEN p0.[start_date] AND p0.[end_date]
    ) us
GROUP BY [product_id]
    )
SELECT [product_id]
        , CASE
    WHEN [total_units] = 0 THEN 0
    ELSE
    ROUND(
    CAST ([revenue] AS DECIMAL (18, 6)) / [total_units]
        , 2
    )
END
AS [average_price]
FROM    #REVENUES