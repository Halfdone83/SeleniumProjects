using OpenQA.Selenium;

namespace _2._Student_RegistryApp.Pages

{
    public class HomePage : BasePage    
    {

        public HomePage(IWebDriver driver) : base(driver)
        {

        }

        public override string PageUrl => "http://localhost:8080/";

        public IWebElement StudentsCount => driver.FindElement(By.XPath("//p//b"));

        public int GetStudentsCount()
        {
            string count = StudentsCount.Text;
            return int.Parse(count);
        }

    }
}
