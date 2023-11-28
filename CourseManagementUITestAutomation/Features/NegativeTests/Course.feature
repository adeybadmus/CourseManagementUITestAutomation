Feature: Course
	As a Course Management System user
	I should be able to Create, Modify, Delete and View 
	A course record

Background: 
	Given that CMS is loaded
	When a user clicks on Course link

Scenario: Course_01_Verify that user cannot create a course records using incorrect data
	When a user clicks on CourseCreate New link
	And a user fills Course page with <CourseNumber>, <Title>, <Credits>, <DepartmentId> data
	And a user clicks on CourseCreate button
	Then a error message <ExpectedErrorMessage> should be displayed
	Examples: 
	| CourseNumber | Title         | Credits | DepartmentId | ExpectedErrorMessage                 |
	|              | BusinessTest3 | 2       | Deptest7     | The Course Number field is required. |
	| 100004       |               | 2       | Deptest7     | Title is required                    |
	| 100005       | BusinessTest5 |         | Deptest7     | Number of credits is required.       |
	| 100006       | BusinessTest6 | 2       |              |                                      |
