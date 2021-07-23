using NUnit.Framework;
using OpenEmrApplication.Base;
using OpenEmrApplication.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEmrApplication
{
    class LoginTest : WebDriverWrapper
    {

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
