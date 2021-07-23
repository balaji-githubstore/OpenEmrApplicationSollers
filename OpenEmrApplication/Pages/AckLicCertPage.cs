using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEmrApplication.Pages
{
    class AckLicCertPage
    {
        private IWebDriver driver;
        public AckLicCertPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetPageSource()
        {
            return driver.PageSource;
        }
    }
}
