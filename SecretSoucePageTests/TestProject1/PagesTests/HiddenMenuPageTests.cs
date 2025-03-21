using SeleniumWebDriverPOM.Pages;

namespace SeleniumWebDriverPOM.PagesTests
{
    public class HiddenMenuPageTests : BasePageTEsts
    {

        [SetUp]
        public void LoginSetup()
        {
            Login("standard_user", "secret_sauce");
        }


        [Test]
        public void TestOpenMenu()
        { 
            hiddenMenuPage.ClickBurgerButton();

            Assert.That(hiddenMenuPage.IsMenuOpen, Is.True);        
        }

        [Test]
        public void TestLogout()
        {
            hiddenMenuPage.ClickBurgerButton();
            hiddenMenuPage.ClickLogout();

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"));
        }


    }
}
