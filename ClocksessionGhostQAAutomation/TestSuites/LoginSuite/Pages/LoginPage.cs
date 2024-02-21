using MyersAndStaufferSeleniumTests.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClocksessionGhostQAAutomation.TestSuites.LoginSuite.Pages
{
    public class LoginPage : BasePage
    {
        public override string PageURL => $"{BaseURL}";

        // Page Elements

        public IWebElement Login => driver.FindElementWhenVisible(() => By.XPath("//a[contains(text(),'Login')]"));
        public IWebElement EmailInput => driver.FindElementWhenVisible(() => By.Id("email"));
        public IWebElement PasswordInput => driver.FindElement(By.Id("password"));

        public IWebElement LogInButton => driver.FindElement(By.XPath("//span[contains(text(),'Login')]"));
        public IWebElement MechlinHeader => driver.FindElementWhenVisible(() => By.XPath("//div//h1[contains(text(), 'Mechlin Software Technology Pvt. Ltd.')]"));

        // Methods
        public void WaitForPageLoad()
        {
            driver.WaitUntilElementIsDisplayed(() => Login, timeoutInSeconds: 120);

        }

        public void ClickonLogin()
        {

            Login.Click();
        }

        public void SetEmail(string username)
        {
            EmailInput.Click();
            driver.ActionSendKeys(EmailInput, username);
        }

        public bool IsPasswordInputVisible()
        {
            return PasswordInput.IsElementVisibleAndEnabled();
        }

        public void SetPassword(string password)
        {
            PasswordInput.Click();
            driver.ActionSendKeys(PasswordInput, password);
        }

        public bool IsLoginButtonVisible()
        {
            return LogInButton.IsElementVisibleAndEnabled();
        }

        public void SubmitLogIn()
        {
            LogInButton.Click();
        }

       

        public bool LoginSuccess()
        {
            return MechlinHeader.IsElementVisibleAndEnabled();
        }
    }
}
