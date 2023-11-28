using CourseManagementUITestAutomation.Hooks;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseManagementUITestAutomation.Pages
{
    // Represents the Page Object Model (POM) for the Course Page in the Course Management System.
    public class CoursePage
    {
        private readonly IWebDriver _driver;

        // WebElements locators for Course Page elements.
        private readonly By courseCreateNewLink = By.CssSelector("a[href*='Create']");
        private readonly By courseNumber = By.Id("CourseId");
        private readonly By title = By.Id("CourseName");
        private readonly By credits = By.Id("TotalCredits");
        private readonly By deptId = By.Id("DepartmentId");
        private readonly By courseCreateButton = By.CssSelector("input[value*='Create']");
        private readonly By courseNumberErrorMessage = By.CssSelector("span[data-valmsg-for*='CourseId']");
        private readonly By titleErrorMessage = By.CssSelector("span[data-valmsg-for*='CourseName']");
        private readonly By creditsErrorMessage = By.CssSelector("span[data-valmsg-for*='TotalCredits']");
        private readonly By deptIdErrormessage = By.CssSelector("span[data-valmsg-for*='DepartmentId']");
        private readonly By editLink = By.CssSelector("a[href *= 'Edit']");
        private readonly By saveButton = By.CssSelector("input[value*='Save']");
        private readonly By deleteLink = By.CssSelector("a[href *= 'Delete']");
        private readonly By deleteButton = By.CssSelector("input[value*='Delete']");
        private readonly By courseTable = By.CssSelector("table[class*='table']");
        private readonly By tableRow = By.TagName("tr");
        private readonly By tableData = By.TagName("td");

        // Constructor to initialize the CoursePage with an IWebDriver instance.
        public CoursePage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Clicks on the "Create New" link on the Course Page.
        public void ClickOnCourseCreateNewLink()
        {
            _driver.Click(courseCreateNewLink);
        }

        // Fills in the Course Number field with the provided data.
        public void FillInCourseNumber(string courseNumberData)
        {
            _driver.ClearAndSendKeys(courseNumber, courseNumberData);
        }

        // Fills in the Title field with the provided data.
        public void FillInTitle(string titleData)
        {
            _driver.ClearAndSendKeys(title, titleData);
        }

        // Fills in the Credits field with the provided data.
        public void FillInCredits(string creditsData)
        {
            _driver.ClearAndSendKeys(credits, creditsData);
        }

        // Selects the Department ID from the dropdown.
        public void SelectDeptId(string deptIdData)
        {
            _driver.SelectOptionByText(deptId, deptIdData);
        }

        // Clicks on the "Create" button.
        public void ClickCourseCreateButton()
        {
            _driver.Click(courseCreateButton);
        }

        // Clicks on the "Edit" link.
        public void ClickEditLink()
        {
            _driver.Navigate().Refresh();
            _driver.Click(editLink);
        }

        // Refreshes the browser.
        public void BrowserRefresh()
        {
            _driver.Navigate().Refresh();
        }

        // Verifies the actual result against the expected result in the Course Table.
        public bool ActualResultVerification(string expectedResult)
        {
            IWebElement table = _driver.FindElement(courseTable);
            IEnumerable<IWebElement> rows = table.FindElements(tableRow).Skip(1);
            bool actualResult = false;
            bool breakOutofTheLoop = false;

            foreach (var row in rows)
            {
                var rowData = row.FindElements(tableData);
                foreach (var data in rowData)
                {
                    if (data.Text.Trim().Equals(expectedResult))
                    {
                        actualResult = true;
                        breakOutofTheLoop = true;
                        break;
                    }
                }
                if (breakOutofTheLoop)
                {
                    break;
                }
            }
            return actualResult;
        }

        // Returns the error message for the Course Number field.
        public string ReturnCourseNumberErrorMessage()
        {
            return _driver.GetElementText(courseNumberErrorMessage).Trim();
        }

        // Returns the error message for the Title field.
        public string ReturnTitleErrorMessage()
        {
            return _driver.GetElementText(titleErrorMessage).Trim();
        }

        // Returns the error message for the Credits field.
        public string ReturnCreditsErrorMessage()
        {
            return _driver.GetElementText(creditsErrorMessage).Trim();
        }

        // Returns the error message for the Department ID field.
        public string ReturnDeptIdErrorMessage()
        {
            return _driver.GetElementText(deptIdErrormessage).Trim();
        }

        // Clicks on the "Save" button.
        public void ClickOnSaveButton()
        {
            _driver.Click(saveButton);
        }

        // Clicks on the "Delete" link.
        public void ClickDeleteLink()
        {
            _driver.Navigate().Refresh();
            _driver.Click(deleteLink);
        }

        // Clicks on the "Delete" button.
        public void ClickOnDeleteButton()
        {
            _driver.Click(deleteButton);
        }

        // Accepts the alert.
        public void Alert()
        {
            _driver.SwitchTo().Alert().Accept();
        }
    }
}
