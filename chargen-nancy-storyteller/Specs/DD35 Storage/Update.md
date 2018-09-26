# Update

-> id = 7f0bceb3-b75d-410a-80c6-e3b0aa3f8a3d
-> lifecycle = Acceptance
-> max-retries = 0
-> last-updated = 2018-09-26T18:48:17.2629815Z
-> tags = 

[DD35Storage]
|> GetAllAsync returnValue=0
|> InsertNewAsync name=test
|> GetByIdAsync id=1
|> CheckName returnValue=test
|> UpdateAsync id=1, name=updated
|> GetByIdAsync id=1
|> CheckName returnValue=updated
~~~
