using CourseManagementTestUIAutomation;
using System.Data.SqlClient;

namespace CourseManagementUITestAutomation.Hooks
{
    // Helper class for interacting with the Course database.
    public class CourseDatabaseHelper
    {
        // Connection string to the Course database
        private readonly string connectionString = EnvironmentData.connectionString;

        // Clears or populates the Course table based on the specified SQL query.
        public void ClearOrPopulateCourseTable(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        // Populates the Course table with multiple records using predefined SQL commands.
        public void PopulateCourseTableWithMultipleRecords()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    // Execute SQL commands to populate the Course table with sample records
                    command.CommandText = Constants.populateFirstCourseRecord;
                    command.ExecuteNonQuery();

                    command.CommandText = Constants.populateSecondCourseRecord;
                    command.ExecuteNonQuery();

                    command.CommandText = Constants.populateThirdCourseRecord;
                    command.ExecuteNonQuery();

                    command.CommandText = Constants.populateFouthCourseRecord;
                    command.ExecuteNonQuery();

                    command.CommandText = Constants.populateFifthCourseRecord;
                    command.ExecuteNonQuery();

                    command.CommandText = Constants.populateSixthCourseRecord;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
