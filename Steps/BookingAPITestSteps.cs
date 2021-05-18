using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using Com.Test.TimADay.APIs;

namespace Com.Test.TimADay.Steps
{
    [Binding]
    public class BookingAPITestSteps
    {
     
        private BaseAPITests _baseAPI;
        private string bookingRef = "";
        private readonly ScenarioContext context;

        public BookingAPITestSteps(ScenarioContext injectedContext)
        {
            this.context = injectedContext;
         }

        [BeforeFeature]
        public void beforeFeature() 
        {
            BaseAPITests.SetBaseUriAndAuth();
        }

        [BeforeScenario]
        public void beforeScenario()
        {
            BaseAPITests.SetBaseUriAndAuth();
            
        }

        [Given(@"I can interact with the booking api")]
        public void GivenICanInteractWithTheBookingApi()
        {
            BaseAPITests.Ping();
        }

        [When(@"I create the following booking")]
        public void WhenICreateTheFollowingBooking(Table table)
        {
            var row = table.Rows[0];
                JObject response = BaseAPITests.createBooking(
                    row["firstname"],
                    row["lastname"],
                    row["totalprice"],
                    row["depositpaid"],
                    row["checkin"],
                    row["checkout"],
                    row["additionalneeds"]
                    );
                this.bookingRef = response.GetValue("bookingref").ToString();
        }

        [When(@"I update the booking with")]
        public void WhenIUpdateTheBookingWith(Table table)
        {
            var row = table.Rows[0];
            BaseAPITests.updateBookingFirstname(this.bookingRef, row["firstrname"]);
        }

        [When(@"I delete the booking")]
        public void WhenIDeleteTheBooking()
        {
            BaseAPITests.deleteBooking(this.bookingRef);
        }

        [Then(@"I see my booking in response")]
        public void ThenISeeMyBookingInResponse(Table table)
        {
            JObject response = BaseAPITests.GetResponseBody();
          
        }

        [Then(@"my booking is not present")]
        public void ThenMyBookingIsNotPresent()
        {
            JObject response = BaseAPITests.getBooking(this.bookingRef);
           string ref = response.GetValue("bookingref").ToString();
            Assert.That(ref, Is.EqualTo(this.bookingRef));
        }


    }
}
