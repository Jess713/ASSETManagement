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


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(MySetup.chromeDriverLocation);
        }


        [Test]
        public void createAsset()
        {

            string testName = "room 306";
      
            int testAskingRent= 1200;
            int testUnitNum= 306;
            string testStreetAddress= "1534 Willingdon Ave";
            string testProvince = "Burnaby";

            string testCountry= "Canada";
            string testPostalCode= "V4J1WK";

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

            nameInput.SendKeys(testName);

            // select by text
            selectElement.SelectByText("Room");
            askingRent.SendKeys(testAskingRent.ToString());
            unitNum.SendKeys(testUnitNum.ToString());
            streetAddress.SendKeys(testStreetAddress);
            province.SendKeys(testProvince);
            country.SendKeys(testCountry);
            postalCode.SendKeys(testPostalCode);

            // click create button
            IWebElement createBtn = driver.FindElement(By.CssSelector("input[type=\'submit\']"));
            createBtn.Click();

            // check the created asset
            Assert.IsTrue(driver.FindElement(By.XPath("//td[contains(text(), \'" + testName + "\')]")).Displayed);

        }

        [Test]
        public void assignAssetToCustomer()
        {

            string testName = "room 306";

            int testAskingRent = 1200;
            int testUnitNum = 306;
            string testStreetAddress = "1534 Willingdon Ave";
            string testProvince = "Burnaby";

            string testCountry = "Canada";
            string testPostalCode = "V4J1WK";

            // move to the homepage
            driver.Url = MySetup.serverUrl;

            // click the customer button 
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

            nameInput.SendKeys(testName);

            // select by text
            selectElement.SelectByText("Room");
            askingRent.SendKeys(testAskingRent.ToString());
            unitNum.SendKeys(testUnitNum.ToString());
            streetAddress.SendKeys(testStreetAddress);
            province.SendKeys(testProvince);
            country.SendKeys(testCountry);
            postalCode.SendKeys(testPostalCode);

            // click create button
            IWebElement createBtn = driver.FindElement(By.CssSelector("input[type=\'submit\']"));
            createBtn.Click();

            // check the created asset
            Assert.IsTrue(driver.FindElement(By.XPath("//td[contains(text(), \'" + testName + "\')]")).Displayed);



            string testName2 = "Charlie";
            string testUnitNum2 = "123";
            string testStreetAddress2 = "Forest Place";
            string testProvince2 = "BC";
            string testCountry2 = "Canada";
            string testPostalCode2 = "123 456";

            string testNameUpdate = "Cold Beer";
            string testUnitNumUpdate = "456";
            string testStreetAddressUpdate = "Fried";
            string testProvinceUpdate = "Chicken";
            string testCountryUpdate = "Yummy";
            string testPostalCodeUpdate = "345 678";
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

            nameInput2.SendKeys(testName2);
            unitNumInput2.SendKeys(testUnitNum2);
            streetAddressInput2.SendKeys(testStreetAddress2);
            provinceInput2.SendKeys(testProvince2);
            countryInput2.SendKeys(testCountry2);
            postalCodeInput2.SendKeys(testPostalCode2);

            // click create button
            IWebElement createBtn2 = driver.FindElement(By.CssSelector("input[type=\'submit\']"));
            createBtn2.Click();

            // check the created customer
            Assert.IsTrue(driver.FindElement(By.XPath("//td[contains(text(), \'" + testName2 + "\')]")).Displayed);


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
            selectElement2.SelectByText("room 306");
       
            IWebElement startdate = driver.FindElement(By.XPath("//form//input[@name='StartDate']"));
            //Fill date as format, ie, MM/dd/yyyy
            startdate.SendKeys("20200410");
            startdate.Submit();

            IWebElement enddate = driver.FindElement(By.XPath("//form//input[@name='EndDate']"));
            //Fill date as format, ie, MM/dd/yyyy
            enddate.SendKeys("20200510");
            enddate.Submit();

            string details = "room detail of room 306";

            //-------------------
            Testing for asset.cs error ( Not able to find the ID ' Details ')

           IWebElement detail = driver.FindElement(By.Id("Details"));
            detail.SendKeys(details);
            -------------------


            // click create button
            IWebElement createBtn3 = driver.FindElement(By.CssSelector("input[type=\'submit\']"));
            createBtn3.Click();

            // check the created occupancy-----------------------



            // click the customer button 
            IWebElement goOccupancy = driver.FindElement(By.LinkText("Occupancies"));
            goOccupancy.Click();

            Assert.IsTrue(driver.FindElement(By.XPath("//td[contains(text(), \'" + testName2 + "\')]")).Displayed);
        }


        [TearDown]
        public void Teardown()
        {
            driver.Close();
        }
    }
}
