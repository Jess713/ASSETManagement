using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Customer
    {
        IWebDriver driver;

        string testName = "Charlie";
        string testUnitNum = "123";
        string testStreetAddress = "Forest Place";
        string testProvince = "BC";
        string testCountry = "Canada";
        string testPostalCode = "123456";

        string testNameUpdate = "Cold Beer";
        string testUnitNumUpdate = "456";
        string testStreetAddressUpdate = "Fried";
        string testProvinceUpdate = "Chicken";
        string testCountryUpdate = "Yummy";
        string testPostalCodeUpdate = "345678";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(MySetup.chromeDriverLocation);
        }


        [Test]
        public void aCreateCustomer()
        {
            // move to the homepage
            driver.Url = MySetup.serverUrl;

            // click the customer button 
            IWebElement customerBtn = driver.FindElement(By.LinkText("Customers"));
            customerBtn.Click();

            // click the create new button
            IWebElement createNewBtn = driver.FindElement(By.LinkText("Create New"));
            createNewBtn.Click();

            // Enter text to the box
            IWebElement nameInput = driver.FindElement(By.Id("Name"));
            IWebElement unitNumInput = driver.FindElement(By.Id("UnitNum"));
            IWebElement streetAddressInput = driver.FindElement(By.Id("StreetAddress"));
            IWebElement provinceInput = driver.FindElement(By.Id("Province"));
            IWebElement countryInput = driver.FindElement(By.Id("Country"));
            IWebElement postalCodeInput = driver.FindElement(By.Id("PostalCode"));

            nameInput.SendKeys(testName);
            unitNumInput.SendKeys(testUnitNum);
            streetAddressInput.SendKeys(testStreetAddress);
            provinceInput.SendKeys(testProvince);
            countryInput.SendKeys(testCountry);
            postalCodeInput.SendKeys(testPostalCode);

            // click create button
            IWebElement createBtn = driver.FindElement(By.CssSelector("input[type=\'submit\']"));
            createBtn.Click();

            // check the created customer
            Assert.IsTrue(driver.FindElement(By.XPath("//td[contains(text(), \'" + testName + "\')]")).Displayed);
        }

        [Test]
        public void bEditCustomer()
        {
            // move to the homepage
            driver.Url = MySetup.serverUrl;

            // click the customer button
            IWebElement customerBtn = driver.FindElement(By.LinkText("Customers"));
            customerBtn.Click();

            // click the edit button
            IWebElement createNewBtn = driver.FindElement(By.LinkText("Edit"));
            createNewBtn.Click();

            // Modify text in the box
            IWebElement nameInput = driver.FindElement(By.Id("Name"));
            IWebElement unitNumInput = driver.FindElement(By.Id("UnitNum"));
            IWebElement streetAddressInput = driver.FindElement(By.Id("StreetAddress"));
            IWebElement provinceInput = driver.FindElement(By.Id("Province"));
            IWebElement countryInput = driver.FindElement(By.Id("Country"));
            IWebElement postalCodeInput = driver.FindElement(By.Id("PostalCode"));

            nameInput.Clear();
            unitNumInput.Clear();
            streetAddressInput.Clear();
            provinceInput.Clear();
            countryInput.Clear();
            postalCodeInput.Clear();

            nameInput.SendKeys(testNameUpdate);
            unitNumInput.SendKeys(testUnitNumUpdate);
            streetAddressInput.SendKeys(testStreetAddressUpdate);
            provinceInput.SendKeys(testProvinceUpdate);
            countryInput.SendKeys(testCountryUpdate);
            postalCodeInput.SendKeys(testPostalCodeUpdate);

            IWebElement createBtn = driver.FindElement(By.CssSelector("input[type=\'submit\']"));
            createBtn.Click();

            Assert.IsTrue(driver.FindElement(By.XPath("//td[contains(text(), \'" + testNameUpdate + "\')]")).Displayed);
        }

        [Test]
        public void cDeleteCustomer()
        {
            // move to the homepage
            driver.Url = MySetup.serverUrl;

            // click the customer button
            IWebElement customerBtn = driver.FindElement(By.LinkText("Customers"));
            customerBtn.Click();

            // click the delete button 1
            IWebElement createNewBtn = driver.FindElement(By.LinkText("Delete"));
            createNewBtn.Click();

            // click the delete button 2
            IWebElement createBtn = driver.FindElement(By.CssSelector("input[type=\'submit\']"));
            createBtn.Click();

            Assert.IsTrue(driver.FindElements(By.XPath("//td[contains(text(), \'" + testNameUpdate + "\')]")).Count == 0);
        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
        }
    }
}
