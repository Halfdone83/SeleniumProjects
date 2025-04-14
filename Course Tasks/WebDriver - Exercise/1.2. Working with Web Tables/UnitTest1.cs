using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace _1._2._Working_with_Web_Tables
{
    public class Tests
    {

        IWebDriver driver;

        [SetUp]
        public void Setup()
        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://practice.bpbonline.com/");
        }

        [Test]
        public void Tables()
        {

            IWebElement table = driver.FindElement(By.TagName("table"));

            ReadOnlyCollection <IWebElement> tableRows = table.FindElements(By.XPath("//tbody//tr"));

            string path = Directory.GetCurrentDirectory() + "productInfo.csv";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

                foreach (var trow in tableRows)
                {
                    ReadOnlyCollection<IWebElement> elements = trow.FindElements(By.XPath("//td"));
                    foreach (var element in elements)
                    {
                        string data = element.Text;
                        string[] productInfo = data.Split("\n");
                        string productInformationToPrint = productInfo[0].Trim() + "," + productInfo[1].Trim() + "\n";

                        File.AppendAllText(path, productInformationToPrint);
                    }



                }

            

            Assert.That(File.Exists(path), Is.True, "File missing");
            Assert.That(new FileInfo(path).Length, Is.GreaterThan(0), "File is empty");




        }

        [TearDown]
        public void TearDown() 
        { 
            driver.Dispose();
            driver.Quit();
        }

    }
}