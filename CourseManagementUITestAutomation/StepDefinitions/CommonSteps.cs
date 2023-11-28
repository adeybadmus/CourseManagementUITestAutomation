using TechTalk.SpecFlow;
using CourseManagementUITestAutomation.Hooks;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using System;

namespace CourseManagementUIAutomation.StepDefinitions
{
    // Represents the common steps for SpecFlow scenarios.
    [Binding]
    public class CommonSteps
    {
        private readonly Context _context;
        private static ExtentTest feature;
        private static ExtentTest scenario;
        private static ExtentReports report;
        private readonly ScenarioContext _scenarioContext;

        // Constructor to initialize CommonSteps with context and scenarioContext.
        public CommonSteps(Context context, ScenarioContext scenarioContext)
        {
            _context = context;
            _scenarioContext = scenarioContext;
        }

        // Loads the CMS application when called.
        [When(@"CMS application is loaded")]
        [Given(@"that CMS is loaded")]
        public void GivenThatCMSIsLoaded()
        {
            _context.LoadCMSApplication();
            scenario = feature.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        // Generates the test report before the test run.
        [BeforeTestRun]
        public static void ReportGenerator()
        {
            DateTime now = DateTime.Now;
            var testResultReport = new ExtentV3HtmlReporter(AppDomain.CurrentDomain.BaseDirectory + now.ToString("MMM-dd-yyyy hh-mm-ss") + @"\TestResult.html");
            testResultReport.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            report = new ExtentReports();
            report.AttachReporter(testResultReport);
        }

        // Cleans up and flushes the report after the test run.
        [AfterTestRun]
        public static void ReportCleaner()
        {
            report.Flush();
        }

        // Creates a test feature before the feature starts.
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            feature = report.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        // Adds steps to the report after each step execution.
        [AfterStep]
        public void StepsInTheReport()
        {
            var typeOfStep = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError == null)
            {
                // Cater for a step that passed
                CreateNodeBasedOnStepType(typeOfStep);
            }

            if (_scenarioContext.TestError != null)
            {
                // Cater for a step that failed
                CreateNodeBasedOnStepType(typeOfStep).Fail(_scenarioContext.TestError.Message);
            }

            if (_scenarioContext.ScenarioExecutionStatus.ToString().Equals("StepDefinitionPending"))
            {
                // Cater for a step that has not been implemented
                CreateNodeBasedOnStepType(typeOfStep).Skip("Step Definition Pending");
            }
        }

        // Closes the AUT (Application Under Test) after each scenario.
        [AfterScenario]
        public void CloseAUT()
        {
            try
            {
                if (_scenarioContext.TestError != null)
                {
                    string scenarioName = _scenarioContext.ScenarioInfo.Title;
                    string directory = AppDomain.CurrentDomain.BaseDirectory + @"\Screenshots\";
                    _context.TakeScreenshotAtThePointOfTestFailure(directory, scenarioName);
                }
            }
            catch (System.Exception)
            {
                // Handle exceptions if needed.
            }
            finally
            {
                _context.ShutDownCMSApplication();
            }
        }

        // Helper method to create a node in the report based on the step type.
        private ExtentTest CreateNodeBasedOnStepType(string typeOfStep)
        {
            if (typeOfStep.Equals("Given"))
            {
                return scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (typeOfStep.Equals("When"))
            {
                return scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (typeOfStep.Equals("Then"))
            {
                return scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
            }

            // Default to creating a node with the type of step.
            return scenario.CreateNode(typeOfStep, ScenarioStepContext.Current.StepInfo.Text);
        }
    }
}
