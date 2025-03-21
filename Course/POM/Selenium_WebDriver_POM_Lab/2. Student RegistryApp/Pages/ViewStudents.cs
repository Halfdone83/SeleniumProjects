using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace _2._Student_RegistryApp.Pages
{
    public class ViewStudents : BasePage
    {
        public ViewStudents(IWebDriver driver) : base(driver)
        {

        }

        public override string PageUrl => "http://localhost:8080/students";

        public ReadOnlyCollection<IWebElement> Students => driver.FindElements(By.XPath("//ul//li"));

        public string[] GetStudentsList()
        {
            
            var studentsList = Students.Select(x => x.Text).ToArray();
            return studentsList;
        }

    }
}
