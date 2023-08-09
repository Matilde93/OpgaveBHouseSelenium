using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace EksamenSelenium
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\Users\\matil\\WebDrivers";
        private static IWebDriver _driver;
        

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory);
            _driver.Navigate().GoToUrl("http://127.0.0.1:5500/index.html");
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TitleTest()
        {

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            string title = _driver.Title;
            Assert.AreEqual("Eksamen", title);

            IWebElement table = wait.Until(d => d.FindElement(By.Id("table")));
            Assert.IsTrue(table.Text.Contains("Birkelunden"));


            ReadOnlyCollection<IWebElement> listElements = _driver.FindElements(By.Id("table"));
            Assert.AreNotEqual(3, listElements.Count);


        }

        [TestMethod]
        public void InputTest()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            IWebElement inputAddress = _driver.FindElement(By.Id("address"));
            inputAddress.SendKeys("Matilde Test, Roskilde");
            IWebElement inputYear = _driver.FindElement(By.Id("year"));
            inputYear.SendKeys("2023");
            IWebElement button = _driver.FindElement(By.Id("addButton"));
            button.Click();


            Thread.Sleep(3000);
            IWebElement table = wait.Until(d => d.FindElement(By.Id("table")));
            Assert.IsTrue(table.Text.Contains("Matilde Test, Roskilde"));

        }


        [TestMethod]
        public void ContainsTest()
        {

            ReadOnlyCollection<IWebElement> listElements = _driver.FindElements(By.Id("table"));
            Assert.AreNotEqual(3, listElements.Count);


        }



    }
}