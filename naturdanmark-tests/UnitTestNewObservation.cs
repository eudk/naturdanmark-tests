using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace MusicFrontendTest
{
    [TestClass]
    public class UnitTestNewObservation
    {
        private static readonly string DriverDirectory = "C:\\webdrivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory);
            //_driver = new FirefoxDriver(DriverDirectory);
            //_driver = new EdgeDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            //    _driver.Quit(); 
        }

        [TestMethod]
        public void TestMethodObservationPage()
        {
            _driver.Navigate()
                .GoToUrl("https://mapnaturetest324842390482903.azurewebsites.net/observation/observation.html");

            string expectedTitle = "New Observation";
            Assert.AreEqual(expectedTitle, _driver.Title);


            // name input
            IWebElement nameInput = _driver.FindElement(By.Id("name"));
            nameInput.SendKeys("TESTER");

            // Manual location
            IWebElement locationToggleMap = _driver.FindElement(By.Id("locationToggleMap"));
            locationToggleMap.Click();

            IWebElement animalSearchInput = _driver.FindElement(By.Id("animalSearch"));
            animalSearchInput.SendKeys("Lion");

            // Manual date
            IWebElement dateInput = _driver.FindElement(By.Id("date"));
            dateInput.Clear();
            dateInput.SendKeys("2023-11-01");

            // Manual time
            IWebElement timeInput = _driver.FindElement(By.Id("time"));
            timeInput.Clear();
            timeInput.SendKeys("14:30");


            //  System.Threading.Thread.Sleep(5000);


            IWebElement searchButton = _driver.FindElement(By.Id("animalSearchBtn"));
            searchButton.Click();


            System.Threading.Thread.Sleep(5000); // wait for the API

            // dropdown
            SelectElement animalDropdown = new SelectElement(_driver.FindElement(By.Id("animalSeen")));
            animalDropdown.SelectByIndex(1);
            IWebElement descriptionTextarea = _driver.FindElement(By.Id("note"));
            descriptionTextarea.SendKeys("UI test, this Observation can be deleted! (Selenium)");

            // Submit form
            IWebElement submitButton = _driver.FindElement(By.Id("submitBtn"));
            submitButton.Click();

            Console.WriteLine("Test completed.");
        }
    }
}
