using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V131.Storage;
using OpenQA.Selenium.Support.UI;


namespace SeleniumWebDriverPOM.Pages
{
    public class BasePage
    {

        protected IWebDriver driver;

        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        protected IWebElement FindElement(By locator)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        protected IReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            return driver.FindElements(locator);
        }

        protected void Type(By locator, string text)
        {
            FindElement(locator).SendKeys(text);
        }

        protected void Click(By locator)
        {
            FindElement(locator).Click();
        }

        protected string GetText(By locator)
        {
            return FindElement(locator).Text;
        }


    }
}
