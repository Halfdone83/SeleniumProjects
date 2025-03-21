using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _2._Student_RegistryApp.Pages
{
    public class BasePage
    {

        protected readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        public virtual string PageUrl { get;}

        public IWebElement HomeLink => driver.FindElement(By.XPath("//a[text()='Home']"));
        public IWebElement ViewStudentsLink => driver.FindElement(By.XPath("//a[text()='View Students']"));
        public IWebElement AddStudentLink => driver.FindElement(By.XPath("//a[text()='Add Student']"));
        public IWebElement PageHeading => driver.FindElement(By.XPath("//h1"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }

        public bool IsPageLoaded()
        {
            Console.WriteLine("Expected: " + PageUrl);
            Console.WriteLine("Actual: " + driver.Url);

            return driver.Url == PageUrl;
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public string GetPageHeading()
        {
            return PageHeading.Text;
        }



        

    }
}