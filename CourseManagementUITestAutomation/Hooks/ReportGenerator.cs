using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;

namespace CourseManagementUITestAutomation.Hooks
{
    // Class responsible for generating and managing test reports using ExtentReports.
    public class ReportGenerator
    {
        // Lazy instantiation of ExtentReports to ensure a single instance throughout the application.
        private static readonly Lazy<ExtentReports> _instantiate = new Lazy<ExtentReports>(() => new ExtentReports());

        // Gets the an instance of ExtentReports.
        public static ExtentReports Instance { get { return _instantiate.Value; } }

        // Static constructor to configure and attach the ExtentV3HtmlReporter.
        static ReportGenerator()
        {
            // Create an instance of ExtentV3HtmlReporter with the specified file path.
            var testResultReport = new ExtentV3HtmlReporter(AppDomain.CurrentDomain.BaseDirectory + @"\TestResult.html");

            // Setting the theme for the report.
            testResultReport.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            // Attach the ExtentV3HtmlReporter to the ExtentReports instance.
            Instance.AttachReporter(testResultReport);
        }
    }
}
