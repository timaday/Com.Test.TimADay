using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Com.Test.TimADay.Pages
{
    class LoginPage : PageObject
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "passwd")]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        private IWebElement Submit { get; set; }
        public LoginPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void Login(String username, String password) 
        {
            this.UserName.SendKeys(username);
            this.Password.SendKeys(password);
            this.Submit.Submit();
        }
    }
}
