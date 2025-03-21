using OpenQA.Selenium;

namespace SeleniumWebDriverPOM.Pages
{
    public class HiddenMenuPage :BasePage
    {
        public HiddenMenuPage(IWebDriver driver) : base(driver)
        {

        }


        private readonly By burgerButton = By.CssSelector("[class=bm-burger-button]");
        private readonly By logoutButton = By.CssSelector("[data-test=logout-sidebar-link]");

        public void ClickBurgerButton()
        {
            Click(burgerButton);
        }

        public void ClickLogout()
        {
            Click(logoutButton);
        }

        public bool IsMenuOpen()
        {
            return FindElement(logoutButton).Displayed;
        }



    }
}
