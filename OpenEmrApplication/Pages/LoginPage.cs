﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEmrApplication.Pages
{
    class LoginPage
    {
        private By usernameLocator = By.CssSelector("#authUser");
        private By passwordLocator = By.Id("clearPass");
        private By languageLocator = By.Name("languageChoice");
        private By submitLocator = By.XPath("//button[@type='submit']");
        private By applicationdescLocator = By.XPath("//p[contains(text(),'most')]");
        private By acknowledgmentsLocator = By.PartialLinkText("Acknowledgments");
        private By errorLocator = By.XPath("//div[contains(text(),'Invalid')]");

        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnterUsername(string username)
        {
            driver.FindElement(usernameLocator).SendKeys(username);
        }
        public void EnterPassword(string password)
        {
            driver.FindElement(passwordLocator).SendKeys(password);
        }

        public void SelectLanguageByText(string language)
        {
            SelectElement select = new SelectElement(driver.FindElement(languageLocator));
            select.SelectByText(language) ;
        }

        public void ClickOnSubmit()
        {
            driver.FindElement(submitLocator).Click();
        }
        public string GetApplicationDescription()
        {
            return driver.FindElement(applicationdescLocator).Text;
        }
        public void ClickOnAcknowledgmentsLicensingCertification()
        {
            driver.FindElement(acknowledgmentsLocator).Click();
        }

        public string GetErrorMessage()
        {
            return driver.FindElement(errorLocator).Text.Trim();
        }
    }
}
