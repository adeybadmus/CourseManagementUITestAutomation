using System;
using System.Data.SqlClient;

namespace CourseManagementUITestAutomation.Hooks
{
    // Helper class for interacting with the Person database table.
    public class StudentDatabaseHelper
    {
        // Connection string to the Person database
        private readonly string connectionString = EnvironmentData.connectionString;

        // Clears or populates the Person table based on the specified SQL query.
        public void ClearOrPopulatePersonTable(string query)
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
    }
}
