using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Authentication
    {
        IWebDriver driver;
        
        string correctEmail = "horololoro@foomail.com";
        string correctPwd = "Foo1234!";
        string incorrectEmail = "porololoro@foomail.com";
        string incorrectPwd = "foo1234";
        string loginErrorMsg = "Invalid login attempt.";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(MySetup.chromeDriverLocation);
        }

        [Test]
        public void aLoginWithCorrectIdPwd()
        {
            // move to the login page
            driver.Url = MySetup.deployUrl;

            // find elements to enter id and password 
            IWebElement emailField = driver.FindElement(By.Id("Email"));
            IWebElement pwdField = driver.FindElement(By.Id("Password"));

            // enter id and password
            emailField.SendKeys(correctEmail);
            pwdField.SendKeys(correctPwd);
           
            // click login button
            IWebElement createBtn = driver.FindElement(By.CssSelector("input[type=\'submit\']"));
            createBtn.Click();

            // check the result
            Assert.IsTrue(driver.FindElement(By.XPath("//a[contains(text(), \'" + correctEmail + "\')]")).Displayed);
        }

        [Test]
        public void bLoginWithIncorrectId()
        {
            // move to the login page
            driver.Url = MySetup.deployUrl;

            // find elements to enter id and password 
            IWebElement emailField = driver.FindElement(By.Id("Email"));
            IWebElement pwdField = driver.FindElement(By.Id("Password"));

            // enter id and password
            emailField.SendKeys(incorrectEmail);
            pwdField.SendKeys(correctPwd);

            // click login button
            IWebElement createBtn = driver.FindElement(By.CssSelector("input[type=\'submit\']"));
            createBtn.Click();

            // check the login error message
            Assert.IsTrue(driver.FindElement(By.XPath("//li[contains(text(), \'" + loginErrorMsg + "\')]")).Displayed);
        }

        [Test]
        public void cLoginWithIncorrectPwd()
        {
            // move to the login page
            driver.Url = MySetup.deployUrl;

            // find elements to enter id and password 
            IWebElement emailField = driver.FindElement(By.Id("Email"));
            IWebElement pwdField = driver.FindElement(By.Id("Password"));

            // enter id and password
            emailField.SendKeys(correctEmail);
            pwdField.SendKeys(incorrectPwd);

            // click login button
            IWebElement createBtn = driver.FindElement(By.CssSelector("input[type=\'submit\']"));
            createBtn.Click();

            // check the result
            // check the login error message
            Assert.IsTrue(driver.FindElement(By.XPath("//li[contains(text(), \'" + loginErrorMsg + "\')]")).Displayed);
        }

        [Test]
        public void dLoginWithIncorrectIdPwd()
        {
            // move to the login page
            driver.Url = MySetup.deployUrl;

            // find elements to enter id and password 
            IWebElement emailField = driver.FindElement(By.Id("Email"));
            IWebElement pwdField = driver.FindElement(By.Id("Password"));

            // enter id and password
            emailField.SendKeys(incorrectEmail);
            pwdField.SendKeys(incorrectPwd);

            // click login button
            IWebElement createBtn = driver.FindElement(By.CssSelector("input[type=\'submit\']"));
            createBtn.Click();

            // check the result
            // check the login error message
            Assert.IsTrue(driver.FindElement(By.XPath("//li[contains(text(), \'" + loginErrorMsg + "\')]")).Displayed);
        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
        }
    }
}
