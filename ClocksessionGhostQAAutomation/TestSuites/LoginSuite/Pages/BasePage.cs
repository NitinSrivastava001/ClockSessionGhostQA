﻿using ClocksessionGhostQAAutomation.TestSuites.LoginSuite.Tests;
using ClocksessionGhostQAAutomation.Utils;
using OpenQA.Selenium;
using System.Text;

namespace ClocksessionGhostQAAutomation.TestSuites.LoginSuite.Pages
{
    public abstract class BasePage
    {
        public static string BaseURL;
        public static string BaseDomain;

        public virtual string PageURL { get; set; } = "/";

        public IWebDriver driver;
        IWebElement element = null;

        public IDictionary<string, object> vars { get; private set; }

        private IJavaScriptExecutor js;

        public BasePage(bool skipLoad = false)
        {
            BaseURL = GhostQAExecutor.Baseurl;

            driver = Browser.Driver;
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();

            if (!skipLoad)
            {
                Load();
            }
        }

        public void Load()
        {
            driver.Navigate().GoToUrl(PageURL);
        }

        protected void Close()
        {
            driver.Quit();
        }

        public void LogMessage(string message)
        {
            string messageWithClass = $"[{GetType().Name}] {message}";
            WebDriverExtensions.LogMessage(messageWithClass);
        }

        public static void WaitSeconds(int seconds)
        {
            Task.Delay(seconds).Wait(seconds * 1000);
        }

        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor((26 * random.NextDouble()) + 65)));
                builder.Append(ch);
            }
            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        public static int RandomNumber(int min, int max)
        {
            Random _random = new Random();
            return _random.Next(min, max);
        }

        public string RandomEmail(string username)
        {
            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next(10000);
            string email = username + randomInt + "@gmail.com";
            return email;
        }
    }
}