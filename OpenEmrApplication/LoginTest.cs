using NUnit.Framework;
using OpenEmrApplication.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEmrApplication
{
    class LoginTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Initialization()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "http://demo.openemr.io/b/openemr/interface/login/login.php?site=default";
        }

        [TearDown]
        public void EndBrowser()
        {
            driver.Quit();
        }


        [Test]
        public void InvalidCredentialTest()
        {
            LoginPage login = new LoginPage(driver);
            login.EnterUsername("admin123");
            login.EnterPassword("pass");
            login.SelectLanguageByText("Dutch");
            login.ClickOnSubmit();

            Assert.AreEqual("Invalid username or password", login.GetErrorMessage());
        }


        [Test,Description("Valid Credential Test")]
        public void ValidCredentialTest()
        {
            LoginPage login = new LoginPage(driver);
            login.EnterUsername("admin");
            login.EnterPassword("pass");
            login.SelectLanguageByText("English (Indian)");
            login.ClickOnSubmit();

            DashboardPage dashboard = new DashboardPage(driver);
            dashboard.WaitForPresenceOfCalendar();

            Assert.AreEqual("OpenEMR", dashboard.GetTitle());
        }
    }
}
