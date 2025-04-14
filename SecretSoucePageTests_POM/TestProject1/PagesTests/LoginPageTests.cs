using SeleniumWebDriverPOM.Pages;

namespace SeleniumWebDriverPOM.PagesTests
{
    public class LoginPageTests : BasePageTEsts
    {

        [Test]

        public void TestLoginWithValidCredentials()
        {
            Login("standard_user", "secret_sauce");

            var inventoryPage = new InventoryPage(driver);

            Assert.That(inventoryPage.IsPageLoaded(), Is.True);
        }

        [Test]
        public void TestLoginWithInvalidCredentials()
        {        
            Login("standard_user", "invalid_password");

            var loginPage = new LoginPage(driver);

            string ErrorMessage = loginPage.GetErrorMessage();

            Assert.That(ErrorMessage, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));       
        }


        [Test]
        public void TestLoginWithLockedOutUser()
        {
            Login("locked_out_user", "secret_sauce");

            var loginPage = new LoginPage(driver);

            string ErrorMessage = loginPage.GetErrorMessage();

            Assert.That(ErrorMessage, Is.EqualTo("Epic sadface: Sorry, this user has been locked out."));        
        }





    }
}
