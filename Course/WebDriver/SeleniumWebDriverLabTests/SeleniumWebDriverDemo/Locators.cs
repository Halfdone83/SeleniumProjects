using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverDemo
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class Locators
    {

        public IWebDriver driver;


        [SetUp]



        public void Setup()
        {
            Console.WriteLine("Setup() - Стартиране на WebDriver");
         
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("file:///C:/Users/Halfdone/Desktop/FrontEndQA/Front-End%20Automation%20Testing/03.Selenium-WebDriver/SimpleForm/Locators.html");
        }

        [Test]

        public void Basic_Locators()
        {


            var lastName = driver.FindElement(By.CssSelector("input[name='lname']"));
            var lastNameValue = lastName.GetAttribute("value");
            Console.WriteLine(lastNameValue);

            Assert.That(lastNameValue, Is.EqualTo("Vega"));


            var checkBox = driver.FindElement(By.CssSelector("input[type='checkbox']"));
            
            Assert.That(checkBox.Selected is false);




            var anchorTag = driver.FindElement(By.CssSelector("p > a"));

            Assert.That(anchorTag.Text, Is.EqualTo("Softuni Official Page"));


            var inputInformation = driver.FindElement(By.CssSelector("input[class=information]"));

            var inputBgColour = inputInformation.GetCssValue("background-color");

            Console.WriteLine(inputBgColour);

            Assert.That(inputBgColour, Is.EqualTo("rgba(255, 255, 255, 1)"));



        }


        [Test]

        public void Text_Link_locators()
        {

            var linkByFullText = driver.FindElement(By.LinkText("Softuni Official Page"));

            var linkHref = linkByFullText.GetAttribute("href");

            Console.WriteLine(linkHref);

            Assert.That(linkHref, Is.EqualTo("http://www.softuni.bg/"));



            var linkByPartialText = driver.FindElement(By.PartialLinkText("Softuni"));

            var linkPHref = linkByPartialText.GetAttribute("href");

            Console.WriteLine(linkPHref);

            Assert.That(linkPHref, Is.EqualTo("http://www.softuni.bg/"));





        }






        [Test]

        public void CSS_Selectors()
        {

            var firstName = driver.FindElement(By.Id("fname"));
            var firstNameValue = firstName.GetAttribute("value");
            Console.WriteLine(firstNameValue);
            Assert.That(firstName.GetAttribute("value"), Is.EqualTo("Vincent"));


            var firstNameAgain = driver.FindElement(By.CssSelector("input[name=\"fname\"]"));
            var firstNameClass = firstNameAgain.GetAttribute("class");
            Console.WriteLine(firstNameClass);
            Assert.That(firstNameClass, Is.EqualTo("information"));



            var submitButton = driver.FindElement(By.CssSelector("input[class=\"button\"]"));
            var submitButtonValue = submitButton.GetAttribute("value");
            Console.WriteLine(submitButtonValue);
            Assert.That(submitButtonValue, Is.EqualTo("Submit"));


            var phoneNumber = driver.FindElement(By.CssSelector("p > input[type=\"text\"]"));

            Assert.That(phoneNumber.Displayed);


        }


        [Test]
        [Explicit]


        public void Xpath_Locators()
        {

            var maleButton = driver.FindElement(By.XPath("//input[@value='m']"));

            var maleValue = maleButton.GetAttribute("value");

            Console.WriteLine(maleValue);

            Assert.That(maleValue, Is.EqualTo("m"));




            var lastName = driver.FindElement(By.XPath("//input[@id='lname']"));

            var lastNameValue = lastName.GetAttribute("value");

            Assert.That(lastNameValue, Is.EqualTo("Vega"));



            var phoneField = driver.FindElement(By.XPath("//div[@class='additional-info']//p"));

            Assert.That(phoneField.Displayed);


        }


       



        [TearDown]

        public void TearDown()
        {
            Console.WriteLine("TearDown() - Затваряне на WebDriver");
            driver.Quit();
            driver.Dispose();
        }

    }
}
