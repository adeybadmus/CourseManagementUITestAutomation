using System;

namespace CourseManagementUITestAutomation.Model
{
    // Model class representing a Course.
    public class CourseModel
    {
        // Gets or sets the course number.
        public string CourseNumber { get; set; }

        // Gets or sets the title of the course.
        public string Title { get; set; }

        // Gets or sets the number of credits for the course.
        public string Credits { get; set; }

        // Gets or sets the department ID associated with the course.
        public string DepartmentId { get; set; }
    }
}
