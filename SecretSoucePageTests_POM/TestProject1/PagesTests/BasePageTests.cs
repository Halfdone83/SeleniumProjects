using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebDriverPOM.Pages;

namespace SeleniumWebDriverPOM.PagesTests
{
    public class BasePageTEsts
    {

        protected IWebDriver driver;

        protected HiddenMenuPage hiddenMenuPage;
        protected InventoryPage inventoryPage;
        protected CartPage cartPage;
        protected CheckOutPage checkOutPage;
        protected LoginPage loginPage;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_enabled", false);

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            hiddenMenuPage = new HiddenMenuPage(driver);
            inventoryPage = new InventoryPage(driver);
            cartPage = new CartPage(driver);
            checkOutPage = new CheckOutPage(driver);
            loginPage = new LoginPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
            driver.Quit();
        }


        protected void Login(string username, string password)
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
          

            loginPage.Username(username);
            loginPage.Password(password);
            loginPage.LoginButton();
        }



    }
}
