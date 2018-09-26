# Insert

-> id = a8b799f1-cfbe-4e1b-bedb-cda927f408b9
-> lifecycle = Acceptance
-> max-retries = 0
-> last-updated = 2018-09-26T18:24:11.1937593Z
-> tags = 

[DD35Storage]
|> GetAllAsync returnValue=0
|> GetByIdAsync id=1
|> CheckName returnValue=EMPTY
|> InsertNewAsync name=test
|> GetAllAsync returnValue=1
|> GetByIdAsync id=1
|> CheckName returnValue=test
~~~
