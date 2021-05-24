# Com.Test.TimADay
**C#** = Specflow, Selenium, Restsharp, Nunit

Specflow test can be run via the command line, also the solutions requires selenium to be running on the machine.

https://www.selenium.dev/downloads/

ChromeDriver.exe has been added to the repo for simplicity.

### Task 1
- Order T-Shirt and Verify in Order History
- Change firstname

#### Overview
tags: web
These tests use selenium to conduct the test and utilise the page object model in the process. 
Since we are using spec flow I have added the setup and teardown of the selenium chrome driver in the hooks.
With more time I would create a class to manage the driver and pass it to the context class for better maintanability.
This runs well within Visual Studio, next I would focus on reporting by setting up html report and integrate reporting with test management tool.

### Task 2
- Create Booking
- Update Booking
- Delete Booking

Restsharp was used to create the api class to drive the actions. I would build a configuration class which could be passed to is for long term maintanability.
Steps have been simplified to keep the tests readable and effiecent. I added the health check as a given step to ping the api before each test, can be added as a background depending on your flavor.
