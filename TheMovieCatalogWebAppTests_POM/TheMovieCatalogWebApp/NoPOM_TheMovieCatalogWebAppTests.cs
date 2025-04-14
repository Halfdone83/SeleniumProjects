using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace TheMovieCatalogWebApp
{
    public class NoPOM_TheMovieCatalogWebAppTests
    {
        private IWebDriver driver;
        Actions actions;
        private readonly string BaseUrl = "https://d24hkho2ozf732.cloudfront.net/";

        private string movieTitle = "";
        private string movieDescription = "";

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            driver.Navigate().GoToUrl(BaseUrl);
            actions = new Actions(driver);
            var LoginHereButton = driver.FindElement(By.XPath("//a[text()='LOGIN HERE']"));
            actions.MoveToElement(LoginHereButton).Click().Perform();
            driver.FindElement(By.XPath("//input[@name='Email']")).SendKeys("sve123@abv.com");
            driver.FindElement(By.XPath("//input[@name='Password']")).SendKeys("Parolata1!");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        [Test, Order(1)]
        public void Test01_AddMovieWithoutTitleTest()
        {
            driver.FindElement(By.XPath("//a[text()='Add Movie']")).Click();
            driver.FindElement(By.XPath("//input[@name='Title']")).SendKeys("");
            driver.FindElement(By.XPath("//textarea[@name='Description']")).SendKeys(movieDescription + "Test");
            driver.FindElement(By.XPath("//button[text()='Add']")).Click();

            var errorTitleMessage = driver.FindElement(By.XPath("//div[@class='toast-message']")).Text;
            Assert.That(errorTitleMessage, Is.EqualTo("The Title field is required."));                        
        }

        [Test, Order(2)]
        public void Test02_AddMovieWithoutDescriptionTest()
        {
            movieTitle = GetRandomMovieTitle("TestMovie");

            driver.FindElement(By.XPath("//textarea[@name='Description']")).Clear();

            driver.FindElement(By.XPath("//input[@name='Title']")).SendKeys(movieTitle);
            driver.FindElement(By.XPath("//textarea[@name='Description']")).SendKeys("");
            driver.FindElement(By.XPath("//button[text()='Add']")).Click();

            var errorDescriptionMessage = driver.FindElement(By.XPath("//div[@class='toast-message']")).Text;
            Assert.That(errorDescriptionMessage, Is.EqualTo("The Description field is required."));
        }

        [Test, Order(3)]
        public void Test03_AddMoviewithRandomTitleTest()
        { 
            movieDescription = GetRandomMovieTitle("TestMovie");
            movieTitle = GetRandomMovieTitle("TestMovie");

            driver.FindElement(By.XPath("//input[@name='Title']")).Clear();
            driver.FindElement(By.XPath("//textarea[@name='Description']")).Clear();

            driver.FindElement(By.XPath("//input[@name='Title']")).SendKeys(movieTitle);
            driver.FindElement(By.XPath("//textarea[@name='Description']")).SendKeys(movieDescription);
            driver.FindElement(By.XPath("//button[text()='Add']")).Click();

            var lastPage = driver.FindElement(By.XPath("(//ul[@class='pagination']//li)[last()]"));
            actions.MoveToElement(lastPage).Click().Perform();

            var lastMovieTitle = driver.FindElement(By.XPath("(//div[@class='col-lg-4']//h2)[last()]")).Text;
            Assert.That(lastMovieTitle, Is.EqualTo(movieTitle).IgnoreCase);
        }

        [Test, Order(4)]
        public void Test04_EditLastAddedMovieTest()
        {
            var lastPage = driver.FindElement(By.XPath("(//ul[@class='pagination']//li)[last()]"));
            actions.MoveToElement(lastPage).Click().Perform();

            var lastMovieEditButton = driver.FindElement(By.XPath("(//div[@class='col-lg-4'])[last()]//a[text()='Edit']"));
            actions.MoveToElement(lastMovieEditButton).Click().Perform();

            var editMovieTitle = driver.FindElement(By.XPath("//input[@name='Title']"));
            editMovieTitle.Clear();
            editMovieTitle.SendKeys(movieTitle + "Edited");

            driver.FindElement(By.XPath("//button[text()='Edit']")).Click();

            var successMessage = driver.FindElement(By.XPath("//div[@class='toast-message']")).Text;
            Assert.That(successMessage, Is.EqualTo("The Movie is edited successfully!").IgnoreCase);            
        }

        [Test, Order(5)]
        public void Test05_MarkLastAddedMovieAsWatchedTest()
        {
            var lastPage = driver.FindElement(By.XPath("(//ul[@class='pagination']//li)[last()]"));
            actions.MoveToElement(lastPage).Click().Perform();

            var markAsWatchedLastMovieButton = driver.FindElement(By.XPath("(//div[@class='col-lg-4'])[last()]//a[text()='Mark as Watched']"));
            actions.MoveToElement(markAsWatchedLastMovieButton).Click().Perform();

            driver.FindElement(By.XPath("//a[text()='Watched Movies']")).Click();

            var lastPageWatchedMovies = driver.FindElement(By.XPath("(//ul[@class='pagination']//li)[last()]"));
            actions.MoveToElement(lastPageWatchedMovies).Click().Perform();

            var lastWatchedMovieTitle = driver.FindElement(By.XPath("(//div[@class='col-lg-4']//h2)[last()]")).Text;
            Assert.That(lastWatchedMovieTitle, Is.EqualTo(movieTitle + "Edited").IgnoreCase);
        }

        [Test, Order(6)]
        public void Test06_DeleteLastAddedMovieTest()
        {
            driver.FindElement(By.XPath("//a[text()='All Movies']")).Click();

            var lastPage = driver.FindElement(By.XPath("(//ul[@class='pagination']//li)[last()]"));
            actions.MoveToElement(lastPage).Click().Perform();

            var lastMovieDeleteButton = driver.FindElement(By.XPath("(//div[@class='col-lg-4'])[last()]//a[text()='Delete']"));
            actions.MoveToElement(lastMovieDeleteButton).Click().Perform();

            var confirmDeleteButton = driver.FindElement(By.XPath("//button[text()='Yes']"));
            actions.MoveToElement(confirmDeleteButton).Click().Perform();

            var successMessage = driver.FindElement(By.XPath("//div[@class='toast-message']")).Text;
            Assert.That(successMessage, Is.EqualTo("The Movie is deleted successfully!").IgnoreCase);
        }

        private string GetRandomMovieTitle(string text)
        {
            var random = new Random();
            var randomNumber = random.Next(1, 1000);
            return text + randomNumber;
        }              

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}