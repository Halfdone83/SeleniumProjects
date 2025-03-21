using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


namespace _2._Student_RegistryApp.PageTests
{
    public class BaseTests
    {
        protected IWebDriver driver;

        [OneTimeSetUp]    
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Dispose();
            driver.Quit();
        }
       


    }
}
