using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace naturdanmark_tests
{
    public class UnitTestRead
    {
        private static readonly string DriverDirectory = "C:\\webdrivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory);
            // _driver = new Firefox(DriverDirectory);
            // _driver = new MicrosoftEdge(DriverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void TestMethodMapPage()
        {

            _driver.Navigate()
                .GoToUrl("https://mapnaturetest324842390482903.azurewebsites.net/map.html"); // side med frontend
            System.Threading.Thread.Sleep(5000);

            Assert.AreEqual("NaturDanmark", _driver.Title);
        }

        [TestMethod]
        public void TestMethodReadPage()
        {

        }
    }
}
