SELECT  w0.[id]
FROM    Weather w0, Weather w1
WHERE   w0.temperature > w1.temperature
  AND w0.recordDate = DATEADD(DAY, 1, w1.recordDate)