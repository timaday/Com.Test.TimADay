using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Com.Test.TimADay.Pages
{
    class TShirtTab : PageObject
    {
        private IWebDriver driver;
        public TShirtTab(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public TShirtProductPage OpenProduct(String productName)
        {
            this.driver.FindElement(
                By.XPath($"//div[contains(@class,'product-container')]//a[contains(@class, 'product-name') and normalize-space(text())='{productName}']")
                ).Click();
            return new TShirtProductPage(driver);
        }
    }
}
