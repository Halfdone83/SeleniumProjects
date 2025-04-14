using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _1._Sum_Two_Numbers
{
    public class SumNumTestsWhitoutPom
    {
        IWebDriver driver;
        private SumNumberPage SumPage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            SumPage = new SumNumberPage(driver);

            SumPage.OpenPage();
        }


        [Test]
        public void Test_AddTwoNumbers_ValidInput()
        {           
            SumPage.SumNumbers("10", "20");

            Assert.That(SumPage.Result.Text, Is.EqualTo("Sum: " + "30"));

        }

        [Test]
        public void Test_AddTwoNumbers_InvalidInput()
        {                                   
            Assert.That(SumPage.SumNumbers("A", "10"), Is.EqualTo("Sum: " + "invalid input"));
        }

        [Test]
        public void Test_Reset_Button()
        {

            SumPage.SumNumbers("10", "20");

            SumPage.Reset();

            Assert.That(SumPage.Result.Text, Is.EqualTo(""));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }   
    }
}
