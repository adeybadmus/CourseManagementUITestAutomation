using CourseManagementTestUIAutomation;
using CourseManagementUITestAutomation.Hooks;
using CourseManagementUITestAutomation.Pages;
using CourseManagementUITestAutomation.Model;
using NUnit.Framework;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CourseManagementUITestAutomation.StepDefinitions
{
    // Represents the steps related to Course in SpecFlow scenarios.
    [Binding]
    public class CourseSteps
    {
        private HomePage homePage;
        private CoursePage coursePage;
        private CourseDatabaseHelper cDatabaseHelper;
        private DeptDatabaseHelper deptDatabaseHelper;

        // Constructor to initialize CourseSteps with dependencies.
        public CourseSteps(HomePage _homepage, CoursePage _coursePage, CourseDatabaseHelper _cDatabaseHelper, DeptDatabaseHelper _deptDatabaseHelper)
        {
            homePage = _homepage;
            coursePage = _coursePage;
            cDatabaseHelper = _cDatabaseHelper;
            deptDatabaseHelper = _deptDatabaseHelper;
        }

        // Steps for navigating to the Course link.
        [When(@"a user clicks on Course link")]
        public void WhenAUserClicksOnCourseLink()
        {
            // Additional steps related to database operations.
            deptDatabaseHelper.ClearOrPopulateDepartmentTable(Constants.clearDepartmentRecord);
            cDatabaseHelper.ClearOrPopulateCourseTable(Constants.clearCourseRecord);
            deptDatabaseHelper.ClearOrPopulateDepartmentTable(Constants.populateDepartmentRecord);

            homePage.ClickOnCourseLink();
        }

        [When(@"a user clicks on CourseCreate New link")]
        public void WhenAUserClicksOnCourseCreateNewLink()
        {
            coursePage.ClickOnCourseCreateNewLink();
        }

        [When(@"a user Input CourseNumber field with (.*)")]
        public void WhenAUserInputCourseNumberFieldWith(string courseNumber)
        {
            coursePage.FillInCourseNumber(courseNumber);
        }

        [When(@"a user Input Title field with (.*)")]
        public void WhenAUserInputTitleFieldWithBusiness(string title)
        {
            coursePage.FillInTitle(title);
        }

        [When(@"a user Input Credits field with (.*)")]
        public void WhenAUserInputCreditsFieldWith(string credits)
        {
            coursePage.FillInCredits(credits);
        }

        [When(@"a user select (.*) from DepartmentId field")]
        public void WhenAUserSelectDepTestFromDepartmentIdField(string deptId)
        {
            coursePage.SelectDeptId(deptId);
        }

        [When(@"a user clicks on CourseCreate button")]
        public void WhenAUserClicksOnCourseCreateButton()
        {
            coursePage.ClickCourseCreateButton();
        }

        [Then(@"a new course record (.*) should be created")]
        public void ThenANewCourseRecordBusinessShouldBeCreated(string expectedResult)
        {
            bool actualResult = coursePage.ActualResultVerification(expectedResult);
            Assert.IsTrue(actualResult, $"actual result {actualResult} is not equal to expected result {expectedResult}");
        }

        // Steps for filling in the Course record page with data from a table.
        [When(@"a user fills in the Course record page with below data")]
        public void WhenAUserFillsInTheCourseRecordPageWithBelowData(Table table)
        {
            var tableList = table.CreateInstance<CourseModel>();
            coursePage.FillInCourseNumber(tableList.CourseNumber);
            coursePage.FillInTitle(tableList.Title);
            coursePage.FillInCredits(tableList.Credits);
            coursePage.SelectDeptId(tableList.DepartmentId);
        }

        // Steps for filling the Course page with data.
        [When(@"a user fills Course page with (.*), (.*), (.*), (.*) data")]
        public void WhenAUserFillsCoursePageWithData(string courseNumber, string title, string credits, string deptId)
        {
            coursePage.BrowserRefresh();
            coursePage.FillInCourseNumber(courseNumber);
            coursePage.FillInTitle(title);
            coursePage.FillInCredits(credits);
            coursePage.SelectDeptId(deptId);
        }

        // Steps for verifying error messages.
        [Then(@"a error message (.*) should be displayed")]
        public void ThenAErrorMessageShouldBeDisplayed(string expectedErrorMessage)
        {
            string actualErrorMessage = string.Empty;

            // Mapping expected error messages to actual error messages.
            switch (expectedErrorMessage)
            {
                case "The Course Number field is required.":
                    actualErrorMessage = coursePage.ReturnCourseNumberErrorMessage();
                    break;
                case "Title is required":
                    actualErrorMessage = coursePage.ReturnTitleErrorMessage();
                    break;
                case "Number of credits is required.":
                    actualErrorMessage = coursePage.ReturnCreditsErrorMessage();
                    break;
                case " ":
                    actualErrorMessage = coursePage.ReturnDeptIdErrorMessage();
                    break;
            }

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage, $"{expectedErrorMessage} is not equal to {actualErrorMessage}");
        }

        // Steps for clicking on CourseEdit link.
        [When(@"a user clicks on CourseEdit link")]
        public void WhenAUserClicksOnCourseEditLink()
        {
            // Additional steps related to database operations.
            cDatabaseHelper.PopulateCourseTableWithMultipleRecords();
            coursePage.BrowserRefresh();
            coursePage.ClickEditLink();
        }

        // Steps for clicking on CourseSave button.
        [When(@"a user clicks on CourseSave button")]
        public void WhenAUserClicksOnCourseSaveButton()
        {
            coursePage.ClickOnSaveButton();
        }

        // Steps for clicking on CourseDelete link.
        [When(@"a user clicks on CourseDelete link")]
        public void WhenAUserClicksOnCourseDeleteLink()
        {
            // Additional steps related to database operations.
            cDatabaseHelper.ClearOrPopulateCourseTable(Constants.populateCourseRecord);
            coursePage.BrowserRefresh();
            coursePage.ClickDeleteLink();
        }

        // Steps for clicking on CourseDelete button.
        [When(@"a user clicks on CourseDelete button")]
        public void WhenAUserClicksOnCourseDeleteButton()
        {
            coursePage.ClickOnDeleteButton();
        }

        // Steps for verifying the absence of an existing record.
        [Then(@"exiting record (.*) should not be present")]
        public void ThenExitingRecordBusinessTestShouldNotBePresent(string expectedResult)
        {
            bool actualResult = coursePage.ActualResultVerification(expectedResult);
            Assert.IsFalse(actualResult, $"actual result {actualResult} is not equal to expected result {expectedResult}");
        }

    }
}


