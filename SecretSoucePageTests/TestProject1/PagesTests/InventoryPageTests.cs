using OpenQA.Selenium.DevTools.V131.FedCm;
using SeleniumWebDriverPOM.Pages;

namespace SeleniumWebDriverPOM.PagesTests
{
    public class InventoryPageTests : BasePageTEsts
    {

        [SetUp]
        public void LoginSetup()
        {
            Login("standard_user", "secret_sauce");
        }


        [Test]
        public void TestInventoryDisplay()
        {
            Console.WriteLine("DEBUG: Започва тестът...");

            Console.WriteLine("DEBUG: Създаден е inventoryPage...");

            bool isDisplayed = inventoryPage.IsInventoryDisplayed();
            Console.WriteLine($"DEBUG: IsInventoryDisplayed = {isDisplayed}");

            Assert.That(isDisplayed, Is.True);
        }




        [Test]
        public void TestAddToCartByIndex()
        {                      
            inventoryPage.AddToCart(1);

            inventoryPage.ClickCart();
            
            Assert.That(cartPage.IsCartItemDisplayed(), Is.True);
        }

        [Test]
        public void TestAddToCartByName()
        {
            inventoryPage.AddToCartByName("Sauce Labs Backpack");

            inventoryPage.ClickCart();

            Assert.That(cartPage.IsCartItemDisplayed(), Is.True);
        }

        [Test]
        public void TestPageTitle()
        {   
            Assert.That(inventoryPage.IsPageLoaded(), Is.True);
        }

    }
}
