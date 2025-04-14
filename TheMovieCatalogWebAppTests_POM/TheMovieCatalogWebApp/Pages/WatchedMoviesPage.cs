using OpenQA.Selenium;

namespace TheMovieCatalogWebApp.Pages
{
    public class WatchedMoviesPage : BasePage
    {
        public WatchedMoviesPage(IWebDriver driver) : base(driver)
        {

        }
        public string GetLastWatchedMovieTitle()
        {
            return driver.FindElement(By.XPath("(//div[@class='col-lg-4']//h2)[last()]"))?.Text;
        }
    }
}