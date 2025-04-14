using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TheMovieCatalogWebApp.Pages;

namespace TheMovieCatalogWebApp.Tests
{
    public class PomTheMovieCatalogWebAppTests
    {
        private IWebDriver driver;

        private MoviesPage moviesPage;
        private WatchedMoviesPage watchedMoviesPage;
        private LoginPage loginPage;

        private readonly string BaseUrl = "https://d24hkho2ozf732.cloudfront.net/";

        private string movieTitle = "";
        private string movieDescription = "";

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl(BaseUrl);

            loginPage = new LoginPage(driver);
            loginPage.Login("sve123@abv.com", "Parolata1!");

            moviesPage = new MoviesPage(driver);
            watchedMoviesPage = new WatchedMoviesPage(driver);
        }

        [Test, Order(1)]
        public void Test01_AddMovieWithoutTitle()
        {
            moviesPage.GoToAddMovie();
            moviesPage.AddMovie("", "Wazaaa");

            Assert.That(moviesPage.GetPopUpMessage(), Is.EqualTo("The Title field is required."));
        }

        [Test, Order(2)]
        public void Test02_AddMovieWithoutDescription()
        {
            movieTitle = GetRandomMovieTitle("TestMovie");
            moviesPage.AddMovie(movieTitle, "");

            Assert.That(moviesPage.GetPopUpMessage(), Is.EqualTo("The Description field is required."));
        }

        [Test, Order(3)]
        public void Test03_AddMovieWithRandomTitle()
        {
            movieTitle = GetRandomMovieTitle("TestMovie");
            movieDescription = GetRandomMovieTitle("TestDesc");
            moviesPage.AddMovie(movieTitle, movieDescription);

            moviesPage.ClickLastPage();

            Assert.That(moviesPage.GetLastMovieTitle(), Is.EqualTo(movieTitle).IgnoreCase);
        }

        [Test, Order(4)]
        public void Test04_EditLastAddedMovie()
        {
            moviesPage.ClickLastPage();

            movieTitle += "Edited";
            moviesPage.EditLastMovie(movieTitle);

            Assert.That(moviesPage.GetPopUpMessage(), Is.EqualTo("The Movie is edited successfully!").IgnoreCase);
        }

        [Test, Order(5)]
        public void Test05_MarkLastAddedMovieAsWatched()
        {
            moviesPage.ClickLastPage();

            moviesPage.MarkLastMovieAsWatched();
            moviesPage.GoToWatchedMovies();
            watchedMoviesPage.ClickLastPage();

            Assert.That(watchedMoviesPage.GetLastWatchedMovieTitle(), Is.EqualTo(movieTitle).IgnoreCase);
        }

        [Test, Order(6)]
        public void Test06_DeleteLastAddedMovie()
        {
            moviesPage.GoToAllMovies();
            moviesPage.ClickLastPage();
            moviesPage.DeleteLastMovie();

            Assert.That(moviesPage.GetPopUpMessage(), Is.EqualTo("The Movie is deleted successfully!").IgnoreCase);
        }

        private string GetRandomMovieTitle(string numbers)
        {
            var rnd = new Random();
            return numbers + rnd.Next(1, 1000);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
