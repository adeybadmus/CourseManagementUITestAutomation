using System.Data.SqlClient;

namespace CourseManagementUITestAutomation.Hooks
{
    // Helper class for interacting with the Department database table.
    public class DeptDatabaseHelper
    {
        // Connection string to the Department database
        private readonly string connectionString = EnvironmentData.connectionString;


        // Clears or populates the Department table based on the specified SQL query.
        public void ClearOrPopulateDepartmentTable(string query)
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
