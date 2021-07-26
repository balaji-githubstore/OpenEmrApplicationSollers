using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEmrApplication.Base
{
    class WebDriverWrapper
    {
        protected IWebDriver driver;

        [SetUp]
        public void Initialization()
        {
            string browser = "firefox";

            switch(browser.ToLower())
            {
                case "ff":
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "ie":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "http://demo.openemr.io/b/openemr/interface/login/login.php?site=default";
        }

        [TearDown]
        public void EndBrowser()
        {

            driver.Quit();
        }
    }
}
