using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _4._Working_with_Alerts
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");


        }

        [Test]
        public void Test1()
        {
            var alertButton1 = driver.FindElement(By.XPath("//button[text()='Click for JS Alert']"));
            alertButton1.Click();

            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            var result = driver.FindElement(By.Id("result")).Text;

            Assert.That(result, Is.EqualTo("You successfully clicked an alert"), "Result message is not as expected");
        }

        [Test]

        public void Test2Accept()
        {
            var alertButton2 = driver.FindElement(By.XPath("//button[text()='Click for JS Confirm']"));
            alertButton2.Click();

            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            var result = driver.FindElement(By.Id("result")).Text;
            Assert.That(result, Is.EqualTo("You clicked: Ok"), "Result message is not as expected");
        }

        [Test]

        public void Test2Dismiss() 
        {         
            var alertButton2 = driver.FindElement(By.XPath("//button[text()='Click for JS Confirm']"));
            alertButton2.Click();

            IAlert alert = driver.SwitchTo().Alert();
            alert.Dismiss();

            var result = driver.FindElement(By.Id("result")).Text;
            Assert.That(result, Is.EqualTo("You clicked: Cancel"), "Result message is not as expected");
        }

        [Test]
        public void Test3Accept()
        {
            var alertButton3 = driver.FindElement(By.XPath("//button[text()='Click for JS Prompt']"));
            alertButton3.Click();

            IAlert alert = driver.SwitchTo().Alert();
            string textToWrite = "WTF";
            alert.SendKeys(textToWrite);
            alert.Accept();

            var result = driver.FindElement(By.Id("result")).Text;
            Assert.That(result, Is.EqualTo("You entered: " + textToWrite), "Result message is not as expected");
        }

        [Test]
        public void Test3Dismiss()
        {
            var alertButton3 = driver.FindElement(By.XPath("//button[text()='Click for JS Prompt']"));
            alertButton3.Click();

            IAlert alert = driver.SwitchTo().Alert();
            string input = "WTF";
            alert.SendKeys(input);
            alert.Dismiss();

            var result = driver.FindElement(By.Id("result")).Text;
            Assert.That(result, Is.EqualTo("You entered: null"), "Result message is not as expected");


        }



        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}