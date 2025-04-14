using _2._Student_RegistryApp.Pages;

namespace _2._Student_RegistryApp.PageTests
{
    public class ViewStudentsPageTests : BaseTests
    {

        [Test]
        public void Test_ViewStudentsPage_Content()
        {
            var viewStudents = new ViewStudents(driver);

            viewStudents.OpenPage();

            Assert.That(viewStudents.GetPageTitle(), Is.EqualTo("Students"));
            Assert.That(viewStudents.GetPageHeading(), Is.EqualTo("Registered Students"));                      

            var students = viewStudents.GetStudentsList();
            foreach (var student in students)
            {
                Console.WriteLine(student);
                //Assert.IsTrue(student.IndexOf("(") > 0);
                //Assert.IsTrue(student.LastIndexOf(")") == student.Length - 1);
                Assert.IsTrue(student.Contains("("));
                Assert.IsTrue(student.EndsWith(")"));
            }
        }

        [Test]
        public void Test_ViewStudentsPage_Links()
        {
            var viewStudents = new ViewStudents(driver);
            viewStudents.OpenPage();
            Assert.That(viewStudents.IsPageLoaded(), Is.True);

            viewStudents.OpenPage();
            viewStudents.HomeLink.Click();
            Assert.That(new HomePage(driver).IsPageLoaded(), Is.True);

            viewStudents.OpenPage();
            viewStudents.AddStudentLink.Click();
            Assert.That(new AddStudent(driver).IsPageLoaded(), Is.True);



        }

    }
}
