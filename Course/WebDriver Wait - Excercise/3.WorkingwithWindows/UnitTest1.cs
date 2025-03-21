using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
namespace _3.WorkingwithWindows
{
    public class Tests
    {

        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");


        }

        [Test]
        public void Test1()
        {
            driver.FindElement(By.XPath("//a[@href='/windows/new']")).Click();

            ReadOnlyCollection<string> windowCollection = driver.WindowHandles;

            Assert.That(windowCollection.Count, Is.EqualTo(2));

            driver.SwitchTo().Window(windowCollection[1]);

            var newWindow = driver.FindElement(By.TagName("h3"));

            Assert.That(newWindow.Text, Is.EqualTo("New Window"));

            driver.SwitchTo().Window(windowCollection[0]);

            var originalWindow = driver.FindElement(By.TagName("h3"));

            Assert.That(originalWindow.Text, Is.EqualTo("Opening a new window"));
        
        }

        [Test]

        public void Test2()
        {

            driver.FindElement(By.XPath("//a[@href='/windows/new']")).Click();

            ReadOnlyCollection<string> tabCollection = driver.WindowHandles;

            Assert.That(tabCollection.Count, Is.EqualTo(2));

            driver.SwitchTo().Window(tabCollection[1]);

            driver.Close();

            try
            {
                driver.SwitchTo().Window(tabCollection[1]);
                Assert.Fail("Tab is still open");
            }
            catch(NoSuchWindowException ex)
            {
                Assert.Pass("Tab is closed: " + ex.Message);
            }
            finally
            {
                driver.SwitchTo().Window(tabCollection[0]);
            }

        }






        [TearDown]
        public void TearDown()
        {
        driver.Quit();
        driver.Dispose();
        
        }

    }

}