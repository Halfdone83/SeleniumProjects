using OpenQA.Selenium;

namespace TheFoodyWebApp.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        
            
        }
        
        public IWebElement Username => driver.FindElement(By.XPath("//input[@name='Username']"));

        public IWebElement Password => driver.FindElement(By.XPath("//input[@name='Password']"));

        public IWebElement SubmitButton => driver.FindElement(By.XPath("//button[@type='submit']"));


        public void Login(string username, string password)
        { 
            Username.SendKeys(username);
            Password.SendKeys(password);
            SubmitButton.Click();        
        }
        

    }
}
