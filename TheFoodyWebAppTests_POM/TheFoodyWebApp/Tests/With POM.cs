using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using TheFoodyWebApp.Pages;



namespace TheFoodyWebApp.Tests
{
    public class TheFoodyWebAppTestsPOM
    {
        private IWebDriver driver;

        private readonly string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85/";

        private string lastFoodName = "";
        private string lastFoodDescription = "";

        Actions actions;

        private LoginPage loginPage;
        private HomePage homePage;
        private AddEditPage addEditPage;
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            addEditPage = new AddEditPage(driver);

            driver.Navigate().GoToUrl(BaseUrl);
            driver.FindElement(By.XPath("//a[text()='Log In']")).Click();

            loginPage.Login("sve1234", "Debaparolata!1");            
        }

        [Test, Order(1)]
        public void Test01_AddFoodwithInvalidDataTest()
        {
            addEditPage.ClickAddButton();

            addEditPage.ClickSubmitButton();

            Assert.That(driver.Url, Is.EqualTo(BaseUrl + "Food/Add"));

            Assert.That(addEditPage.GetErrorMessage(), Is.EqualTo("Unable to add this food revue!"));
        }

        [Test, Order(2)]
        public void Test02_AddRandomFoodTest()
        {
            addEditPage.ClickAddButton();           

            lastFoodName = RandomNameGenerator("Test Food");
            lastFoodDescription = RandomNameGenerator("Test Description");

            addEditPage.AddNewFood(lastFoodName, lastFoodDescription);

            addEditPage.WaitForUrlToBe(BaseUrl);
            Assert.That(driver.Url, Is.EqualTo(BaseUrl));

            Assert.That(addEditPage.LastElementTitle, Is.EqualTo(lastFoodName));
        }

        [Test, Order(3)]
        public void Test03_EditLastAddedFoodTest()
        {
            addEditPage.ClickHomeButton();

            homePage.LastAddedFoodEditButtonClick();

            addEditPage.EditFoodName(lastFoodName + " Edited");                              
                       
            Assert.That(addEditPage.FoodTitle, Is.EqualTo(lastFoodName), "Title change won't be possible due to incomplete functionality");
        }

        [Test, Order(4)]
        public void Test04_SearchForFoodTitleTest()
        {
            addEditPage.ClickHomeButton();

            homePage.SearchForFood(lastFoodName);
            
            Assert.That(homePage.GetFoodList().Count, Is.EqualTo(1));
            
            Assert.That(homePage.LastElementTitle, Is.EqualTo(lastFoodName));
        }

        [Test, Order(5)]
        public void Test05_DeleteLastAddedFoodTest()
        {
            addEditPage.ClickHomeButton();

            homePage.LastAddedFoodDeleteButtonClick();
           
            Assert.That(homePage.FoodListTitles, Does.Not.Contain(lastFoodName), "Food was not deleted successfully.");
        }

        [Test, Order(6)]
        public void Test06_SearchforDeletedFoodTest()
        {
            driver.Navigate().GoToUrl(BaseUrl);

            homePage.SearchForFood(lastFoodName);
            
            Assert.That(homePage.ErrorMessage, Is.EqualTo("There are no foods :("));

            Assert.That(addEditPage.AddFoodButton.Displayed);
        }

        private string RandomNameGenerator(string text)
        {
            Random random = new Random();

            return text + random.Next(1, 1000).ToString();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}