using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace _1._3._Drop_down_Practice
{
    public class Tests
    {

        IWebDriver driver;

        [SetUp]
        public void Setup()
        {

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");

            driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl("https://practice.bpbonline.com/");

        }

        [Test]
        public void Test1()
        {
           
            string path = Directory.GetCurrentDirectory() + "/manufacturers.txt";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            SelectElement manufacturerMenu = new SelectElement(driver.FindElement(By.XPath("//select[@name='manufacturers_id']")));


            IList<IWebElement> allManufacturers = manufacturerMenu.Options;

            List<string> manufacturerNames = new List<string>();

            foreach (IWebElement manufacturer in allManufacturers)
            {
                manufacturerNames.Add(manufacturer.Text);

            }

            manufacturerNames.RemoveAt(0);


            foreach(var mnane in manufacturerNames)
            {
                manufacturerMenu.SelectByText(mnane);

                manufacturerMenu = new SelectElement(driver.FindElement(By.XPath("//select[@name='manufacturers_id']")));


                if(driver.PageSource.Contains("There are no products available in this category."))
                {

                    File.AppendAllText(path, $"The manufaturer {mnane} has no products!");

                }

                else
                {

                    IWebElement table = driver.FindElement(By.XPath("//table[@class='productListingData']"));

                    File.AppendAllText(path, $"\n\nThe manufacturer {mnane} products are listed--\n");

                    ReadOnlyCollection<IWebElement> rows = table.FindElements(By.XPath("//tbody//tr"));

                    foreach (IWebElement row in rows)
                    {
                        File.AppendAllText(path, row.Text + "\n");

                    }



                }



            }


        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
            
        }
    }
}