# Delete

-> id = 8b6e701f-4cd5-4c98-b143-1d5d87a018d0
-> lifecycle = Acceptance
-> max-retries = 0
-> last-updated = 2018-09-26T18:50:18.7725810Z
-> tags = 

[DD35Storage]
|> GetAllAsync returnValue=0
|> InsertNewAsync name=To Delete
|> GetAllAsync returnValue=1
|> DeleteAsync id=1
|> GetAllAsync returnValue=0
~~~
