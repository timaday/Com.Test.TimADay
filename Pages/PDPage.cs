using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Com.Test.TimADay.Pages
{
    class PDPage : PageObject
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "firstname")]
        private IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "old_passwd")]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.Name, Using = "submitIdentity")]
        private IWebElement Submit { get; set; }
        public PDPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }
        
        public void UpdateFirstNameOnly(String firstname, String password) 
        {
            this.FirstName.Clear();
            this.FirstName.SendKeys(firstname);
            this.Password.SendKeys(password);
            this.Submit.Submit();
        }

        public string GetFirstName()
        {
            return this.FirstName.GetAttribute("value");
        }
    }
}
