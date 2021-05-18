using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Com.Test.TimADay.Pages
{
    class TShirtProductPage : PageObject
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "quantity_wanted")]
        private IWebElement Quantity { get; set; }

        [FindsBy(How = How.Id, Using = "group_1")]
        private IWebElement ProductSize { get; set; }

        [FindsBy(How = How.CssSelector, Using = "p#add_to_cart > button[name='Submit']")]
        private IWebElement AddToCartButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div#layer_cart div.layer_cart_product h2")]
        private IWebElement CartConfirmationTitle { get; set; }

        public TShirtProductPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void SetProductQuantity(String quantity) 
        {
            this.Quantity.SendKeys(quantity);
        }

        public void SetProductSize(String size)
        {
            var selectElement = new SelectElement(this.ProductSize);
            selectElement.SelectByText(size);
        }

        public void SetProductColour(string colour) 
        {
            driver.FindElement(
                By.XPath($"//ul[@id='color_to_pick_list']//li/a[@name='{colour}']")
                ).Click();
        }

        public void AddToCart() 
        {
            this.AddToCartButton.Click();
        }

        public bool CheckCartOnfirmationMessage() 
        {
            string confirmationMessage = this.CartConfirmationTitle.Text;
            return confirmationMessage.Contains("Product successfully added to your shopping cart");
        }
    }
}
