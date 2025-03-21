using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace SeleniumWebDriverDemo


{
    public class Wikipedia
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Quality_Assurance_Search()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.wikipedia.org/");

            Console.WriteLine("Page name: " + driver.Title);

            var search = driver.FindElement(By.Name("search"));

            search.SendKeys("Quality Assurance" + Keys.Enter );

            Console.WriteLine("Page QA name: " + driver.Title);

            driver.Quit();
        }


    





       
    }
}