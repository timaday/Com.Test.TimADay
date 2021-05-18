using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Com.Test.TimADay.Pages
{
    class PageObject
    {
        private IWebDriver driver;

        public PageObject(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public String GetPageTitle()
        {
            return driver.Title;
        }
    }
}
