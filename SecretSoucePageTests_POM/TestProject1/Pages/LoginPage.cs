using OpenQA.Selenium;


namespace SeleniumWebDriverPOM.Pages
{
    public class LoginPage : BasePage
    {

        public LoginPage(IWebDriver driver) : base(driver) {

        }

        private readonly By inputField = By.CssSelector("[name=user-name]");
        private readonly By passwordField = By.CssSelector("[name=password]");
        private readonly By loginButton = By.CssSelector("[name=login-button]");
        private readonly By errorMsg = By.CssSelector("[data-test=error]");


        public void Username(string username)
        {
            Type(inputField, username);
        }

        public void Password(string password)
        {
            Type(passwordField, password);
        }

        public void LoginButton()
        {
            Click(loginButton);
        }

        public string GetErrorMessage()
        {
            return GetText(errorMsg);
        }



    }
}
