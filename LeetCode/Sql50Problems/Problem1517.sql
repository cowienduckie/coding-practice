SELECT  *
FROM    Users
WHERE   [mail] LIKE '%@leetcode.com'
    AND [mail] NOT LIKE '%[^a-zA-Z0-9_.-]%@leetcode.com%'
    AND [mail] NOT LIKE '[^a-zA-Z]%'