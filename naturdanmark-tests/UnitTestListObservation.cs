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
            _driver.Navigate().GoToUrl("https://mapnaturetest324842390482903.azurewebsites.net/list/list.html");
            //string theTitle = "The observation";
            //Assert.AreEqual(theTitle, _driver.Title);

            System.Threading.Thread.Sleep(5000);


            IWebElement animaltable = _driver.FindElement(By.Id("app"));
            //Assert.IsTrue(animaltable.Text.Contains("User"));
            Assert.IsTrue(animaltable.Text.Contains("Asiatic Black Bear"));
            Assert.IsTrue(animaltable.Text.Contains("2024-01-04"));
            Assert.IsTrue(animaltable.Text.Contains("10:10"));

            
        }
    }
}
