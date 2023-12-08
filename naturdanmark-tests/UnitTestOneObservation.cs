using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFrontendTest
{
    [TestClass]
    public class UnitTestOneObservation
    {
        private static readonly string DriverDirectory = "C:\\webdrivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new FirefoxDriver(DriverDirectory);
            //_driver = new ChromeDriver(DriverDirectory);
            //_driver = new EdgeDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            //    _driver.Quit(); 
        }

        [TestMethod]
        public void ReadPage()
        {
            _driver.Navigate().
                GoToUrl("https://mapnaturetest324842390482903.azurewebsites.net/list/read/read.html");
            //string theTitle = "The observation";
            //Assert.AreEqual(theTitle, _driver.Title);

            Thread.Sleep(10000);

            IWebElement javascript = _driver.FindElement(By.Id("app"));
            string animalName = javascript.GetDomProperty("observation");
            Assert.AreEqual("Asiatic Black Bear", animalName);

            IWebElement userName = _driver.FindElement(By.Id("UserName"));
            Assert.AreEqual("User", userName);

            IWebElement theExactDate = _driver.FindElement(By.Id("Date"));
            Assert.AreEqual("2024-01-04", theExactDate);

            IWebElement theExactTime = _driver.FindElement(By.Id("Time"));
            Assert.AreEqual("10:10", theExactTime);

            System.Threading.Thread.Sleep(5000);
        }
    }
}
