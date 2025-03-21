using OpenQA.Selenium;

namespace _2._Student_RegistryApp.Pages
{
    public  class AddStudent : BasePage
    {
        public  AddStudent(IWebDriver driver) : base(driver)
        {


        }

        public override string PageUrl => "http://localhost:8080/add-student";

        public IWebElement ErrorMessage => driver.FindElement(By.XPath("//div[text()=\"Cannot add student. Name and email fields are required!\"]"));
        public IWebElement Name => driver.FindElement(By.XPath("//input[@id='name']"));
        public IWebElement Email => driver.FindElement(By.XPath("//input[@id='email']"));
        public IWebElement AddButton => driver.FindElement(By.XPath("//button[text()='Add']"));

        public void AddStudents(string name, string email)
        {
            Name.SendKeys(name);
            Email.SendKeys(email);
            AddButton.Click();
        }

        public string ErrorMessageText()
        {
            return ErrorMessage.Text;
        }

    }
}
