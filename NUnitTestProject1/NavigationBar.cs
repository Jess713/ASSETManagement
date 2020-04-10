using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Collections.ObjectModel;

namespace Test
{
    public class NavigationBar
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(MySetup.chromeDriverLocation);
        }

        [Test]
        public void NavigateToCustomer()
        {
            // move to the homepage
            driver.Url = MySetup.serverUrl;

            // click the customer button 
            IWebElement customerBtn = driver.FindElement(By.LinkText("Customers"));
            customerBtn.Click();

            // verify that user is redirect to the customer list view
            IWebElement indexLabel = driver.FindElement(By.CssSelector("h2"));
            Assert.AreEqual(indexLabel.Text, "Index");

            // check the list of table heads
            ReadOnlyCollection<IWebElement> tableHeads = driver.FindElements(By.CssSelector("th"));
            Assert.AreEqual(tableHeads[0].Text, "Name");
        }

        [Test]
        public void NavigateToAsset()
        {
            // move to the homepage
            driver.Url = "http://localhost:3000";

            // click the customer button 
            IWebElement customerBtn = driver.FindElement(By.LinkText("Assets"));
            customerBtn.Click();

            // verify that user is redirect to the customer list view
            IWebElement indexLabel = driver.FindElement(By.CssSelector("h2"));
            Assert.AreEqual(indexLabel.Text, "Index");

            // check the list of table heads
            ReadOnlyCollection<IWebElement> tableHeads = driver.FindElements(By.CssSelector("th"));
            Assert.AreEqual(tableHeads[0].Text, "Name");
            Assert.AreEqual(tableHeads[1].Text, "Type");
            Assert.AreEqual(tableHeads[2].Text, "Address");
            Assert.AreEqual(tableHeads[3].Text, "Current Occupant");
        }

    [Test]
        public void NavigateToAppliance()
        {
            // move to the homepage
            driver.Url = "http://localhost:3000";

            // click the customer button 
            IWebElement customerBtn = driver.FindElement(By.LinkText("Appliances"));
            customerBtn.Click();

            // verify that user is redirect to the customer list view
            IWebElement indexLabel = driver.FindElement(By.CssSelector("h2"));
            Assert.AreEqual(indexLabel.Text, "Index");

            // check the list of table heads
            ReadOnlyCollection<IWebElement> tableHeads = driver.FindElements(By.CssSelector("th"));
            Assert.AreEqual(tableHeads[0].Text, "ApplianceType");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
        }
    }
}