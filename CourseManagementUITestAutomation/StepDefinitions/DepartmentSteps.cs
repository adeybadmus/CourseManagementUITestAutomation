using CourseManagementUITestAutomation.Hooks;
using CourseManagementUITestAutomation.Model;
using CourseManagementUITestAutomation.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using CourseManagementTestUIAutomation;

namespace CourseManagementUIAutomation.StepDefinitions
{
    // Represents the steps related to Department in SpecFlow scenarios.
    [Binding]
    public class DepartmentSteps
    {
        private DepartmentPage departmentPage;
        private InstructorDatabaseHelper instDBhelper;
        private DeptDatabaseHelper depDBhelper;
        private HomePage homePage;

        // Constructor to initialize DepartmentSteps with dependencies.
        public DepartmentSteps(DepartmentPage _departmentPage, DeptDatabaseHelper _depDBhelper, HomePage _homePage, InstructorDatabaseHelper _instDBhelper)
        {
            departmentPage = _departmentPage;
            instDBhelper = _instDBhelper;
            depDBhelper = _depDBhelper;
            homePage = _homePage;
        }

        // Steps for clicking on Department link.
        [When(@"a user clicks on Department link")]
        public void WhenAUserClicksOnDepartmentLink()
        {
            // Additional steps related to database operations.
            depDBhelper.ClearOrPopulateDepartmentTable(Constants.clearDepartmentRecord);
            instDBhelper.ClearOrPopulateInstructorRecordInPersonTable(Constants.clearInstructorRecord);
            instDBhelper.ClearOrPopulateInstructorRecordInPersonTable(Constants.populateInstructorRecord);
            homePage.ClickOnDepartmentLink();
        }

        // Steps for verifying error messages.
        [Then(@"dept error message (.*) should be displayed")]
        public void ThenDeptErrorMessageShouldBeDisplayed(string expectedDeptErrorMessage)
        {
            string actualErrorMessage = string.Empty;

            // Mapping expected error messages to actual error messages.
            switch (expectedDeptErrorMessage)
            {
                case "Department name is required.":
                    actualErrorMessage = departmentPage.ReturnNameErrorMessage();
                    break;
                case "Budget is required.":
                    actualErrorMessage = departmentPage.ReturnBudgetErrorMessage();
                    break;
                case "Start is required.":
                    actualErrorMessage = departmentPage.ReturnStartDateErrorMessage();
                    break;
            }

            Assert.AreEqual(expectedDeptErrorMessage, actualErrorMessage, $"{expectedDeptErrorMessage} is not equal to {actualErrorMessage}");
        }

        [When(@"a user clicks on DepCreate New link")]
        public void WhenAUserClicksOnDepCreateNewLink()
        {
            departmentPage.ClickOnDepCreateNewLink();
        }

        [When(@"a user Input Name field with (.*)")]
        public void WhenAUserInputNameFieldWith(string Name)
        {
            departmentPage.FillinDepName(Name);
        }

        [When(@"a user Input Budget field with (.*)")]
        public void WhenAUserInputBudgetFieldWith(string budget)
        {
            departmentPage.FillInBudget(budget);
        }

        [When(@"a user Input StartDate field with (.*)")]
        public void WhenAUserInputStartDateFieldWith(string startDate)
        {
            departmentPage.FillInStartDate(startDate);
        }

        [When(@"a user select (.*) from PersonId field")]
        public void WhenAUserSelectYinkaTestFromPersonIdField(string personData)
        {
            departmentPage.SelectPersonId(personData);
        }


        [When(@"a user clicks on DepCreate button")]
        public void WhenAUserClicksOnDepCreateButton()
        {
            departmentPage.ClickCreateButton();
        }

        [Then(@"a new Department record (.*) should be created")]
        public void ThenANewDepartmentRecordShouldBeCreated(string expectedResult)
        {
            //string actualResult = departmentPage.VerifyDepartmentRecordCreation();
            //string expectedResult = "http://localhost/CourseManagementSystem/department";
            //Assert.AreEqual(expectedResult, actualResult);

            bool actualResult = departmentPage.ActualResultVerification(expectedResult);
            Assert.IsTrue(actualResult, $"actual result {actualResult} is not equal to expected result {expectedResult}");
        }

        [When(@"a user fills in the Department record page with below data")]
        public void WhenAUserFillsInTheDepartmentRecordPageWithBelowData(Table table)
        {
            var tableList = table.CreateInstance<DepartmentModel>();
            departmentPage.FillinDepName(tableList.Name);
            departmentPage.FillInBudget(tableList.Budget);
            departmentPage.FillInStartDate(tableList.StartDate);
            departmentPage.SelectPersonId(tableList.PersonId);
        }

        [When(@"a user fills in Department page with (.*), (.*), (.*), (.*) fields")]
        public void WhenAUserFillsInDepartmentPageWithDepTestYinkaTestFields(string name, string budget, string startDate, string personId)
        {
            departmentPage.FillinDepName(name);
            departmentPage.FillInBudget(budget);
            departmentPage.FillInStartDate(startDate);
            departmentPage.SelectPersonId(personId);
        }

        
        [When(@"a user clicks on DepEdit link")]
        public void WhenAUserClicksOnDepEditLink()
        {
            depDBhelper.ClearOrPopulateDepartmentTable(Constants.populateDepartmentRecord);
            departmentPage.ClickEditLink();
        }

        [When(@"a user clicks on DepSave button")]
        public void WhenAUserClicksOnDepSaveButton()
        {
            departmentPage.ClickSaveButton();
        }

        [When(@"a user clicks on DepDelete link")]
        public void WhenAUserClicksOnDepDeleteLink()
        {
            depDBhelper.ClearOrPopulateDepartmentTable(Constants.populateDepartmentRecord);
            departmentPage.ClickDeletelink();
        }

        [When(@"a user clicks on DepDelete button")]
        public void WhenAUserClicksOnDepDeleteButton()
        {
            departmentPage.ClickDeleteButton();
        }

        [Then(@"an existing Department record (.*) should be deleted")]
        public void ThenAnExistingDepartmentRecordDepTestShouldBeDeleted(string expectedResult)
        {
            bool actualResult = departmentPage.ActualResultVerification(expectedResult);
            Assert.IsFalse(actualResult, $"actual result {actualResult} is not equal to expected result {expectedResult}");
        }
    }
}
