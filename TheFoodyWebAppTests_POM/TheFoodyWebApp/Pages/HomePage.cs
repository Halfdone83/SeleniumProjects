using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFoodyWebApp.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
                                    
        }

        public IWebElement SearchField => driver.FindElement(By.XPath("//input[@type='search']"));

        public IWebElement SearchButton => driver.FindElement(By.XPath("//button[@type='submit']"));

        public IWebElement LastFoodEditButton => driver.FindElement(By.XPath("(//div[@class='row gx-5 align-items-center'])[last()]//a[text()='Edit']"));

        public IWebElement LastFoodDeleteButton => driver.FindElement(By.XPath("(//div[@class='row gx-5 align-items-center'])[last()]//a[text()='Delete']"));

        public void SearchForFood(string foodName)
        {
            SearchField.SendKeys(foodName);
            SearchButton.Click();
        }

        public List<IWebElement> GetFoodList()
        {
            return driver.FindElements(By.XPath("//div[@class='row gx-5 align-items-center']")).ToList();
        }

        public string LastElementTitle()
        {                      
            return driver.FindElement(By.XPath("//div[@class='p-5']//h2")).Text;            
        }


        public void LastAddedFoodEditButtonClick()
        {
            actions.MoveToElement(LastFoodEditButton).Click().Perform();

        }

        public void LastAddedFoodDeleteButtonClick()
        {
            actions.MoveToElement(LastFoodDeleteButton).Click().Perform();
        }

        public List<string> FoodListTitles()
        {
            return driver.FindElements(By.XPath("//div[@class='row gx-5 align-items-center']//h2")).Select(x => x.Text).ToList();
        }

        public string ErrorMessage()
        {
            return driver.FindElement(By.XPath("//h2[@class='display-4']")).Text;
        }
    }
}
