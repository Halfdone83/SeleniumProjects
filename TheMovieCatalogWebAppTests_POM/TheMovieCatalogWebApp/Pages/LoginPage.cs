using OpenQA.Selenium;

namespace TheMovieCatalogWebApp.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        { 

        }
        private IWebElement LoginHereButton => driver.FindElement(By.XPath("//a[text()='LOGIN HERE']"));
        private IWebElement EmailInput => driver.FindElement(By.Name("Email"));
        private IWebElement PasswordInput => driver.FindElement(By.Name("Password"));
        private IWebElement SubmitButton => driver.FindElement(By.XPath("//button[@type='submit']"));

        public void Login(string email, string password)
        {
            actions.MoveToElement(LoginHereButton).Click().Perform();
            EmailInput.SendKeys(email);
            PasswordInput.SendKeys(password);
            SubmitButton.Click();
        }
    }
}