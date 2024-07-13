;WITH #FIRST_ORDER_DATE AS
    (
        SELECT  [customer_id]
    ,MIN([order_date])  AS [first_date]
 FROM    Delivery
 GROUP BY    [customer_id]
     )
SELECT  ROUND(
                CAST(
                        SUM(IIF(d0.[order_date] = d0.[customer_pref_delivery_date], 1, 0)) * 100
                    AS DECIMAL(18, 6)
                ) / COUNT(*)
            ,2
        ) AS [immediate_percentage]
FROM    Delivery d0
    JOIN    #FIRST_ORDER_DATE fd
ON  d0.[customer_id] = fd.[customer_id]
    AND d0.[order_date] = fd.[first_date]