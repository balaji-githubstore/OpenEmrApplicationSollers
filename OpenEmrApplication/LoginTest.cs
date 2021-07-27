using AutomationWrapper.Base;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenEmrApplication.Pages;
using OpenEmrApplication.Utilities;


namespace OpenEmrApplication
{
    class LoginTest : WebDriverWrapper
    {

        [Test]
        public void AcknowledgmentsLicensingCertificationLinkTest()
        {
            LoginPage login = new LoginPage(driver);
            login.ClickOnAcknowledgmentsLicensingCertification();

            login.switchToAcknowledgmentsLicensingCertificationTab();
            AckLicCertPage ack = new AckLicCertPage(driver);
            Assert.IsTrue(ack.GetPageSource().Contains("License information"), "Assertion using page contains License information");

        }

        [Test,TestCaseSource(typeof(TestCaseSourceUtils), "InvalidCredentialData")]
       // [TestCase("john","john123","Dutch","Invalid username or password")]
       // [TestCase("Peter", "Perter123", "Danish", "Invalid username or password")]
        public void InvalidCredentialTest(string username,string password,string language,string expectedValue)
        {
            LoginPage login = new LoginPage(driver);
            login.EnterUsername(username);
            login.EnterPassword(password);
            login.SelectLanguageByText(language);
            login.ClickOnSubmit();

            Assert.AreEqual(expectedValue, login.GetErrorMessage());
        }


        [Test,Description("Valid Credential Test"),TestCaseSource(typeof(TestCaseSourceUtils), "ValidCredentialData")]
        public void ValidCredentialTest(string username,string password, string language, string expectedValue)
        {
            test.Log(Status.Info, "valid credential test started for " + username);

            LoginPage login = new LoginPage(driver);

            login.EnterUsername(username);
            test.Log(Status.Info, "Username entered as " + username);

            login.EnterPassword(password);
            test.Log(Status.Info, "Password entered as " + password);

            login.SelectLanguageByText(language);
           
            test.Log(Status.Info, "Language selected as " + language);

            login.ClickOnSubmit();
            test.Log(Status.Info, "Clicked on login");

            DashboardPage dashboard = new DashboardPage(driver);
            dashboard.WaitForPresenceOfCalendar();

            Assert.AreEqual(expectedValue, dashboard.GetTitle());

            test.Log(Status.Info, "valid credential completed for " + username);

        }
    }
}
