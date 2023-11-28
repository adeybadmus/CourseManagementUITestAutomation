﻿using System;
using OpenQA.Selenium;
using CourseManagementUITestAutomation.Factory;
using BoDi;

namespace CourseManagementUITestAutomation.Hooks
{
    
    //Class representing the context for Course Management System tests.
    
    public class Context
    {
        private readonly ChromeDriverFactory _chromeDriverFactory;
        private readonly FirefoxDriverFactory _firefoxDriverFactory;
        private readonly InternetExplorerDriverFactory _internetExplorerDriverFactory;
        public IWebDriver driver;
        private readonly IObjectContainer _objectContainer;
        private readonly string _baseUrl = EnvironmentData.baseUrl;
        private readonly string _browser = EnvironmentData.browser;

        // Initializes a new instance of the Context class.
        public Context(IObjectContainer objectContainer,
                       ChromeDriverFactory chromeDriverFactory,
                       FirefoxDriverFactory firefoxDriverFactory,
                       InternetExplorerDriverFactory internetExplorerDriverFactory)
        {
            _objectContainer = objectContainer;
            _chromeDriverFactory = chromeDriverFactory;
            _firefoxDriverFactory = firefoxDriverFactory;
            _internetExplorerDriverFactory = internetExplorerDriverFactory;
        }

        // Loads the Course Management System application based on the specified browser.
        public void LoadCMSApplication()
        {
            switch (_browser.ToLower())
            {
                case "firefox":
                    driver = _firefoxDriverFactory.Create(_objectContainer);
                    break;

                case "chrome":
                    driver = _chromeDriverFactory.Create(_objectContainer);
                    break;

                case "ie":
                    driver = _internetExplorerDriverFactory.Create(_objectContainer);
                    break;

                default:
                    driver = _chromeDriverFactory.Create(_objectContainer);
                    break;
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Navigate().GoToUrl(_baseUrl);
        }

        // Shuts down the Course Management System application.
        public void ShutDownCMSApplication()
        {
            driver?.Quit();
        }

        // Takes a screenshot at the point of test failure.
        public void TakeScreenshotAtThePointOfTestFailure(string directory, string scenarioName)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string path = directory + scenarioName + DateTime.Now.ToString("yyyy-MM-dd") + ".png";
            string Screenshot = screenshot.AsBase64EncodedString;
            byte[] screenshotAsByteArray = screenshot.AsByteArray;
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
        }
    }
}
