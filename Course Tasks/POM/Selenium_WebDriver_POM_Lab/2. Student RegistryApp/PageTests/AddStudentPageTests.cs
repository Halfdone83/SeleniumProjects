using _2._Student_RegistryApp.Pages;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace _2._Student_RegistryApp.PageTests
{
    public class AddStudentPageTests : BaseTests
    {
        [Test]
        public void Test_TestAddStudentPage_Content()
        {
            var addStudent = new AddStudent(driver);

            addStudent.OpenPage();

            Assert.That(addStudent.GetPageTitle(), Is.EqualTo("Add Student"));
            Assert.That(addStudent.GetPageHeading(), Is.EqualTo("Register New Student"));

            Assert.That(addStudent.Name.Text, Is.Empty);
            Assert.That(addStudent.Email.Text, Is.Empty);
            Assert.That(addStudent.AddButton.Text, Is.EqualTo("Add"));
        }

        [Test]

        public void Test_TestAddStudentPage_Links()
        {
            var addStudent = new AddStudent(driver);

            addStudent.OpenPage();
            addStudent.HomeLink.Click();
            Assert.That(new HomePage(driver).IsPageLoaded(), Is.True);

            addStudent.OpenPage();
            addStudent.ViewStudentsLink.Click();
            Assert.That(new ViewStudents(driver).IsPageLoaded(), Is.True);

            addStudent.OpenPage();
            addStudent.AddStudentLink.Click();
            Assert.That(addStudent.IsPageLoaded(), Is.True);

        }

        [Test]
        public void Test_TestAddStudentPage_AddValidStudent()
        {
            var addStudent = new AddStudent(driver);
            addStudent.OpenPage();

            string randomName = "TestName" + new Random().Next(1000);
            string randomEmail = "test" + new Random().Next(1000) + "@test.com";
            addStudent.AddStudents(randomName, randomEmail);


            var viewStudents = new ViewStudents(driver);
            viewStudents.OpenPage();

            string pageContent = driver.PageSource;

            Assert.IsTrue(pageContent.Contains(randomName), "Not Found");

            var students = viewStudents.GetStudentsList();

            string newStudent = randomName + " (" + randomEmail + ")";

            Assert.That(students.Contains(newStudent));

        }

        [Test]
        public void	Test_TestAddStudentPage_AddInvalidStudent()
        {
            var addStudent = new AddStudent(driver);
            addStudent.OpenPage();

            addStudent.AddStudents("", "");

            Assert.That(addStudent.IsPageLoaded(), Is.True);
            Assert.That(addStudent.ErrorMessageText(), Is.EqualTo("Cannot add student. Name and email fields are required!"));


        }

    }
}
