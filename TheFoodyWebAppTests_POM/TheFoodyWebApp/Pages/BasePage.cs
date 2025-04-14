using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TheFoodyWebApp.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;

        protected WebDriverWait wait;

        protected Actions actions;

        protected string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85/";
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            actions = new Actions(driver);
        }

        public IWebElement HomeButton => driver.FindElement(By.XPath("//a[text()='FOODY']"));

        public IWebElement LoginButton => driver.FindElement(By.XPath("//a[text()='Log In']"));

        public IWebElement RegisterButton => driver.FindElement(By.XPath("//a[text()='Sign Up']"));

        public IWebElement AddFoodButton => driver.FindElement(By.XPath("//a[text()='Add Food']"));

        public IWebElement LogOutButton => driver.FindElement(By.XPath("//a[text()='Logout']"));



        public void ClickAddButton()
        {
            AddFoodButton.Click();
        }

        public void ClickHomeButton()
        {
            HomeButton.Click();
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public void ClickRegisterButton()
        {
            RegisterButton.Click();
        }
        public void ClickLogOutButton()
        {
            LogOutButton.Click();
        }



    }
}
