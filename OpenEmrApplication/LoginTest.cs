using NUnit.Framework;
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
        [Test,Description("Valid Credential Test")]
        public void ValidCredentialTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "http://demo.openemr.io/b/openemr/interface/login/login.php?site=default";

            driver.FindElement(By.CssSelector("#authUser")).SendKeys("physician");
            driver.FindElement(By.Id("clearPass")).SendKeys("physician");
            SelectElement select = new SelectElement(driver.FindElement(By.Name("languageChoice")));
            select.SelectByText("English (Indian)");

            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Message = "Calendar text is not there";
            wait.Until(x => x.FindElement(By.XPath("//span[text()='Calendar']")));

            string actualValue = driver.Title;
            Assert.AreEqual("OpenEMR", actualValue);

            driver.Quit();
        }
    }
}
