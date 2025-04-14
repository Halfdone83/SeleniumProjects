using SeleniumWebDriverPOM.Pages;

namespace SeleniumWebDriverPOM.PagesTests
{
    public class CheckOutPageTests : BasePageTEsts
    {

        [SetUp]
        public void SetUp()
        {
            Login("standard_user", "secret_sauce");            
           
            inventoryPage.AddToCart(1);
            inventoryPage.ClickCart();
           
            cartPage.ClickCheckout();        
        }


        [Test]
        public void	TestCheckoutPageLoaded()
        {           
            Assert.That(checkOutPage.IsPageLoaded(), Is.True);
        }

        [Test]
        public void TestContinueToNextStep()
        {          
            checkOutPage.FillDetails();

            Assert.That(checkOutPage.IsPageLoaded(), Is.True);
        }

        [Test]
        public void TestCompleteOrder()
        {
            checkOutPage.FillDetails();
            checkOutPage.ClickFinish();

            Assert.That(checkOutPage.IsCheckoutComplete(), Is.True);            
        }

    }
}
