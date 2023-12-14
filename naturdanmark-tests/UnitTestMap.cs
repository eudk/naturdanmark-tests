using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

using System;

namespace MusicFrontendTest
{
    [TestClass]
    public class UnitTestMap
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
        public void TestMethodMapPage()
        {
            _driver.Navigate()
                .GoToUrl("https://mapnaturetest324842390482903.azurewebsites.net/map.html"); // side med frontend
            System.Threading.Thread.Sleep(5000);

            Assert.AreEqual("NaturDanmark", _driver.Title);
            //_driver.FindElement(By.ClassName("Add")).Click();

            // Wait for the new page 
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(driver =>
                ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState")
                .Equals("complete")); // videre til ny side vent paa at siden er loadet
            // 5 sec pause
            System.Threading.Thread.Sleep(5000);
        }
    }
}

