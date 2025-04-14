using OpenQA.Selenium;

namespace _1._Sum_Two_Numbers
{
    internal class SumNumberPage
    {
        private IWebDriver driver;

        public SumNumberPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        const string PageUrl = "file:///C:/Users/Halfdone/Desktop/FrontEndQA/Front-End%20Automation%20Testing/07.Selenium%20WebDriver%20POM/Resources/Sum-Num/sum-num.html";

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }

        public IWebElement Number1 => driver.FindElement(By.XPath("//input[@id='number1']"));
        public IWebElement Number2 => driver.FindElement(By.XPath("//input[@id='number2']"));
        public IWebElement CalcButton => driver.FindElement(By.XPath("//input[@id='calcButton']"));
        public IWebElement ResetButton => driver.FindElement(By.XPath("//input[@id='resetButton']"));
        public IWebElement Result => driver.FindElement(By.XPath("//div[@id='result']"));
        public string SumNumbers(string number1, string number2)
        {
            Number1.SendKeys(number1);
            Number2.SendKeys(number2);
            CalcButton.Click();

            string result = Result.Text;

            return result;

        }

        public void Reset()
        {
            
            ResetButton.Click();
        }
               



    }
}
