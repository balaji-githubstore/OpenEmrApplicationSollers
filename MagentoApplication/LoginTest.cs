using AutomationWrapper.Base;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MagentoApplication
{
    public class LoginTest : WebDriverWrapper
    {

        [Test]
        public void ValidCredentialTest()
        {
            driver.FindElement(By.XPath("//span[text()='Sign in']")).Click();
        }
    }
}