using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using CourseManagementUITestAutomation.Model;
using CourseManagementUITestAutomation.Pages;

namespace CourseManagementUITestAutomation.StepDefinitions
{
    // Represents the steps related to the Homepage in SpecFlow scenarios.
    [Binding]
    public class HomePageSteps
    {
        private HomePage _homePage;

        // Constructor to initialize the HomePage instance
        public HomePageSteps(HomePage homePage)
        {
            _homePage = homePage;
        }

        // Verifies that all modules specified in the table are visible on the home page
        [Then("All below modules are visible")]
        public void ThenAllBelowModulesAreVisible(Table table)
        {
            // Retrieve expected modules from the table
            var expectedModules = table.CreateSet<HomePageModel>();

            // Retrieve actual modules from the home page
            var actualModules = _homePage.VerifyThatAllModulesExist();

            // Compare expected and actual modules
            foreach (var expectedModule in expectedModules)
            {
                Assert.IsTrue(actualModules[0].Equals(expectedModule.Module), $"Expected module {expectedModule.Module} is not equal to actual module {actualModules[0]}");
                actualModules.Remove(actualModules[0]);
            }
        }

        // Verifies that all modules specified in the table are clickable
        [Then("All modules are clickable")]
        public void ThenAllModulesAreClickable(Table table)
        {
            int counter = 0;
            var expectedModules = table.CreateSet<HomePageModel>();

            // Verify clickability for each module
            foreach (var expectedModule in expectedModules)
            {
                counter++;
                Assert.IsTrue(_homePage.VerifyThatAModuleIsClickable(expectedModule.Module, counter));
            }
        }
    }
}
