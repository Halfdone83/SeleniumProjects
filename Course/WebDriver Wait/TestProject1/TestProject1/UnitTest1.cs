using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics.Tracing;

namespace TestProject1
{

    

    public class Tests
    {

        IWebDriver driver;

        [SetUp]
        public void Setup()
        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/dynamic.html");
        }

        [Test]
        public void AddBoxWithoutWaitsFails()
        {
           
            var addButton = driver.FindElement(By.Id("adder"));
            addButton.Click();

            
            IWebElement redBox = driver.FindElement(By.XPath("//div[@class='redbox']"));


            Assert.IsTrue(redBox.Displayed);

        }

        [Test]
        public void RevealInputWithoutWaitsFail()
        {

            var revealButton = driver.FindElement(By.Id("reveal"));
            revealButton.Click();


            IWebElement revealedField = driver.FindElement(By.Id("revealed"));


           Assert.That(revealedField.Displayed, Is.True);

        }


        [Test]
        public void AddBoxWithThreadSleep()
        {

            var addButton = driver.FindElement(By.Id("adder"));
            addButton.Click();

            Thread.Sleep(5000);
            IWebElement redBox = driver.FindElement(By.XPath("//div[@class='redbox']"));


            Assert.IsTrue(redBox.Displayed);

        }

        [Test]
        public void RevealInputWithThreadSleepl()
        {

            var revealButton = driver.FindElement(By.Id("reveal"));
            revealButton.Click();


            Thread.Sleep(5000);
            IWebElement revealedField = driver.FindElement(By.Id("revealed"));


            Assert.That(revealedField.Displayed, Is.True);

        }

        [Test]
        public void AddBoxWithImplicitWait()
        {

            var addButton = driver.FindElement(By.Id("adder"));
            addButton.Click();

            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement redBox = driver.FindElement(By.XPath("//div[@class='redbox']"));


            Assert.IsTrue(redBox.Displayed);

        }

        [Test]
        public void RevealInputWithImplicitWait()
        {

            var revealButton = driver.FindElement(By.Id("reveal"));
            revealButton.Click();


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement revealedField = driver.FindElement(By.Id("revealed"));


            Assert.That(revealedField.Displayed, Is.True);

        }

        [Test]
        public void AddBoxWithExplicitWait()
        {

            var addButton = driver.FindElement(By.Id("adder"));
            addButton.Click();

           

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.XPath("//div[@class='redbox']")).Displayed);

            IWebElement redBox = driver.FindElement(By.XPath("//div[@class='redbox']"));


            Assert.IsTrue(redBox.Displayed);

        }


        [Test]

        public void RevealInputWithExplicitWaits()
        { 
            IWebElement revealedField = driver.FindElement(By.Id("revealed"));

            var revealButton = driver.FindElement(By.Id("reveal"));

            revealButton.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(driver => revealedField.Displayed);

            Assert.That(revealedField.Displayed, Is.True);

            revealedField.SendKeys("Wazaaa");

            Assert.That(revealedField.GetAttribute("value"), Is.EqualTo("Wazaaa"));
        
        
        }


        [Test]

        public void AddBoxWithFluentWait()
        {
            var addButton = driver.FindElement(By.Id("adder"));
            addButton.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

           IWebElement redbox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='redbox']")));

            Assert.IsTrue(redbox.Displayed);


        }

        [Test]
        public void RevealInputWithFluentWait()
        {
            var revealButton = driver.FindElement(By.Id("reveal"));

            revealButton.Click();

            IWebElement revealedField = driver.FindElement(By.Id("revealed"));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            IWebElement revealed = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("revealed")));

            Assert.IsTrue(revealed.Displayed);

            revealedField.SendKeys("Wazzaaa");

            Assert.That(revealedField.GetAttribute("value"), Is.EqualTo("Wazzaaa"));

        }

        [Test]

        public void RevealInputWithCustomFluentWait()
        {

            IWebElement revealedField = driver.FindElement(By.Id("revealed"));
            driver.FindElement(By.Id("reveal")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            {
                wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            };
                wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));

            wait.Until(d =>
            {
                revealedField.SendKeys("Wazzaaa");
                return true;
            });

            Assert.That(revealedField.TagName, Is.EqualTo("input"));
            Assert.That(revealedField.GetAttribute("value"), Is.EqualTo("Wazzaaa"));


            



        }




        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
            driver.Quit();
        }
    }
}