using _2._Student_RegistryApp.Pages;

namespace _2._Student_RegistryApp.PageTests
{
    public class HomePageTests : BaseTests
    {

        [Test]
        public void Home_Page_Tests()
        {
            var homePage = new HomePage(driver);

            homePage.OpenPage();

            Assert.That(homePage.GetPageTitle(), Is.EqualTo("MVC Example"));
            Assert.That(homePage.GetPageHeading(), Is.EqualTo("Students Registry"));
            Assert.That(homePage.GetStudentsCount(), Is.EqualTo(3));
        }

        [Test]
        public void Test_HomePage_Links()
        {
            var homePage = new HomePage(driver);

            homePage.OpenPage();
            homePage.HomeLink.Click();
            Assert.That(homePage.IsPageLoaded(), Is.True);

            homePage.OpenPage();
            homePage.ViewStudentsLink.Click();
            Assert.That(new ViewStudents(driver).IsPageLoaded(), Is.True);

            homePage.OpenPage();
            homePage.AddStudentLink.Click();
            Assert.That(new AddStudent(driver).IsPageLoaded(), Is.True);
        }

       

    }
}
