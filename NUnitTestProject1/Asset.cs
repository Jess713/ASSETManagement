using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Asset
    {
        IWebDriver driver;

        string testNameCustomer = "Charlie";
        string testUnitNumCustomer = "123";
        string testStreetAddressCustomer = "Forest Place";
        string testProvinceCustomer = "BC";
        string testCountryCustomer = "Canada";
        string testPostalCodeCustomer = "123456";

        string testNameCustomerUpdate = "Cold Beer";
        string testUnitNumCustomerUpdate = "456";
        string testStreetAddressCustomerUpdate = "Fried";
        string testProvinceCustomerUpdate = "Chicken";
        string testCountryCustomerUpdate = "Yummy";
        string testPostalCodeCustomerUpdate = "345678";

        string testNameAsset = "room 306";
        int testAskingRentAsset = 1200;
        int testUnitNumAsset = 306;
        string testStreetAddressAsset = "1534 Willingdon Ave";
        string testProvinceAsset = "Burnaby";
        string testCountryAsset = "Canada";
        string testPostalCodeAsset = "V4J1WK";

        string testNameAssetUpdate = "room 1907";
        int testAskingRentAssetUpdate = 1700;
        int testUnitNumAssetUpdate = 23;
        string testStreetAddressAssetUpdate = "Waterfront";
        string testProvinceAssetUpdate = "Vancouver";
        string testCountryAssetUpdate = "Canada";
        string testPostalCodeAssetUpdate = "ABCDER";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(MySetup.chromeDriverLocation);
        }

        [Test]
        public void aCreateAsset()
        {
            // move to the homepage
            driver.Url = MySetup.serverUrl;

            // click the Assets button 
            IWebElement assetBtn = driver.FindElement(By.LinkText("Assets"));
            assetBtn.Click();

            // click the create new button
            IWebElement createNewBtn = driver.FindElement(By.LinkText("Create Asset"));
            createNewBtn.Click();

            // Enter text to the box
            IWebElement nameInput = driver.FindElement(By.Id("Name"));
            // select the drop down list
            var dropdownType = driver.FindElement(By.Name("Type"));
            IWebElement askingRent = driver.FindElement(By.Id("AskingRent"));
            IWebElement unitNum = driver.FindElement(By.Id("UnitNum"));
            IWebElement streetAddress = driver.FindElement(By.Id("StreetAddress"));
            IWebElement province = driver.FindElement(By.Id("Province"));
            IWebElement country = driver.FindElement(By.Id("Country"));
            IWebElement postalCode = driver.FindElement(By.Id("PostalCode"));

            //create select element object 
            var selectElement = new SelectElement(dropdownType);

            nameInput.SendKeys(testNameAsset);

            // select by text
            selectElement.SelectByText("Room");
            askingRent.SendKeys(testAskingRentAsset.ToString());
            unitNum.SendKeys(testUnitNumAsset.ToString());
            streetAddress.SendKeys(testStreetAddressAsset);
            province.SendKeys(testProvinceAsset);
            country.SendKeys(testCountryAsset);
            postalCode.SendKeys(testPostalCodeAsset);

            // click create button
            IWebElement createBtn = driver.FindElement(By.CssSelector("input[type=\'submit\']"));
            createBtn.Click();

            // check the created asset
            Assert.IsTrue(driver.FindElement(By.XPath("//td[contains(text(), \'" + testNameAsset + "\')]")).Displayed);
        }

        [Test]
        public void bAssignAssetToCustomer()
        {
            // move to the homepage
            driver.Url = MySetup.serverUrl;

            // click the customer button 
            IWebElement customerBtn = driver.FindElement(By.LinkText("Customers"));
            customerBtn.Click();

            // click the create new button
            IWebElement createNewBtn2 = driver.FindElement(By.LinkText("Create New"));
            createNewBtn2.Click();

            // Enter text to the box
            IWebElement nameInput2 = driver.FindElement(By.Id("Name"));
            IWebElement unitNumInput2 = driver.FindElement(By.Id("UnitNum"));
            IWebElement streetAddressInput2 = driver.FindElement(By.Id("StreetAddress"));
            IWebElement provinceInput2 = driver.FindElement(By.Id("Province"));
            IWebElement countryInput2 = driver.FindElement(By.Id("Country"));
            IWebElement postalCodeInput2 = driver.FindElement(By.Id("PostalCode"));

            nameInput2.SendKeys(testNameCustomer);
            unitNumInput2.SendKeys(testUnitNumCustomer);
            streetAddressInput2.SendKeys(testStreetAddressCustomer);
            provinceInput2.SendKeys(testProvinceCustomer);
            countryInput2.SendKeys(testCountryCustomer);
            postalCodeInput2.SendKeys(testPostalCodeCustomer);

            // click create button
            IWebElement createBtn2 = driver.FindElement(By.CssSelector("input[type=\'submit\']"));
            createBtn2.Click();

            // check the created customer
            Assert.IsTrue(driver.FindElement(By.XPath("//td[contains(text(), \'" + testNameCustomer + "\')]")).Displayed);

            IWebElement assignAssetBtn = driver.FindElement(By.Id("assign-asset"));
            assignAssetBtn.Click();

            // Assign the new asset created-----------------------------
            IWebElement addasset = driver.FindElement(By.LinkText("Add Asset"));
            addasset.Click();

            // select the drop down list
            var dropdownAssets= driver.FindElement(By.Name("AssetID"));
            //create select element object 
            var selectElement2 = new SelectElement(dropdownAssets);

            // select by text
            selectElement2.SelectByText(testNameAsset);
       
            IWebElement startdate = driver.FindElement(By.XPath("//form//input[@name='StartDate']"));
            startdate.SendKeys("002020/01/01");

            IWebElement enddate = driver.FindElement(By.XPath("//form//input[@name='EndDate']"));
            enddate.SendKeys("002020/04/01");

            string details = "room detail of room 306";

            IWebElement detail = driver.FindElement(By.Id("Details"));
            detail.SendKeys(details);
       
            // click create button
            IWebElement createBtn3 = driver.FindElement(By.CssSelector("input[type=\'submit\']"));
            createBtn3.Click();

            // check the created occupancy-----------------------

            // click the customer button 
            IWebElement goOccupancy = driver.FindElement(By.LinkText("Occupancies"));
            goOccupancy.Click();

            Assert.IsTrue(driver.FindElement(By.XPath("//td[contains(text(), \'" + testNameCustomer + "\')]")).Displayed);
        }

        [Test]
        public void cEditAsset()
        {
            // move to the homepage
            driver.Url = MySetup.serverUrl;

            // click the assets buton
            IWebElement customerBtn = driver.FindElement(By.LinkText("Assets"));
            customerBtn.Click();

            // click the edit button
            IWebElement createNewBtn = driver.FindElement(By.LinkText("Edit"));
            createNewBtn.Click();

            IWebElement nameInput = driver.FindElement(By.Id("Name"));
            var dropdownType = driver.FindElement(By.Name("Type"));
            var selectElement = new SelectElement(dropdownType);
            IWebElement askingRent = driver.FindElement(By.Id("AskingRent"));
            IWebElement unitNum = driver.FindElement(By.Id("UnitNum"));
            IWebElement streetAddress = driver.FindElement(By.Id("StreetAddress"));
            IWebElement province = driver.FindElement(By.Id("Province"));
            IWebElement country = driver.FindElement(By.Id("Country"));
            IWebElement postalCode = driver.FindElement(By.Id("PostalCode"));

            nameInput.Clear();
            askingRent.Clear();
            unitNum.Clear();
            streetAddress.Clear();
            province.Clear();
            country.Clear();
            postalCode.Clear();

            nameInput.SendKeys(testNameAssetUpdate);
            selectElement.SelectByText("Room");
            askingRent.SendKeys(testAskingRentAssetUpdate.ToString());
            unitNum.SendKeys(testUnitNumAssetUpdate.ToString());
            streetAddress.SendKeys(testStreetAddressAssetUpdate);
            province.SendKeys(testProvinceAssetUpdate);
            country.SendKeys(testCountryAssetUpdate);
            postalCode.SendKeys(testPostalCodeAssetUpdate);

            IWebElement createBtn = driver.FindElement(By.CssSelector("input[type=\'submit\']"));
            createBtn.Click();

            Assert.IsTrue(driver.FindElement(By.XPath("//td[contains(text(), \'" + testNameAssetUpdate + "\')]")).Displayed);
        }

        [Test]
        public void dDeleteAsset()
        {
            // move to the homepage
            driver.Url = MySetup.serverUrl;

            // click the assets button
            IWebElement customerBtn = driver.FindElement(By.LinkText("Assets"));
            customerBtn.Click();

            // click the delete button 1
            IWebElement createNewBtn = driver.FindElement(By.LinkText("Delete"));
            createNewBtn.Click();

            // click the delete button 2
            IWebElement createBtn = driver.FindElement(By.CssSelector("input[type=\'submit\']"));
            createBtn.Click();

            Assert.IsTrue(driver.FindElements(By.XPath("//td[contains(text(), \'" + testNameAssetUpdate + "\')]")).Count == 0);
        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
        }
    }
}
