SELECT   p0.[product_name]
     ,s0.[year]
        ,s0.[price]
FROM    Sales s0
    JOIN    Product p0
ON  s0.[product_id] = p0.[product_id]