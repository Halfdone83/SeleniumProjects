using OpenQA.Selenium;

namespace SeleniumWebDriverPOM.Pages
{
    public class InventoryPage : BasePage
    {

        public InventoryPage(IWebDriver driver) : base(driver) {
        
        }

        private readonly By cartLink = By.CssSelector("[data-test=shopping-cart-link]");
        private readonly By productTitle = By.CssSelector("[class=title]");
        private readonly By inventoryItems = By.CssSelector(".inventory_item");


        public void AddToCart(int index)
        {
            var itemToAdd = By.XPath($"//div[@class='inventory_item'][{index}]//button");
            Click(itemToAdd);
        }

        public void AddToCartByName(string name)
        {
            var itemToAdd = By.XPath($"//div[@class='inventory_item_name ' and text()='{name}']/ancestor::div[@class='inventory_item']//button");
            Click(itemToAdd);
        }

        public void ClickCart()
        {
            Click(cartLink);
        }

        public bool IsInventoryDisplayed()
        {
            var elements = FindElements(inventoryItems);

            Console.WriteLine($"DEBUG: Намерени {elements.Count} елемента");

            return elements.Any();
        }


        public bool IsPageLoaded()
        {
            return GetText(productTitle) == "Products" && driver.Url.Contains("inventory.html");
        }



    }
}
