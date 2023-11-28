using NUnit.Framework;

// Represents environment data for the test suite
namespace CourseManagementUITestAutomation
{
    // Provides access to environment-specific configuration data
    class EnvironmentData
    {
        // Gets the base URL from the test context parameters
        public static string BaseUrl { get; } = TestContext.Parameters["baseURL"];

        // Gets the browser from the test context parameters
        public static string Browser { get; } = TestContext.Parameters["browser"];

        // Gets the database connection string from the test context parameters
        public static string ConnectionString { get; } = TestContext.Parameters["connectionString"];

        // Gets the directory for storing screenshots from the test context parameters
        public static string ScreenShotDirectory { get; } = TestContext.Parameters["ScreenShotDirectory"];
    }
}
