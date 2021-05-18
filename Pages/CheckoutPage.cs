using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Com.Test.TimADay.Pages
{
    class CheckoutPage : PageObject
    {
        private IWebDriver driver;

        private IJavaScriptExecutor js;

        [FindsBy(How = How.XPath, Using = "//a[@title='Proceed to checkout']")]
        private IWebElement ProceedToCheckoutButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@name='processAddress']")]
        private IWebElement ProcessAddressButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@name='processCarrier']")]
        private IWebElement ProcessCarrierButton { get; set; }

        [FindsBy(How = How.Id, Using = "cgv")]
        private IWebElement TermsCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Pay by bank wire' and contains(@class,'bankwire')]")]
        private IWebElement PayByWirebutton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='I confirm my order']/parent::button")]
        private IWebElement ConfirmPaymentButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'box')]")]
        private IWebElement OrderPageText { get; set; }

        public CheckoutPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            this.js = (IJavaScriptExecutor)this.driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void ProceedToCheckout()
        {
            var script = "arguments[0].scrollIntoView(true);";
            this.js.ExecuteScript(script, this.ProceedToCheckoutButton);
            this.ProceedToCheckoutButton.Click();
        }

        public void ProcessAddress()
        {
            var script = "arguments[0].scrollIntoView(true);";
            this.js.ExecuteScript(script, this.ProcessAddressButton);
            this.ProcessAddressButton.Click();
        }

        public void ProcessCarrier()
        {
            var script = "arguments[0].scrollIntoView(true);";
            this.js.ExecuteScript(script, this.ProcessCarrierButton);
            this.ProcessCarrierButton.Click();
        }

        public void SetTerms(Boolean check)
        {
            var script = "arguments[0].scrollIntoView(true);";
            this.js.ExecuteScript(script, this.TermsCheckbox);
            if (this.TermsCheckbox.Selected != check)
            {
                this.TermsCheckbox.Click();
            }
        }

        public void PayByBankWire()
        {
            var script = "arguments[0].scrollIntoView(true);";
            this.js.ExecuteScript(script, this.PayByWirebutton);
            this.PayByWirebutton.Click();
        }

        public void ConfirmOrder()
        {
            var script = "arguments[0].scrollIntoView(true);";
            this.js.ExecuteScript(script, this.ConfirmPaymentButton);
            this.ConfirmPaymentButton.Click();
        }

        public void CompleteCheckoutSimple(bool terms)
        {
            this.ProcessAddress();
            this.SetTerms(terms);
            this.ProcessCarrier();
            this.PayByBankWire();
            this.ConfirmOrder();
        }

        public String GetOrderRef() 
        {
            string text = this.OrderPageText.Text;
            int start = text.IndexOf("your order reference ") + 21;
            return text.Substring(start, 10).Trim();
        }

    }
}

