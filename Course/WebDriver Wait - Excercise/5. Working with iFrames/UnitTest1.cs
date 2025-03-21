using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace _5._Working_with_iFrames
{
    public class Tests
    {
        IWebDriver driver;
        WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("https://codepen.io/pervillalva/full/abPoNLd");

            wait = new WebDriverWait(driver,TimeSpan.FromSeconds(5));
        }

        [Test]
        public void TestByIndex()
        {
            //driver.SwitchTo().Frame("result");

            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("result")));

            var dropDownButton = driver.FindElement(By.XPath("//button[@class='dropbtn']"));
            dropDownButton.Click();

            var dropDownOptions = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='dropdown-content']//a")));

            foreach (var option in dropDownOptions)
            {
                Console.WriteLine(option.Text);
                Assert.That(option.Displayed, Is.True, "Text not displayed" );
            }

            driver.SwitchTo().DefaultContent();


        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}