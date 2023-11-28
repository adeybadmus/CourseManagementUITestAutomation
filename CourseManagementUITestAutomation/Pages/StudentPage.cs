using System.Collections.Generic;
using CourseManagementUITestAutomation.Hooks;
using OpenQA.Selenium;
using System.Linq;

namespace CourseManagementUITestAutomation.Pages
{
    // Represents the Page Object Model (POM) for the Student Page in the Course Management System.
    public class StudentPage
    {
        private readonly IWebDriver _driver;

        // WebElements locators for Student Page elements.
        private readonly By createNewLink = By.CssSelector("a[href*='Create']");
        private readonly By familyName = By.Id("LastName");
        private readonly By firstName = By.Id("FirstName");
        private readonly By enrollmentDate = By.Id("EnrollmentDate");
        private readonly By familyNameErrorMessage = By.CssSelector("span[data-valmsg-for*='LastName']");
        private readonly By firstNameErrorMessage = By.CssSelector("span[data-valmsg-for*='FirstName']");
        private readonly By enrollmentDateErrorMessage = By.CssSelector("span[data-valmsg-for*='EnrollmentDate']");
        private readonly By editLink = By.CssSelector("tr:nth-child(2) a[href*='Edit']");
        private readonly By createSaveAndDeleteButton = By.CssSelector("input[type='submit']");
        private readonly By deleteLink = By.CssSelector("tr:nth-child(2) a[href*='Delete']");
        private readonly By stuTable = By.XPath("//table[@class='table']");
        private readonly By tableRow = By.TagName("tr");
        // private readonly By tableData = By.TagName("td");

        // Constructor to initialize the StudentPage with an IWebDriver instance.
        public StudentPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Clicks on the "Create New" link on the Student Page.
        public void ClickOnCreateNewLink()
        {
            _driver.Click(createNewLink);
        }

        // Fills in the Family Name field on the Student Page.
        public void FillInFamilyName(string familyNameData)
        {
            _driver.ClearAndSendKeys(familyName, familyNameData);
        }

        // Fills in the First Name field on the Student Page.
        public void FillInFirstName(string firstNameData)
        {
            _driver.ClearAndSendKeys(firstName, firstNameData);
        }

        // Fills in the Enrollment Date field on the Student Page.
        public void FillInEnrollmentDate(string enrollmentDateData)
        {
            _driver.ClearAndSendKeys(enrollmentDate, enrollmentDateData);
        }

        // Clicks on the "Create," "Save," or "Delete" button on the Student Page.
        public void ClickOnCreateSaveOrDeleteButton()
        {
            _driver.Click(createSaveAndDeleteButton);
        }

        // Verifies that a Student record is created successfully.
        public string VerifyStudentRecordCreation()
        {
            return _driver.Url;
        }

        // Returns the error message for the Family Name field on the Student Page.
        public string ReturnFamilyNameErrorMessage()
        {
            return _driver.GetElementText(familyNameErrorMessage);
        }

        // Returns the error message for the First Name field on the Student Page.
        public string ReturnFirstNameErrorMessage()
        {
            return _driver.GetElementText(firstNameErrorMessage);
        }

        // Returns the error message for the Enrollment Date field on the Student Page.
        public string ReturnEnrollmentDateErrorMessage()
        {
            return _driver.GetElementText(enrollmentDateErrorMessage);
        }

        // Clicks on the "Edit" link on the Student Page.
        public void ClickOnEditLink()
        {
            _driver.Navigate().Refresh();
            _driver.FocusAndClick(editLink);
        }

        // Clicks on the "Delete" link on the Student Page.
        public void ClickOnDeleteLink()
        {
            _driver.Navigate().Refresh();
            _driver.FocusAndClick(deleteLink);
        }

        // Verifies that a Student record is deleted successfully.
        public string VerifyStudentRecordDeletion()
        {
            return _driver.Url;
        }

        // Verifies the actual result based on the expected result.
        public bool ActualResultVerification(string expectedResult)
        {
            IList<IWebElement> table = _driver.FindElement(stuTable).FindElements(tableRow);
            IWebElement rows = table.FirstOrDefault(x => x.Text.Contains(expectedResult));
            return (rows != null);
        }

        public void ClickonCreateNewLink()
        {
            _driver.Click(createNewLink);
        }

        public void FillinFamilyName(string familyNameData)
        {
            _driver.ClearAndSendKeys(familyName, familyNameData);
        }
    }
}
