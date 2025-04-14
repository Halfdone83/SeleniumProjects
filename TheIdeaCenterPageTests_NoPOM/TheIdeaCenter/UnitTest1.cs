using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace TheIdeaCenter
{
    public class TheIdeaCenterTests
    {
        private IWebDriver driver;
        private string baseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83/";

        string lastTitle = "";
        string lastDescription = "";

        Actions actions;
        Random random;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl(baseUrl);
            driver.FindElement(By.CssSelector("[class='btn btn-outline-info px-3 me-2']")).Click();
            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("sve777@abv.com");
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("123456");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();                      
        }

        [Test, Order(1)]
        public void CreateIdeaWithInvalidDataTest()
        {
           driver.FindElement(By.XPath("//a[@class='nav-link'][text()='Create Idea']")).Click();
           driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']")).Click();

           Assert.That(driver.Url, Is.EqualTo("http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83/Ideas/Create"));

           Assert.That(driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']//li")).Text, Is.EqualTo("Unable to create new Idea!"));
        }


        [Test, Order(2)]
        public void CreateRandomIdeaTest() 
        {
            lastTitle = RandomNumbers("TestTitle");
            lastDescription = RandomNumbers("TestDescription");

            driver.FindElement(By.XPath("//a[@class='nav-link'][text()='Create Idea']")).Click();
            
            driver.FindElement(By.XPath("//input[@name='Title']")).SendKeys(lastTitle);
            driver.FindElement(By.XPath("//textarea[@type='text']")).SendKeys(lastDescription);

            driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']")).Click();

            Assert.That(driver.Url, Is.EqualTo("http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83/Ideas/MyIdeas"));
            Assert.That(driver.FindElement(By.XPath("(//p[@class='card-text'])[last()]")).Text, Is.EqualTo(lastDescription));
        }

        [Test, Order(3)]
        public void ViewLastCreatedIdeaTest()
        {       
            List<IWebElement> allIdeaCards = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']")).ToList(); //??

            var viewButton = driver.FindElement(By.XPath("(//div[@class='card mb-4 box-shadow'])[last()]//a[@type='button']"));
            actions = new Actions(driver);
            actions.MoveToElement(viewButton).Click().Perform();
            
            var ideaTitle = driver.FindElement(By.CssSelector("[class='mb-0 h4']")).Text;
            
            Assert.That(ideaTitle, Is.EqualTo(lastTitle));
        }

        [Test, Order(4)]
        public void EditLastCreatedIdeaTest()
        {
            driver.FindElement(By.XPath("//a[@class='nav-link'][text()='My Ideas']")).Click();

            var editButton = driver.FindElement(By.XPath("(//div[@class='card mb-4 box-shadow'])[last()]//a[text()='Edit']"));
            actions = new Actions(driver);
            actions.MoveToElement(editButton).Click().Perform();

            var title = driver.FindElement(By.Id("form3Example1c"));
            title.Clear();
            title.SendKeys("Changed Title" + lastTitle);
            lastTitle = "Changed Title" + lastTitle;

            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            var viewButton = driver.FindElement(By.XPath("(//div[@class='card mb-4 box-shadow'])[last()]//a[@type='button']"));
            actions = new Actions(driver);
            actions.MoveToElement(viewButton).Click().Perform();

            var ideaNewTitle = driver.FindElement(By.CssSelector("[class='mb-0 h4']")).Text;

            Assert.That(ideaNewTitle, Is.EqualTo(lastTitle));
        }

        [Test, Order(5)]
        public void EditDescriptionIdeaTest() 
        {
            driver.FindElement(By.XPath("//a[@class='nav-link'][text()='My Ideas']")).Click();

            var editButton = driver.FindElement(By.XPath("(//div[@class='card mb-4 box-shadow'])[last()]//a[text()='Edit']"));
            actions = new Actions(driver);
            actions.MoveToElement(editButton).Click().Perform();

            var description = driver.FindElement(By.XPath("//textarea[@type='text']"));
            description.Clear();
            description.SendKeys("Changed Description" + lastDescription);
            lastDescription = "Changed Description" + lastDescription;

            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            var ideaNewDescription = driver.FindElement(By.XPath("(//div[@class='card mb-4 box-shadow'])[last()]//p")).Text;

            Assert.That(ideaNewDescription, Is.EqualTo(lastDescription));
        }

        [Test, Order(6)]
        public void DeleteLastCreatedIdeaTest()
        {
            driver.FindElement(By.XPath("//a[@class='nav-link'][text()='My Ideas']")).Click();

            var deleteButton = driver.FindElement(By.XPath("(//div[@class='card mb-4 box-shadow'])[last()]//a[text()='Delete']"));
            actions = new Actions(driver);
            actions.MoveToElement(deleteButton).Click().Perform();

            List<IWebElement> ideas = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']")).ToList();

            Assert.That(ideas.Select(e => e.Text), Does.Not.Contain(lastDescription));
        }


        private string RandomNumbers(string text)
        {           
            random = new Random();

            return text + random.Next(1000, 9999).ToString();
        }
 
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}