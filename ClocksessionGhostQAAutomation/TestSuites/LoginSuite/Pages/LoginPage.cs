using ClocksessionGhostQAAutomation.Utils;
using OpenQA.Selenium;

namespace ClocksessionGhostQAAutomation.TestSuites.LoginSuite.Pages
{
    public class LoginPage : BasePage
    {
        public override string PageURL => $"{BaseURL}";

        // Page Elements

        //public IWebElement Login => driver.FindElementWhenVisible(() => By.XPath("//a[contains(text(),'Login')]"));
        public IWebElement EmailInput => driver.FindElementWhenVisible(() => By.XPath("//input[@name='email']"));

        public IWebElement PasswordInput => driver.FindElement(By.XPath("//input[@name='password']"));

        public IWebElement LogInButton => driver.FindElement(By.XPath("//button[contains(text(),'LOGIN')]"));
        public IWebElement MechlinHeader => driver.FindElementWhenVisible(() => By.XPath("//div//h1[contains(text(), 'Mechlin Software Technology Pvt. Ltd.')]"));

        // Methods
        public void WaitForPageLoad()
        {
            driver.WaitUntilElementIsDisplayed(() => EmailInput, timeoutInSeconds: 120);
        }

        public void ClickonLogin()
        {
            EmailInput.Click();
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