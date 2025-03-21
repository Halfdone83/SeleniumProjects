using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace practice.bpbonline.com

{


    public class Tests
    {

        public IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://practice.bpbonline.com/");
        }

        [Test]
        public void CreateAccountTest()
        {
            var myAccount = driver.FindElement(By.XPath("//span [text()='My Account']"));
            myAccount.Click();

            var continueButton = driver.FindElement(By.XPath("//span [text()='Continue']"));
            continueButton.Click();

            var maleButton = driver.FindElement(By.XPath("//input[@value='m']"));
            maleButton.Click();
            Assert.That(maleButton.Selected);

            var firstName = driver.FindElement(By.XPath("//input[@name='firstname']"));
            firstName.SendKeys("Svetoslav");
            Assert.That(firstName.GetAttribute("value"), Is.EqualTo("Svetoslav"));

            var lastName = driver.FindElement(By.Name("lastname"));
            lastName.SendKeys("Dantchev");
            Assert.That(lastName.GetAttribute("value"), Is.EqualTo("Dantchev"));

            var birthDate = driver.FindElement(By.XPath("//input[@name='dob']"));
            birthDate.SendKeys("05/21/1970");

            Random random = new Random();
            int number = random.Next(100, 200);
            string email = "Svetlin" + number.ToString() + "@abv.bg";

            var emailAdrres = driver.FindElement(By.XPath("//input[@name='email_address']"));
            emailAdrres.SendKeys(email);
            Assert.That(emailAdrres.GetAttribute("value"), Is.EqualTo(email));

            var companyName = driver.FindElement(By.XPath("//input[@name='company']"));
            companyName.SendKeys("SD777");

            var address = driver.FindElement(By.XPath("//input[@name='street_address']"));
            address.SendKeys("KPSecond");

            var suburb = driver.FindElement(By.XPath("//input[@name='suburb']"));
            suburb.SendKeys("2");

            var postCode = driver.FindElement(By.XPath("//input[@name='postcode']"));
            postCode.SendKeys("1330");

            var city = driver.FindElement(By.XPath("//input[@name='city']"));
            city.SendKeys("Sofia");

            var state = driver.FindElement(By.XPath("//input[@name='state']"));
            state.SendKeys("SOF");

            new SelectElement(driver.FindElement(By.Name("country"))).SelectByValue("33");

            var phone = driver.FindElement(By.XPath("//input[@name='telephone']"));
            phone.SendKeys("0888999777");

            var fax = driver.FindElement(By.XPath("//input[@name='fax']"));
            fax.SendKeys("777");

            var newsLetter = driver.FindElement(By.XPath("//input[@name='newsletter']"));
            newsLetter.Click();
            Assert.That(newsLetter.Selected);

            var password = driver.FindElement(By.XPath("//input[@name='password']"));
            password.SendKeys("password");

            var confirmPassword = driver.FindElement(By.XPath("//input[@name='confirmation']"));
            confirmPassword.SendKeys("password");

            var nextButton = driver.FindElement(By.XPath("//span[text()='Continue']"));
            nextButton.Click();

            var confirmMesssage = driver.FindElement(By.TagName("h1"));
            Assert.That(confirmMesssage.Text, Is.EqualTo("Your Account Has Been Created!"));


            var logOff = driver.FindElement(By.XPath("//span[text()='Log Off']"));
            logOff.Click();

            var continueButt = driver.FindElement(By.XPath("//span[text()='Continue']"));
            continueButt.Click();


            Console.WriteLine($"User Acount Created with email:{email}");

        }



        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }


    }
}