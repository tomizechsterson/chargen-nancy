# Delete

-> id = 8b6e701f-4cd5-4c98-b143-1d5d87a018d0
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-09-26T21:30:10.9894383Z
-> tags = 

[DD35Storage]
|> GetAllAsync returnValue=0
|> InsertNewAsync name=To Delete
|> GetAllAsync returnValue=1
|> GetByIdAsync id=1
|> CheckName returnValue=To Delete
|> DeleteAsync id=1
|> GetAllAsync returnValue=0
~~~
