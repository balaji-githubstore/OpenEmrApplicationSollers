using NUnit.Framework;
using OpenEmrApplication.Base;
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
            string actualHeader = driver.FindElement(By.TagName("h1")).Text;
            string actualVersion = driver.FindElement(By.TagName("h4")).Text;

            Assert.AreEqual(expectedHeader, actualHeader, "Assertion on header");
            Assert.AreEqual(expectedVersion, actualVersion, "Assertion on version");

        }
    }
}
