using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection.Metadata;

namespace _1._Search_Product_with_Implicit_Wait
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("https://practice.bpbonline.com/");
        }

        [Test]
        public void Test1()
        {
            var searchField = driver.FindElement(By.XPath("//input[@name='keywords']"));
            searchField.SendKeys("Keyboard" + "\n");

            try
            {
                Assert.That(driver.FindElement(By.XPath("//td//a[text()='Microsoft Internet Keyboard PS/2']")).Displayed, Is.True, "Product Not Found");

                driver.FindElement(By.XPath("//span[text()='Buy Now']")).Click();

                Assert.That(driver.FindElement(By.XPath("//strong[text()='Microsoft Internet Keyboard PS/2']")).Displayed, Is.True, "Product Not Found");

                Console.WriteLine("Product Found");
            }

            catch(Exception ex)
            {
                Assert.Fail("Unexpected Error: " + ex.Message);
            }
        }
        [Test]
        public void Test2()
        {
            driver.FindElement(By.XPath("//input[@name='keywords']")).SendKeys("wtf" + "\n");
           
            try
            {                
                driver.FindElement(By.XPath("//span[text()='Buy Now']")).Click();
                Console.WriteLine("Product Found - Test Failed");
                Assert.Fail("Product Found");
            }

            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Product Not Found as expected.");
                Assert.Pass("Product Not Found: " + ex.Message);
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