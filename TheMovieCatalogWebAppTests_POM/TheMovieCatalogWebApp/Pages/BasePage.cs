using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TheMovieCatalogWebApp.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected Actions actions;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            actions = new Actions(driver);
        }

        protected IWebElement LastPageButton => driver.FindElement(By.XPath("(//ul[@class='pagination']//li)[last()]"));
        private IWebElement AddMovieLink => driver.FindElement(By.XPath("//a[text()='Add Movie']"));
        private IWebElement AllMoviesLink => driver.FindElement(By.XPath("//a[text()='All Movies']"));
        private IWebElement WatchedMoviesLink => driver.FindElement(By.XPath("//a[text()='Watched Movies']"));
        private IWebElement LogoutLink => driver.FindElement(By.XPath("//a[text()='Logout']"));

        public void ClickLastPage()
        {
            actions.MoveToElement(LastPageButton).Click().Perform();
        }

        public void GoToAddMovie()
        {
            AddMovieLink.Click();
        }
        public void GoToAllMovies()
        {
            AllMoviesLink.Click();
        }
        
        public void GoToWatchedMovies()
        {
            WatchedMoviesLink.Click();
        }
        public void Logout()
        {
            LogoutLink.Click();
        }
    }
}