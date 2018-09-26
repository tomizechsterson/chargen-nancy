# Insert

-> id = a8b799f1-cfbe-4e1b-bedb-cda927f408b9
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-09-26T21:30:13.4289677Z
-> tags = 

[DD35Storage]
|> GetAllAsync returnValue=0
|> GetByIdAsync id=1
|> CheckName returnValue=none
|> InsertNewAsync name=test
|> GetAllAsync returnValue=1
|> GetByIdAsync id=1
|> CheckName returnValue=test
|> DeleteAsync id=1
~~~
