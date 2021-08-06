using AutomationWrapper.Base;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MagentoApplication
{
    public class LoginTest : WebDriverWrapper
    {
        //take data from excel
        [Test]
        public void ValidCredentialTest()
        {
            driver.FindElement(By.XPath("//span[text()='Sign in']")).Click();
        }

        [Test]
        public void InvalidCredentialTest()
        {
            driver.FindElement(By.XPath("//span[text()='Sign in']")).Click();
        }
    }
}