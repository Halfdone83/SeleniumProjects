using OpenQA.Selenium;

namespace TheMovieCatalogWebApp.Pages
{
    public class MoviesPage : BasePage
    {
        public MoviesPage(IWebDriver driver) : base(driver)
        { 
        
        }

        private IWebElement TitleInput => driver.FindElement(By.Name("Title"));
        private IWebElement DescriptionTextarea => driver.FindElement(By.Name("Description"));
        private IWebElement AddButton => driver.FindElement(By.XPath("//button[text()='Add']"));
        private IWebElement EditButton => driver.FindElement(By.XPath("//button[text()='Edit']"));
        private IWebElement MarkAsWatchedButton => driver.FindElement(By.XPath("(//div[@class='col-lg-4'])[last()]//a[text()='Mark as Watched']"));
        private IWebElement EditMovieButton => driver.FindElement(By.XPath("(//div[@class='col-lg-4'])[last()]//a[text()='Edit']"));
        private IWebElement DeleteMovieButton => driver.FindElement(By.XPath("(//div[@class='col-lg-4'])[last()]//a[text()='Delete']"));
        private IWebElement ConfirmDeleteButton => driver.FindElement(By.XPath("//button[text()='Yes']"));

        public void AddMovie(string title, string description)
        {
            TitleInput.Clear();
            DescriptionTextarea.Clear();
            TitleInput.SendKeys(title);
            DescriptionTextarea.SendKeys(description);
            AddButton.Click();
        }

        public void EditLastMovie(string newTitle)
        {
            actions.MoveToElement(EditMovieButton).Click().Perform();
            TitleInput.Clear();
            TitleInput.SendKeys(newTitle);
            EditButton.Click();
        }

        public void MarkLastMovieAsWatched()
        {
            actions.MoveToElement(MarkAsWatchedButton).Click().Perform();
        }

        public void DeleteLastMovie()
        {
            actions.MoveToElement(DeleteMovieButton).Click().Perform();
            actions.MoveToElement(ConfirmDeleteButton).Click().Perform();
        }

        public string GetLastMovieTitle()
        {
            return driver.FindElement(By.XPath("(//div[@class='col-lg-4']//h2)[last()]"))?.Text;
        }
        public string GetPopUpMessage()
        {
            return driver.FindElement(By.XPath("//div[@class='toast-message']"))?.Text;
        }

    }
}