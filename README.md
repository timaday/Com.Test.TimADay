# Com.Test.TimADay
C# = Specflow, Selenium, Restsharp, Nunit

### Task 1
- Order T-Shirt and Verify in Order History
- Change firstname

#### Overview
tags: web
These tests use selenium to conduct the test and utilise the page object model in the process. 
Since we are using spec flow I have added the setup and teardown of the selenium chrome driver in the hooks.
With more time I would create a class to manage the driver and pass it to the context class for better maintanability.
This runs well within Visual Studio, unfortunately I ran out of time to sort out reporting via the commandline - Hope I have shown you enough

### Task 2
- Create Booking
- Update Booking
- Delete Booking
Restsharp was used to create the api class to drive the actions. I would build a configuration class which could be passed to is for long term maintanability.
Steps have been simplified to keep the tests readable and effiecent.
