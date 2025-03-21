using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverDemo
{
    internal class Test_Form_Submission
    {


        public IWebDriver driver;

        [SetUp]

        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("==headless=new");

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("file:///C:/Users/Halfdone/Desktop/FrontEndQA/Front-End%20Automation%20Testing/03.Selenium-WebDriver/SimpleForm/Locators.html");
        }


        [Test]

        public void TestFormSubmission()
        {


            var contactTitle = driver.FindElement(By.TagName("h2"));
            Assert.That(contactTitle.Text, Is.EqualTo("Contact Form"));

            var malebutton = driver.FindElement(By.XPath("//input[@value='m']"));
            malebutton.Click();
            Assert.That(malebutton.Selected);

            var fName = driver.FindElement(By.CssSelector("#fname"));
            fName.Clear();
            fName.SendKeys("Butch");
            var fNameValue = fName.GetAttribute("value");
            Console.WriteLine(fNameValue);
            Assert.That(fNameValue, Is.EqualTo("Butch"));

            var lName = driver.FindElement(By.CssSelector("#lname"));
            lName.Clear();
            lName.SendKeys("Coolidge");
            var lnameValue = lName.GetAttribute("value");
            Console.WriteLine(lnameValue);
            Assert.That(lnameValue, Is.EqualTo("Coolidge"));

            var additionInfoSection = driver.FindElement(By.TagName("h3"));
            Assert.That(additionInfoSection.Displayed);

            var phoneField = driver.FindElement(By.XPath("//div[@class='additional-info']//input"));
            phoneField.Clear();
            phoneField.SendKeys("0888999777");
            var PhoneFieldValue = phoneField.GetAttribute("value");
            Console.WriteLine(PhoneFieldValue);
            Assert.That(PhoneFieldValue, Is.EqualTo("0888999777"));

            var checkBox = driver.FindElement(By.XPath("//input[@type='checkbox']"));
            checkBox.Click();
            Assert.That(checkBox.Selected);


            var submitButton = driver.FindElement(By.XPath("//input[@type='submit']"));
            submitButton.Click();


            var message = driver.FindElement(By.TagName("h1"));
            Assert.That(message.Text, Is.EqualTo("Thank You!"));
            Assert.That(message.Displayed);













        }


        [TearDown]

        public void TearDown()
        {

            driver.Quit();

        }





    }
}
