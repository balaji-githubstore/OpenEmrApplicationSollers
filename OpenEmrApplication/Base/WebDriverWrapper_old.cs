//using NUnit.Framework;
//using OpenEmrApplication.Utilities;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.IE;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace OpenEmrApplication.Base
//{
//    class WebDriverWrapper_old
//    {
//        protected IWebDriver driver;

//        [SetUp]
//        public void Initialization()
//        {
//            string browser = JsonUtils.GetValue(@"D:\B-Mine\Company\Company\Sollers\OpenEmrApplication\OpenEmrApplication\TestData\data.json", "browser");

//            switch(browser.ToLower())
//            {
//                case "ff":
//                case "firefox":
//                    driver = new FirefoxDriver();
//                    break;
//                case "ie":
//                    driver = new InternetExplorerDriver();
//                    break;
//                default:
//                    driver = new ChromeDriver();
//                    break;
//            }

//            driver.Manage().Window.Maximize();
//            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
//            string baseUrl= JsonUtils.GetValue(@"D:\B-Mine\Company\Company\Sollers\OpenEmrApplication\OpenEmrApplication\TestData\data.json", "url");
//            driver.Url = baseUrl;
//        }

//        [TearDown]
//        public void EndBrowser()
//        {

//            driver.Quit();
//        }
//    }
//}
