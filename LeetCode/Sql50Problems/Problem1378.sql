SELECT   eu.[unique_id]
     ,e0.[name]
FROM    Employees e0
LEFT JOIN   EmployeeUNI eu
            ON  e0.[id] = eu.[id]