using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace MusicFrontendTest
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\webdrivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new FirefoxDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            //    _driver.Quit(); 
        }

        [TestMethod]
        public void TestMethodMapPage()
        {
            _driver.Navigate().GoToUrl("https://mapnaturetest324842390482903.azurewebsites.net/map.html"); // side med frontend
            Assert.AreEqual("NaturDanmark", _driver.Title);

            IWebElement observationButton = _driver.FindElement(By.CssSelector("div#buttons-container a.btn-success"));
            observationButton.Click();

            // Wait for the new page 
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete")); // videre til ny side vent paa at siden er loadet
            // 5 sec pause
            System.Threading.Thread.Sleep(5000);
        }

        [TestMethod]
        public void TestMethodObservationPage()
        {
            string expectedTitle = "Ny Observation";
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
            dateInput.SendKeys("2023-12-01");

            // Manual time
            IWebElement timeInput = _driver.FindElement(By.Id("time"));
            timeInput.Clear();
            timeInput.SendKeys("14:30");


            System.Threading.Thread.Sleep(500);

            //

            // problemer efter dette punkt nok APIen eller manglende ID???


            IWebElement searchButton = _driver.FindElement(By.CssSelector("button[onclick='searchAnimal()']")); // fejl her
            searchButton.Click();

            System.Threading.Thread.Sleep(5000); // vent paa api

            //  dropdown
            SelectElement animalDropdown = new SelectElement(_driver.FindElement(By.Id("animalSeen")));
            animalDropdown.SelectByIndex(1);

            // Submit form
            IWebElement submitButton = _driver.FindElement(By.CssSelector("button[type='submit']"));
            submitButton.Click();


            Console.WriteLine("Test completed.");
        }

    }
}
