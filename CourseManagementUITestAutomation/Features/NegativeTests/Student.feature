Feature: Student
	As a Course Management System user
	I should be able to Create, Modify, Delete and View 
	A student record

Background: 
	Given that CMS is loaded
	When a user clicks on Student link

Scenario Outline: Student_01_Verify that a new student record cannot be created with incorrect datak
	When a user clicks on Create New link
	And a user fills-in a new student form page with <FamilyName>, <FirstName>, <EnrollmentDate> fields
	And a user clicks on Create button
	Then an error message <ExpectedErrorMessage> should be displayed
	Examples: 
	| FamilyName  | FirstName    | EnrollmentDate | ExpectedErrorMessage        |
	| AtokeTest8  |              | 2020/02/03     | First name is required      |
	|             | AdenleTest9  | 2020/02/03     | Last name is required       |
	| AtokeTest10 | Adenletest10 |                | Enrollment date is required |
