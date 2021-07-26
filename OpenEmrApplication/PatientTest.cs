using NUnit.Framework;
using OpenEmrApplication.Base;
using OpenEmrApplication.Pages;
using OpenEmrApplication.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEmrApplication
{
    class PatientTest : WebDriverWrapper
    {
        [Test,TestCaseSource(typeof(TestCaseSourceUtils), "AddPatientData")]
        public void AddPatientTest(string username, string password, string language, string firstname, string lastname, 
            string DOB, string gender, string expectedAlert, string expectedPatientName)
        {
            LoginPage login = new LoginPage(driver);
            login.EnterUsername(username);
            login.EnterPassword(password);
            login.SelectLanguageByText(language);
            login.ClickOnSubmit();

            //DashboardPage
            DashboardPage dashboard = new DashboardPage(driver);
            dashboard.ClickOnPatientClient();
            driver.FindElement(By.XPath("//div[text()='Patients']")).Click();

            //PatientFinderPage
            driver.SwitchTo().Frame("fin");
            driver.FindElement(By.Id("create_patient_btn1")).Click();
            driver.SwitchTo().DefaultContent();

            //SearchOrAddPatientPage
            driver.SwitchTo().Frame("pat");

            driver.FindElement(By.Id("form_fname")).SendKeys(firstname);
            driver.FindElement(By.Id("form_lname")).SendKeys(lastname);
            driver.FindElement(By.Id("form_DOB")).SendKeys(DOB);
            SelectElement selectGender = new SelectElement(driver.FindElement(By.Id("form_sex")));
            selectGender.SelectByText(gender);
            driver.FindElement(By.Id("create")).Click();

            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame("modalframe");
            driver.FindElement(By.XPath("//input[@value='Confirm Create New Patient']")).Click();
            driver.SwitchTo().DefaultContent();

            //fluent wait
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(50);
            wait.PollingInterval = TimeSpan.FromSeconds(5);
            wait.IgnoreExceptionTypes(typeof(NoAlertPresentException));//ignore no alert exception

            string actualValueOfAlert = wait.Until(x => x.SwitchTo().Alert()).Text;
            Console.WriteLine(actualValueOfAlert);

            wait.Until(x => x.SwitchTo().Alert()).Accept();

            if (driver.FindElements(By.XPath("//div[@class='closeDlgIframe']")).Count > 0) // check element present or not
            {
                driver.FindElement(By.XPath("//div[@class='closeDlgIframe']")).Click();
            }


            //PatientDashboardPage

            //driver.SwitchTo().Frame("Pat");
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[contains(@src,'new.php')]")));

            String actualValueOfAddedPatient = driver.FindElement(By.XPath("//h2[contains(text(),'Medical')]")).Text;


            //should be present here
            Assert.IsTrue(actualValueOfAlert.Contains(expectedAlert));//given condition must be true otherwise method is failure

            Assert.AreEqual(expectedPatientName, actualValueOfAddedPatient);

        }
    }
}
