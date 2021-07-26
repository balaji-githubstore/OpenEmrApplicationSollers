using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEmrApplication.Pages
{
    class AboutOpenEMRPage
    {
        private string mscFrameName = "msc";
        private By headerLocator = By.TagName("h1");
        private By versionLocator = By.TagName("h4");

        private IWebDriver driver;
        public AboutOpenEMRPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SwitchToMSCFrame()
        {
            driver.SwitchTo().Frame(mscFrameName);
        }

        public string GetHeaderDetail()
        {
            return driver.FindElement(headerLocator).Text.Trim();
        }

        public string GetVersionDetail()
        {
            return driver.FindElement(versionLocator).Text.Trim();
        }
    }
}
