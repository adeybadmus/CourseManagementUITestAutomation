using CourseManagementUITestAutomation.Hooks;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace CourseManagementUITestAutomation.Pages
{
    // Represents the Page Object Model (POM) for the Home Page in the Course Management System.
    public class HomePage
    {
        private readonly IWebDriver _driver;

        // WebElements locators for Home Page elements.
        private readonly By courseManagementSystemLink = By.CssSelector("div.navbar-header > a");
        private readonly By studentLink = By.CssSelector("ul> li:nth-child(1) >a");
        private readonly By courseLink = By.CssSelector("ul> li:nth-child(2) >a");
        private readonly By departmentLink = By.CssSelector("ul> li:nth-child(5) >a");
        // private readonly By enrollmentLink = By.CssSelector("ul> li:nth-child(3) >a");
        // private readonly By instructorLink = By.CssSelector("ul> li:nth-child(4) >a");
        // private readonly By teachingAssignLink = By.CssSelector("ul> li:nth-child(6) >a");
        // private readonly By taskLink = By.CssSelector("ul> li:nth-child(7) >a");
        // private readonly By adminLink = By.CssSelector("ul> li:nth-child(8) >a");
        // private readonly By registerLink = By.Id("#registerLink");
        // private readonly By logInLink = By.Id("#loginLink");
        // private readonly By allModules = By.XPath("//*[@href]");

        // Constructor to initialize the HomePage with an IWebDriver instance.
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Clicks on the "Student" link and returns a new instance of the StudentPage.
        public StudentPage ClickOnStudentLink()
        {
            _driver.Click(studentLink);
            return new StudentPage(_driver);
        }

        // Clicks on the "Course" link and returns a new instance of the CoursePage.
        public CoursePage ClickOnCourseLink()
        {
            _driver.Click(courseLink);
            return new CoursePage(_driver);
        }

        // Clicks on the "Department" link and returns a new instance of the DepartmentPage.
        public DepartmentPage ClickOnDepartmentLink()
        {
            _driver.Click(departmentLink);
            return new DepartmentPage(_driver);
        }

        // Verifies that all modules exist on the page and returns their text.
        public List<string> VerifyThatAllModulesExist()
        {
            List<string> modulesText = new List<string>();
            IList<IWebElement> modules = _driver.FindElements(By.XPath("//*[@href]"));

            foreach (var module in modules)
            {
                if (!string.IsNullOrEmpty(module.Text))
                {
                    modulesText.Add(module.Text);
                }
            }
            return modulesText;
        }

        // Verifies that a module is clickable based on the expected module text and counter.
        public bool VerifyThatAModuleIsClickable(string expectedModule, int counter)
        {
            bool newPageAppears = false;
            IList<IWebElement> modules = _driver.FindElements(By.XPath("//*[@href]"));

            if (expectedModule.Equals("Teaching_Assign"))
            {
                modules[counter].Click();
                newPageAppears = _driver.GetUrl().Contains("courseinstructor");
            }
            else if (expectedModule.Equals("Log in"))
            {
                modules[counter].Click();
                newPageAppears = _driver.GetUrl().Contains("Account/Login");
            }
            else if (expectedModule.Equals("Course Management System"))
            {
                modules[counter].Click();
                newPageAppears = _driver.GetUrl().Contains(_driver.GetUrl());
            }
            else if (modules[counter].Text.Equals(expectedModule))
            {
                modules[counter].Click();
                newPageAppears = _driver.GetUrl().ToLower().Contains(expectedModule.ToLower());
            }

            return newPageAppears;
        }
    }
}
