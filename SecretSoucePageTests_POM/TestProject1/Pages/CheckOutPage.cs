using OpenQA.Selenium;

namespace SeleniumWebDriverPOM.Pages
{
    public class CheckOutPage : BasePage
    {

        public CheckOutPage(IWebDriver driver) : base(driver)
        {

        }

        private readonly By firstnameField = By.CssSelector("[data-test=firstName]");
        private readonly By lastnameField = By.CssSelector("[data-test=lastName]");
        private readonly By postalcodeField = By.CssSelector("[data-test=postalCode]");
        private readonly By continueButton = By.CssSelector("[name=continue]");
        private readonly By finishButton = By.CssSelector("[name=finish]");
        private readonly By checkoutTitle = By.CssSelector("[data-test=complete-header]");



        public void EnterFirstName(string firstname)
        {
            Type(firstnameField, firstname);
        }

        public void EnterLastName(string lastname)
        {
            Type(lastnameField, lastname);
        }

        public void EnterPostalCode(string postalcode)
        {
            Type(postalcodeField, postalcode);
        }

        public void ClickContinue()
        {
            Click(continueButton);
        }

        public void ClickFinish()
        {
            Click(finishButton);
        }

        public bool IsPageLoaded()
        {
            return driver.Url.Contains("checkout-step-two.html") || driver.Url.Contains("checkout-step-one.html");
        }

        public bool IsCheckoutComplete()
        {
            return GetText(checkoutTitle).Contains("Thank you for your order!");
        }

        public void FillDetails()
        {
            EnterFirstName("John");
            EnterLastName("Doe");
            EnterPostalCode("12345");
            ClickContinue();
            
        }


    }
}
