Feature: Student
	As a Course Management System user
	I should be able to Create, Modify, Delete and View 
	A student record

Background: 
	Given that CMS is loaded
	When a user clicks on Student link

Scenario: Student_01_Verify that user can create a new Student record	
	When a user clicks on Create New link
	And a user Input FamilyName field with AtokeTest1
	And a user Input FirstName field with AdenleTest1
	And a user Input EnrollmentDate field with 2010/10/10
	And a user clicks on Create button
	Then a new Student record AtokeTest1 should be created
	#

Scenario: Student_02_Use a table format to verify that a user can create a new 'Student' record
	When a user clicks on Create New link
	And a user fills in new student record form page with below data
	| FamilyName | FirstName   | EnrollmentDate |
	| AtokeTest2 | AdenleTest2 | 2020/02/03     |
	And a user clicks on Create button
	Then a new Student record AtokeTest2 should be created


Scenario Outline: Student_03_Verify that multiple Student records can be created
	When a user clicks on Create New link
	And a user fills-in a new student form page with <FamilyName>, <FirstName>, <EnrollmentDate> fields
	And a user clicks on Create button
	Then a new Student record <ExpectedResults> should be created
	Examples:
	| FamilyName | FirstName | EnrollmentDate | ExpectedResult |
	| AtokeTest3 | AdenleTest3 | 2020/02/03     | AtokeTest3     |
	| AtokeTest4 | AdenleTest4 | 2020/02/03     | AtokeTest4     |
	| AtokeTest5 | AdenleTest5 | 2020/02/03     | AtokeTest5     |
	| AtokeTest6 | AdenleTest6 | 2020/02/03     | AtokeTest6     |
	| AtokeTest7 | AdenleTest7 | 2020/02/03     | AtokeTest7     |

Scenario: Student_04_Verify that user can modify an existing Student record
	When a user clicks on Edit link
	And a user Input FamilyName field with AtokeTest12
	And a user Input FirstName field with AdenleTest12
	And a user Input EnrollmentDate field with 10/10/2018
	And a user clicks on Save button
	Then a new Student record AtokeTest12 should be created


Scenario: Student_05_Verify that user can delete an existing Student record
	When a user clicks on Delete on link
	And a user clicks on Delete button on the form page
	Then Student record AtokeTes11 should not be present