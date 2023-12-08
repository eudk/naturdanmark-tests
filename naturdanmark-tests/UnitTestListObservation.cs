using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFrontendTest
{
    [TestClass]
    public class UnitTestListObservation
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
        public void ReadPageList()
        {
            _driver.Navigate().GoToUrl("https://127.0.0.1:5500/list/list.html");
            //string theTitle = "The observation";
            //Assert.AreEqual(theTitle, _driver.Title);


            IWebElement animaltable = _driver.FindElement(By.Id("animaltable"));
            Assert.IsTrue(animaltable.Text.Contains("Asiatic Black Bear"));

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
