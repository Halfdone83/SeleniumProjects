using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverPOM.Pages
{
    public class CartPage : BasePage
    {

        public  CartPage(IWebDriver driver) : base(driver){

        }

        private readonly By cartItem = By.CssSelector("[class=cart_item]");
        private readonly By checkOutButton = By.CssSelector("[name=checkout]");


        public bool IsCartItemDisplayed()
        { 
            return FindElement(cartItem).Displayed;
        }

        public void ClickCheckout()
        {
            Click(checkOutButton);
        }
         



    }
}
