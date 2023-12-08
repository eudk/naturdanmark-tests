using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace naturdanmark_tests
{
    public class UnitTestReadList
    {
        private static readonly string DriverDirectory = "C:\\webdrivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new FirefoxDriver(DriverDirectory);
            // _driver = new ChromeDriver(DriverDirectory);
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
            string theTitle = "The observation";
            Assert.AreEqual(theTitle, _driver.Title);


            IWebElement animalName = _driver.FindElement(By.Id("AnimalName"));
            animalName.SendKeys("Dog");

            IWebElement userName = _driver.FindElement(By.Id("UserName"));
            userName.SendKeys("Hans");

            IWebElement theExactDate = _driver.FindElement(By.Id("Date"));
            theExactDate.SendKeys("2023-10-05");

            IWebElement theExactTime = _driver.FindElement(By.Id("Time"));
            theExactTime.SendKeys("10:40");

            System.Threading.Thread.Sleep(5000);
        }
    }
}
