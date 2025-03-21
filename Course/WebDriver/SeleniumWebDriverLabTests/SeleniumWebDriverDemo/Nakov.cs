using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Security.Cryptography.X509Certificates;

namespace SeleniumWebDriverDemo
{
    public class Nakov
    {

        private IWebDriver driver;

        [SetUp]

        public void Setup()
        {
            driver = new ChromeDriver();        }

        [Test]
        public void Test2()
        {

            

            driver.Navigate().GoToUrl("https://nakov.com/");

            var pageTtitle = driver.Title;

            Assert.That(pageTtitle.Contains("Svetlin Nakov – Official Web Site"));

            var searchLink = driver.FindElement(By.XPath("//li[@id='sh']//a[@class='smoothScroll']"));

            var searchClass = searchLink.GetAttribute("class");

            Console.WriteLine(searchClass);

            Assert.That(searchLink.Text, Is.EqualTo("SEARCH"));

            searchLink.Click();

            var searchInput = driver.FindElement(By.Id("s"));

            var placeHolder = searchInput.GetAttribute("placeholder");


            Console.WriteLine(placeHolder);

            Assert.That(searchInput.GetAttribute("placeholder"), Is.EqualTo("Search this site"));

                          


        }

        [TearDown]

        public void TearDown()
        {
            driver.Dispose();
        }


    }
}
