using TechTalk.SpecFlow;
using CourseManagementUITestAutomation.Hooks;
using CourseManagementUITestAutomation.Pages;
using TechTalk.SpecFlow.Assist;
using CourseManagementUITestAutomation.Model;
using NUnit.Framework;
using CourseManagementTestUIAutomation;

namespace CourseManagementUITestAutomation.StepDefinitions
{
    [Binding]
    public class StudentSteps
    {
        private HomePage homePage;
        private StudentPage studentPage;
        private StudentDatabaseHelper sdatabaseHelper;

        // Constructor to initialize instances of StudentPage, HomePage, and StudentDatabaseHelper
        public StudentSteps(StudentPage _studentPage, HomePage _homepage, StudentDatabaseHelper _sdatabasehelper)
        {
            studentPage = _studentPage;
            sdatabaseHelper = _sdatabasehelper;
            homePage = _homepage;
        }

        // Clicks on the Student link
        [When(@"a user clicks on Student link")]
        public void WhenAUserClicksOnStudentLink()
        {
            homePage.ClickOnStudentLink();
        }

        // Clicks on the Create New link and populates the Person table with data
        [When(@"a user clicks on Create New link")]
        public void WhenAUserClicksOnCreateNewLink()
        {
            sdatabaseHelper.ClearOrPopulatePersonTable(Constants.clearStudentRecord);
            studentPage.ClickonCreateNewLink();
        }

        // Fills in the FamilyName field with the provided value
        [When(@"a user Input FamilyName field with (.*)")]
        public void WhenAUserInputFamilyNameFieldWith(string familyName)
        {
            studentPage.FillinFamilyName(familyName + (WebDriverExtension.RandomNumber(0, 1000)));
        }

        // Fills in the FirstName field with the provided value
        [When(@"a user Input FirstName field with (.*)")]
        public void WhenAUserInputFirstNameFieldWith(string firstName)
        {
            studentPage.FillInFirstName(firstName + (WebDriverExtension.RandomNumber(0, 1000)));
        }

        // Fills in the EnrollmentDate field with the provided value
        [When(@"a user Input EnrollmentDate field with (.*)")]
        public void WhenAUserInputEnrollmentDateFieldWith(string enrollmentDate)
        {
            studentPage.FillInEnrollmentDate(enrollmentDate);
        }

        // Clicks on Create, Save, or Delete button
        [When(@"a user clicks on Delete button on the form page")]
        [When(@"a user clicks on Save button")]
        [When(@"a user clicks on Create button")]
        public void WhenAUserClicksOnCreateButton()
        {
            studentPage.ClickOnCreateSaveOrDeleteButton();
        }

        // Verifies that a new Student record is created
        [Then(@"a new Student record (.*) should be created")]
        public void ThenANewStudentRecordAdeShouldBeCreated(string familyName)
        {
            string actualResult = studentPage.VerifyStudentRecordCreation();
            string expectedResult = "http://localhost/CourseManagementSystem/students";
            Assert.AreEqual(expectedResult, actualResult);
        }

        // Fills in the new student record form with data from the table
        [When(@"a user fills in new student record form page with below data")]
        public void WhenAUserFillsInNewStudentRecordFormPageWithBelowData(Table table)
        {
            var tableList = table.CreateInstance<StudentModel>();
            studentPage.FillinFamilyName(tableList.FamilyName + (WebDriverExtension.RandomNumber(0, 1000)));
            studentPage.FillInFirstName(tableList.FirstName + (WebDriverExtension.RandomNumber(0, 1000)));
            studentPage.FillInEnrollmentDate(tableList.EnrollmentDate);
        }

        // Fills in the new student form with provided values
        [When(@"a user fills-in a new student form page with (.*), (.*), (.*) fields")]
        public void WhenAUserFills_InANewStudentFormPageWithAtokeAdedenleFields(string familyName, string firstName, string enrollmentDate)
        {
            studentPage.FillinFamilyName(familyName);
            studentPage.FillInFirstName(firstName);
            studentPage.FillInEnrollmentDate(enrollmentDate);
        }

        // Clicks on the Edit link
        [When(@"a user clicks on Edit link")]
        public void WhenAUserClicksOnEditLink()
        {
            sdatabaseHelper.ClearOrPopulatePersonTable(Constants.populateStudentRecord);
            studentPage.ClickOnEditLink();
        }

        // Clicks on the Delete link
        [When(@"a user clicks on Delete on link")]
        public void WhenAUserClicksOnDeleteOnLink()
        {
            sdatabaseHelper.ClearOrPopulatePersonTable(Constants.populateStudentRecord);
            studentPage.ClickOnDeleteLink();
        }

        // Verifies that the student record is not present
        [Then(@"Student record (.*) should not be present")]
        public void ThenStudentRecordShouldNotBePresent(string expectedResult)
        {
            bool actualResult = studentPage.ActualResultVerification(expectedResult);
            Assert.IsFalse(actualResult, $"actual result {actualResult} is not equal to expected result {expectedResult}");
        }

        // Verifies that an error message is displayed
        [Then(@"an error message (.*) should be displayed")]
        public void AnErrorMessageShouldBeDisplayed(string expectedErrorMessage)
        {
            string actualErrorMessage = string.Empty;

            if (expectedErrorMessage.Equals("First name is required"))
            {
                actualErrorMessage = studentPage.ReturnFirstNameErrorMessage();
            }
            else if (expectedErrorMessage.Equals("Last name is required"))
            {
                actualErrorMessage = studentPage.ReturnFamilyNameErrorMessage();
            }
            else if (expectedErrorMessage.Equals("Enrollment date is required"))
            {
                actualErrorMessage = studentPage.ReturnEnrollmentDateErrorMessage();
            }

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage, $"{expectedErrorMessage} is not equal to {actualErrorMessage}");
        }
    }
}
