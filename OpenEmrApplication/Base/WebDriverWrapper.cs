﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            driver = new ChromeDriver();
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