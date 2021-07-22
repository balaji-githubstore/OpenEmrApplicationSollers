using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEmrApplication.Pages
{
    class LoginPage
    {
        private static By usernameLocator = By.CssSelector("#authUser");
        private static By passwordLocator = By.Id("clearPass");

        public static void EnterUsername(IWebDriver driver,string username)
        {
            driver.FindElement(usernameLocator).SendKeys(username);
        }

        public static void EnterPassword(IWebDriver driver,string password)
        {
            driver.FindElement(passwordLocator).SendKeys(password);
        }
    }
}
