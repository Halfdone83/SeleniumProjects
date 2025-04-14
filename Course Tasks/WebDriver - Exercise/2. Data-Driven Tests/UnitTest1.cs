using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V131.Storage;
using OpenQA.Selenium.Support.UI;

namespace _2._Data_Driven_Tests
{
    public class TestCalculator
    {

        IWebDriver driver;

        IWebElement firstNum;
        IWebElement selectOperation;
        IWebElement secondNum;
        IWebElement calculate;
        IWebElement reset;
        IWebElement result;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("file:///C:/Users/Halfdone/Desktop/FrontEndQA/Front-End%20Automation%20Testing/04.Exercise%20Selenium%20WebDriver/number-calculator/number-calculator.html");

            firstNum = driver.FindElement(By.Id("number1"));
            selectOperation = driver.FindElement(By.Id("operation"));
            secondNum = driver.FindElement(By.Id("number2"));
            calculate = driver.FindElement(By.Id("calcButton"));
            reset = driver.FindElement(By.Id("resetButton"));
            result = driver.FindElement(By.Id("result"));

        }

        
        public void Calculation(string firstNumber, string operation, string secondNumber, string expectedResult)
        {

            reset.Click();

            if (!string.IsNullOrEmpty(firstNumber)){
                firstNum.SendKeys(firstNumber);
            }

            if (!string.IsNullOrEmpty(secondNumber))
            {
                secondNum.SendKeys(secondNumber);
            }

            if (!string.IsNullOrEmpty(operation))
            {
                new SelectElement(selectOperation).SelectByText(operation);
            }

            calculate.Click();

            Assert.That(result.Text,Is.EqualTo(expectedResult));

        }
        [Test]
        [TestCase("5", "+ (sum)", "5", "Result: 10")]
        [TestCase("10", "+ (sum)", "5", "Result: 15")]
        [TestCase("20", "+ (sum)", "5", "Result: 25")]
        [TestCase("5", "+ (sum)", "30", "Result: 35")]
        public void Tests(string firstNumber, string operation, string secondNumber, string expectedResult) { 
        
        
            Calculation(firstNumber, operation, secondNumber, expectedResult);
        
        
        }


        [OneTimeTearDown] public void TearDown() {

            driver.Quit();

            driver.Dispose();
            
        }


    }
}