using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using Com.Test.TimADay.Pages;
using NUnit.Framework;

using Com.Test.TimADay.Drivers;
using Com.Test.TimADay.Configuration;

namespace Com.Test.TimADay.Steps
{
    [Binding]
    public class OnlineStoreUITestSteps
    {
        String test_url = "http://automationpractice.com/";
        private TesterConfig config;
        String lastOrderRef = null;
        private IWebDriver _driver;

        private readonly ScenarioContext context;

        public OnlineStoreUITestSteps(ScenarioContext injectedContext)
        {
            this.context = injectedContext;
            this.config = new TesterConfig();
         }

        [BeforeScenario]
        public void startSelenium() 
        {
            _driver = new ChromeDriver();
        }

        [AfterScenario]
        public void stopSelenium()
        {
            _driver.Quit();
        }


        [Given(@"I Login as ""(.*)""")]
        public void GivenILoginAs(string p0)
        {
            _driver.Url = test_url + "/index.php?controller=authentication&back=my-account";
            LoginPage loginPage = new LoginPage(_driver);
            var tester = this.config.Get(p0);
            loginPage.Login(tester[0], tester[1]);
        }

        [Given(@"I am viewing the T-Shirts tab")]
        public void GivenIAmViewingTheT_ShirtsTab()
        {
            _driver.Url = test_url + "/index.php?id_product=1&controller=product";
        }
        
        [When(@"I add to my basket from the T-Shirts tab")]
        public void WhenIAddToMyBasket(Table table)
        {
            _driver.Url = test_url + "/index.php?id_category=5&controller=category";
            TShirtTab tshirtTab = new TShirtTab(_driver);
            foreach(var row in table.Rows) {
              TShirtProductPage productPage = tshirtTab.OpenProduct(row["Item Name"]);
              productPage.SetProductQuantity(row["Quantity"]);
              productPage.SetProductColour(row["Colour"]);
              productPage.AddToCart();
            }  
        }

        [When(@"I complete checkout")]
        public void WhenICompleteCheckout()
        {
            _driver.Url = test_url + "/index.php?controller=order&step=1";
            CheckoutPage checkout = new CheckoutPage(_driver);
            checkout.CompleteCheckoutSimple(true);
            this.lastOrderRef = checkout.GetOrderRef();
        }

        [Then(@"I should see in last order history")]
        public void ThenIShouldSeeInLastOrderHistory()
        {
            _driver.Url = test_url + "/index.php?controller=history";

            OrderHistoryPage orderHistoryPage = new OrderHistoryPage(_driver);
        
            Assert.IsTrue(
                this.lastOrderRef != null && orderHistoryPage.IsOrderPresent(this.lastOrderRef),
                $"order reference not found, Expected: {this.lastOrderRef}"
            );
    
        }

        //since no environment set up I set the default 
        [Given(@"my account firstname is ""(.*)""")]
        public void GivenMyAccountIs(string value)
        {
            _driver.Url = test_url + "/index.php?controller=identity";
            PDPage pdPage = new PDPage(_driver);
            var tester = this.config.Get("Customer");
            pdPage.UpdateFirstNameOnly(value, tester[1]);
            _driver.Url = test_url + "/index.php?controller=identity";
            var actual =  pdPage.GetFirstName();
            if (actual != value)
            {
                throw new Exception("Precondtion Error: Unable to set firstname default");
            }
        }

        [When(@"I Update my account firstname to ""(.*)""")]
        public void WhenIUpdateMyAccountTo(string value)
        {
            _driver.Url = test_url + "/index.php?controller=identity";
            PDPage pdPage = new PDPage(_driver);
            var tester = this.config.Get("Customer");
            pdPage.UpdateFirstNameOnly(value, tester[1]);
        }

        [Then(@"my account firstname should be ""(.*)""")]
        public void ThenMyAccountShouldBe(string value)
        {
            _driver.Url = test_url + "/index.php?controller=identity";
            PDPage pdPage = new PDPage(_driver);
            var actual = pdPage.GetFirstName();
            Assert.That(value, Is.EqualTo(actual), 
                "Firstname does not match:" +
                $"Expected: {value} but got {actual}");
        }
    }
}
