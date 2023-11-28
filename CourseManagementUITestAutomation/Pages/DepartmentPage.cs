using CourseManagementUITestAutomation.Hooks;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;


namespace CourseManagementUITestAutomation.Pages
{
    // Represents the Page Object Model (POM) for the Department Page in the Course Management System.
    public class DepartmentPage
    {
        private readonly IWebDriver _driver;

        // WebElements locators for Department Page elements.
        private readonly By depCreateNewLink = By.CssSelector("a[href*='Create']");
        private readonly By name = By.Id("Name");
        private readonly By budget = By.Id("Budget");
        private readonly By startDate = By.Id("StartDate");
        private readonly By personId = By.Name("PersonId");
        private readonly By depCreateButton = By.CssSelector("input[value*='Create']");
        private readonly By nameErrorMessage = By.CssSelector("span[data-valmsg-for*='Name']");
        private readonly By budgetErrorMesssage = By.CssSelector("span[data-valmsg-for*='Budget']");
        private readonly By startDateErrorMessage = By.CssSelector("span[data-valmsg-for*='StartDate']");
        private readonly By depEditLink = By.CssSelector("a[href *= 'Edit']");
        private readonly By depSaveButton = By.CssSelector("input[value*='Save']");
        private readonly By depDeleteLink = By.CssSelector("a[href *= 'Delete']");
        private readonly By depDeleteButton = By.CssSelector("input[value*='Delete']");
        private readonly By DepTable = By.CssSelector("table[class*='table']");
        private readonly By tableRow = By.TagName("tr");
        private readonly By tableData = By.TagName("td");

        // Constructor to initialize the DepartmentPage with an IWebDriver instance.
        public DepartmentPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Clicks on the "Create New" link on the Department Page.
        public void ClickOnDepCreateNewLink()
        {
            _driver.Click(depCreateNewLink);
        }

        // Fills in the Department Name field with the provided data.
        public void FillinDepName(string nameData)
        {
            _driver.ClearAndSendKeys(name, nameData);
        }

        // Fills in the Budget field with the provided data.
        public void FillInBudget(string budgetFieldData)
        {
            _driver.ClearAndSendKeys(budget, budgetFieldData);
        }

        // Fills in the Start Date field with the provided data.
        public void FillInStartDate(string startDateData)
        {
            _driver.ClearAndSendKeys(startDate, startDateData);
        }

        // Selects the Person ID from the dropdown.
        public void SelectPersonId(string personData)
        {
            _driver.SelectOptionByText(personId, personData);
        }

        // Clicks on the "Create" button.
        public void ClickCreateButton()
        {
            _driver.Click(depCreateButton);
        }

        // Verifies the URL after department record creation.
        public string VerifyDepartmentRecordCreation()
        {
            return _driver.Url;
        }

        // Returns the error message for the Department Name field.
        public string ReturnNameErrorMessage()
        {
            return _driver.GetElementText(nameErrorMessage);
        }

        // Returns the error message for the Budget field.
        public string ReturnBudgetErrorMessage()
        {
            return _driver.GetElementText(budgetErrorMesssage);
        }

        // Returns the error message for the Start Date field.
        public string ReturnStartDateErrorMessage()
        {
            return _driver.GetElementText(startDateErrorMessage);
        }

        // Clicks on the "Edit" link.
        public void ClickEditLink()
        {
            _driver.Navigate().Refresh();
            _driver.Click(depEditLink);
        }

        // Clicks on the "Save" button.
        public void ClickSaveButton()
        {
            _driver.Click(depSaveButton);
        }

        // Clicks on the "Delete" link.
        public void ClickDeletelink()
        {
            _driver.Navigate().Refresh();
            _driver.Click(depDeleteLink);
        }

        // Clicks on the "Delete" button.
        public void ClickDeleteButton()
        {
            _driver.Navigate().Refresh();
            _driver.Click(depDeleteButton);
        }

        // Refreshes the browser.
        public void Refresh()
        {
            _driver.Navigate().Refresh();
        }

        // Verifies the actual result against the expected result in the Department Table.
        public bool ActualResultVerification(string expectedResult)
        {
            IWebElement table = _driver.FindElement(DepTable);
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
    }
}
