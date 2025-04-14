using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace _2.SearchProductWithExplicitWait
{
    public class Tests
    {
        IWebDriver driver;
        

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("http://practice.bpbonline.com/");

           

        }

        [Test]
        public void Test1()
        {
         
            driver.FindElement(By.CssSelector("[name='keywords']")).SendKeys("Keyboard" + "\n");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            try
            {
               WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

               IWebElement buyButton = wait.Until(e => e.FindElement(By.XPath("//span[text()='Buy Now']")));

               buyButton.Click();

                Assert.That(driver.FindElement(By.XPath("//strong[text()='Microsoft Internet Keyboard PS/2']")).Displayed, Is.True);

                Console.WriteLine("Product Found");

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }

            catch(Exception ex)
            {
                Assert.Fail("Unexpected Error: " + ex.Message);
            }                        
        }

        [Test]
        public void Test2() {

            driver.FindElement(By.CssSelector("[name='keywords']")).SendKeys("wtf2" + "\n");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);


            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement buyButton = wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Buy Now']")));

                buyButton.Click();

                Assert.Fail("Product Found - Test Failed");
                               
            }
            catch(Exception ex)
            {
                Assert.Pass("Product Not Found as expected.");
                Console.WriteLine("Product Not Found as expected." + ex.Message);

            }
            finally
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
        }



        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
            driver.Quit();
        }
    }
}