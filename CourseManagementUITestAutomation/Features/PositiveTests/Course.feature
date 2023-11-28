Feature: Course
	As a Course Management System user
	I should be able to Create, Modify, Delete and View 
	A course record

Background: 
	Given that CMS is loaded
	When a user clicks on Course link

#prerequisite: A course record Business1 should be deleted
Scenario: Course_01_Verify that user can create a new Course record
	When a user clicks on CourseCreate New link
	And a user Input CourseNumber field with 100001
	And a user Input Title field with BusinessTest1
	And a user Input Credits field with 4
	And a user select DepTest7 from DepartmentId field
	And a user clicks on CourseCreate button
	Then a new course record BusinessTest1 should be created


Scenario: Course_02_Verify that user can create a new COURSE record using table format
	When a user clicks on CourseCreate New link
	And a user fills in the Course record page with below data
	| CourseNumber | Title         | Credits | DepartmentId |
	| 100002       | BusinessTest2 | 2       | Deptest7     |
	And a user clicks on CourseCreate button
	Then a new Department record BusinessTest2 should be created


Scenario: Course_03_Verify that user can create multiple course records using table format
	When a user clicks on CourseCreate New link
	And a user fills Course page with <CourseNumber>, <Title>, <Credits>, <departmentId> data
	And a user clicks on CourseCreate button
	Then a new course record <ExpectedResults> should be created
	Examples: 
	| CourseNumber | Title         | Credits | DepartmentId | ExpectedResults |
	| 100003       | BusinessTest3 | 2       | Deptest7     | BusinessTest3   |
	| 100004       | BusinessTest4 | 2       | Deptest7     | BusinessTest4   |
	| 100005       | BusinessTest5 | 2       | Deptest7     | BusinessTest5   |
	| 100006       | BusinessTest6 | 2       | Deptest7     | BusinessTest6   |
	| 100007       | BusinessTest7 | 2       | Deptest7     | BusinessTest7   |

Scenario: Course_04_Verify that user can modify an exiting Course record
	When a user clicks on CourseEdit link
	And a user Input Title field with BusinessTest8
	And a user Input Credits field with 5
	And a user select DepTest7 from DepartmentId field
	And a user clicks on CourseSave button
	Then a new course record BusinessTest8 should be created

Scenario: Course_05_Verify that user can delete an exiting Course record
	When a user clicks on CourseDelete link
	And a user clicks on CourseDelete button
	Then exiting record BusinessTest7 should not be present