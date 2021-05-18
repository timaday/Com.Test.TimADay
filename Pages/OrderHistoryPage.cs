using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Com.Test.TimADay.Pages
{
    class OrderHistoryPage : PageObject
    {
        private IWebDriver driver;
        public OrderHistoryPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public Boolean IsOrderPresent(String orderRef, string price = null)
        {
            var order = driver.FindElement(
                By.XPath($"//table[@id='order-list']//td/a[normalize-space(text())='{orderRef}']")
                );
            
            // check if expected price matches order record - providing price is given and order exists
            if (order.Displayed && price != null) {
                return driver.FindElement(
                By.XPath($"//table[@id='order-list']//td/a[normalize-space(text())='{orderRef}']/ancestor::tr/td//span[@class='price' and normalize-space(text())='{price}']")
                ).Displayed;
            }

            return order.Displayed;

        }
    }
}
