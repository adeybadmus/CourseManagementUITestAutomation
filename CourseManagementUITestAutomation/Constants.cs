using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementTestUIAutomation
{
    public static class Constants
    {
        public static string clearStudentRecord = @"Delete from Person where LastName like 'AtokeTest%' and FirstName like 'AdenleTest%' and Discriminator = 'Student';";
        
        public static string populateStudentRecord = @"insert into Person (LastName, FirstName, EnrollmentDate, Discriminator)
                                      values('AtokeTest11', 'AdenleTest11', '2010/01/01', 'Student')";

        public static string clearEmployeeRecord = @"Delete from Employee where EmployeeName like 'Mariam%';";

        public static string populateEmployeeRecord = @"insert into Employee (EmployeeName)
                           values('Mariam6');";

        public static string clearStatusRecord = @"Delete from Status where StatusName like 'Status%';";

        public static string populateStatusRecord = @"insert into Status (StatusName)
                            values('Status6');";

        public static string clearCourseRecord = @"Delete from Course where CourseName like 'BusinessTest%';";

        public static string populateCourseRecord = @"insert into Course (CourseId, CourseName, TotalCredits, DepartmentId)
                            values('10007', 'BusinessTest7', 5, (SELECT [DepartmentId] from tb_Department));";

        public static string populateFirstCourseRecord = @"insert into Course (CourseId, CourseName, TotalCredits, DepartmentId)
                            values('10001', 'BusinessTest1', 5, (SELECT [DepartmentId] from tb_Department));";

        public static string populateSecondCourseRecord = @"insert into Course (CourseId, CourseName, TotalCredits, DepartmentId)
                            values('10002', 'BusinessTest2', 5, (SELECT [DepartmentId] from tb_Department));";

        public static string populateThirdCourseRecord = @"insert into Course (CourseId, CourseName, TotalCredits, DepartmentId)
                            values('10003', 'BusinessTest3', 5, (SELECT [DepartmentId] from tb_Department));";

        public static string populateFouthCourseRecord = @"insert into Course (CourseId, CourseName, TotalCredits, DepartmentId)
                            values('10004', 'BusinessTest4', 5, (SELECT [DepartmentId] from tb_Department));";

        public static string populateFifthCourseRecord = @"insert into Course (CourseId, CourseName, TotalCredits, DepartmentId)
                            values('10005', 'BusinessTest5', 5, (SELECT [DepartmentId] from tb_Department));";

        public static string populateSixthCourseRecord = @"insert into Course (CourseId, CourseName, TotalCredits, DepartmentId)
                            values('10006', 'BusinessTest6', 5, (SELECT [DepartmentId] from tb_Department));";

        public static string clearDepartmentRecord = @"delete from tb_Department;";
        //string query = @"Delete tb_Department from  tb_Department JOIN dbo.Person on Person.PersonId = tb_Department.PersonId Where Person.LastName like 'YinkaTest%';";

        public static string populateDepartmentRecord = @" insert into dbo.tb_Department (Name, Budget, StartDate, PersonId) 
                            values('DepTest7', '2000', '2010/01/01', (SELECT [PersonId] from Person where discriminator = 'Instructor'));";

        public static string clearEnrollmentRecord = @"Delete from Enrollment;";

        public static string populateEnrollmentRecord = @"Insert into Enrollment (CourseId, PersonId, Grade)
						values ((SELECT [CourseId] from Course), (SELECT [PersonId] from Person where discriminator = 'Student'), 100);";

        public static string clearInstructorRecord = @"Delete from Person where Discriminator = 'Instructor';";

        public static string populateInstructorRecord = @"insert into Person (LastName, FirstName, HireDate, Discriminator)
                            values('YinkaTest7', 'BadmusTest7', '2010/01/01', 'Instructor')";

        public static string clearTeachAssignRecord = @"Delete from CourseInstructor;";

        public static string populateTeachAssignRecord = @"Insert into CourseInstructor (CourseId, PersonId)
						values ((SELECT [CourseId] from Course), (SELECT [PersonId] from Person where discriminator = 'Instructor'));";
    }
}
