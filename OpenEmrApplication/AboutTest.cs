using AutomationWrapper.Base;
using NUnit.Framework;
using OpenEmrApplication.Pages;
using OpenEmrApplication.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEmrApplication
{
    class AboutTest : WebDriverWrapper
    {
        [Test,TestCaseSource(typeof(TestCaseSourceUtils), "AboutUsHeaderAndVersionData")]
        public void AboutUsHeaderAndVersionTest(string username, string password, string language,string expectedHeader,string expectedVersion)
        {
            LoginPage login = new LoginPage(driver);
            login.EnterUsername(username);
            login.EnterPassword(password);
            login.SelectLanguageByText(language);
            login.ClickOnSubmit();

            DashboardPage dashboard = new DashboardPage(driver);
            dashboard.ClickOnAbout();

            AboutOpenEMRPage about = new AboutOpenEMRPage(driver);
            about.SwitchToMSCFrame();

            Assert.AreEqual(expectedHeader, about.GetHeaderDetail(), "Assertion on header");
            Assert.AreEqual(expectedVersion, about.GetVersionDetail(), "Assertion on version");

        }
    }
}
