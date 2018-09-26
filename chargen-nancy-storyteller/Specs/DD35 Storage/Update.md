# Update

-> id = 7f0bceb3-b75d-410a-80c6-e3b0aa3f8a3d
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-09-26T21:30:07.5442826Z
-> tags = 

[DD35Storage]
|> GetAllAsync returnValue=0
|> InsertNewAsync name=test
|> GetByIdAsync id=1
|> CheckName returnValue=test
|> UpdateAsync id=1, name=updated
|> GetByIdAsync id=1
|> CheckName returnValue=updated
|> DeleteAsync id=1
~~~
