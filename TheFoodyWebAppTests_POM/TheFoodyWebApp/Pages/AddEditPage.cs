using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TheFoodyWebApp.Pages
{
    public class AddEditPage : BasePage
    {
        public AddEditPage(IWebDriver driver) : base(driver)
        {
            
        }
        
        public IWebElement FoodName => driver.FindElement(By.XPath("//input[@name='Name']"));

        public IWebElement FoodDescription => driver.FindElement(By.XPath("//input[@name='Description']"));

        public IWebElement SubmitButton => driver.FindElement(By.XPath("//button[@type='submit']"));

        public IWebElement ErrorMessage => driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']//li"));

        

        public void EnterFoodName(string name)
        {
            FoodName.SendKeys(name);
        }

        public void EnterFoodDescription(string description)
        {
            FoodDescription.SendKeys(description);
        }

        public void ClickSubmitButton()
        {
            SubmitButton.Click();
        }

        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }

        public string LastElementTitle()
        {
            return driver.FindElement(By.XPath("(//div[@class='row gx-5 align-items-center'])[last()]//h2")).Text;
        }
               

        public void EditFoodName(string name)
        {
            FoodName.Clear();
            FoodName.SendKeys(name);
            SubmitButton.Click();
        }

        public string FoodTitle()
        {
            return driver.FindElement(By.XPath("(//div[@class='row gx-5 align-items-center'])[last()]//h2")).Text;
        }

        public void AddNewFood(string title, string description)
        {
            EnterFoodName(title);
            EnterFoodDescription(description);
            ClickSubmitButton();
        }

        public void WaitForUrlToBe(string expectedUrl, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d => d.Url == expectedUrl);
        }


    }
}
