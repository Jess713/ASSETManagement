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
    public class Appliances
    {
        IWebDriver driver;
        IWebElement btnHandler;
        //Name of the new appliance.
        string testName1 = "Test-Appliance1";
        string testName2 = "Test-Appliance1_Edited";


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(MySetup.chromeDriverLocation);
        }



        [Test]
        public void createAppliance()
        {
            


            driver.Url = MySetup.serverUrl;


            //Click the Appliances.
            btnHandler = driver.FindElement(By.LinkText("Appliances"));
            btnHandler.Click();

            //Click the Create New button on the appliances page.
            btnHandler = driver.FindElement(By.LinkText("Create New"));
            btnHandler.Click();

            //Type a new appliance name
            btnHandler = driver.FindElement(By.Id("ApplianceType"));
            btnHandler.SendKeys(testName1);


            //clicking 'create' button
            btnHandler= driver.FindElement(By.CssSelector("input[type=\'submit\']"));
            btnHandler.Click();

            //Check the created appliances.
            Assert.IsTrue(driver.FindElement(By.XPath("//td[contains(text(), \'" + testName1 + "\')]")).Displayed);

        }

        [Test]
        public void editAppliance()
        {

            //Mov to the main page
            driver.Url = MySetup.serverUrl;

            //Click the appliance
            btnHandler = driver.FindElement(By.LinkText("Appliances"));
            btnHandler.Click();

            //Click the Edit
            btnHandler = driver.FindElement(By.LinkText("Edit"));
            btnHandler.Click();


            IWebElement appliName = driver.FindElement(By.Id("ApplianceType"));
            //Clear the input field
            appliName.Clear();

            //Type the new name for edit
            appliName.SendKeys(testName2);


            //Click the Submit
            btnHandler = driver.FindElement(By.CssSelector("input[type=\'submit\']"));
            btnHandler.Click();

            Assert.IsTrue(driver.FindElement(By.XPath("//td[contains(text(), \'" + testName2 + "\')]")).Displayed);


        }

        [Test]

        public void deleteAppliances()
        {

            //Move to the main page
            driver.Url = MySetup.serverUrl;

            //Click the Appliances
            btnHandler = driver.FindElement(By.LinkText("Appliances"));
            btnHandler.Click();

            //Click the Delete
            btnHandler = driver.FindElement(By.LinkText("Delete"));
            btnHandler.Click();

            //Click the Submit after Delete btn
            btnHandler = driver.FindElement(By.CssSelector("input[type=\'submit\']"));
            btnHandler.Click();


            //Check if  the appliances deleted.
            Assert.IsTrue(driver.FindElements(By.XPath("//td[contains(text(), \'" + testName2
                + "\')]")).Count == 0);

        }
        public void Teardown()
        {
            driver.Close();
        }



    }
}
