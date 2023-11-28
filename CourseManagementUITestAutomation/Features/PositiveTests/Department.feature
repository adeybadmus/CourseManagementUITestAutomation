Feature: Department
	As a Course Management System user
	I should be able to Create, Modify, Delete and View 
	An instructor record

Background: 
	Given that CMS is loaded
	When a user clicks on Department link

#prerequisite: A Department record DepTest1 should be deleted
#			An instructor record YinkaTest7 BadmisTest7 should be added
Scenario: Department_01_Verify that user can create a new Department record
	When a user clicks on DepCreate New link
	And a user Input Name field with DepTest1
	And a user Input Budget field with 2000
	And a user Input StartDate field with 01/01/2020
	And a user select YinkaTest7 from PersonId field
	And a user clicks on DepCreate button
	Then a new Department record DepTest1 should be created

Scenario: Department_02_Verify that user can create a new Department record using table format
	When a user clicks on DepCreate New link
	And a user fills in the Department record page with below data
	| Name     | Budget | StartDate  | PersonId   |
	| DepTest2 | 5000   | 02/04/2010 | YinkaTest7 |
	And a user clicks on DepCreate button
	Then a new Department record DepTest2 should be created

Scenario Outline: Department_03_Verify that user can create muliple Departmet Records
	When a user clicks on DepCreate New link
	And a user fills in Department page with <Name>, <Budget>, <StartDate>, <PersonId> fields
	And a user clicks on DepCreate button
	Then a new Department record <ExpectedResult> should be created
	Examples:
	| Name     | Budget | StartDate  | PersonId   | ExpectedResult |
	| DepTest3 | 5000   | 02/04/2010 | YinkaTest7 | DepTest3       |
	| DepTest4 | 5000   | 02/04/2010 | YinkaTest7 | DepTest4       |
	| DepTest5 | 5000   | 02/04/2010 | YinkaTest7 | DepTest5       |
	| DepTest6 | 5000   | 02/04/2010 | YinkaTest7 | DepTest6       |

Scenario: Department_05_Verify that user can modify an existing Department record
	When a user clicks on DepEdit link
	And a user Input Name field with DepTest8
	And a user Input Budget field with 6000
	And a user Input StartDate field with 01/01/2022
	And a user select YinkaTest7 from PersonId field
	And a user clicks on DepSave button
	Then a new Department record DepTest8 should be created

	Scenario: Department_06_Verify that user can delete an existing Department record
	When a user clicks on DepDelete link
	And a user clicks on DepDelete button
	Then an existing Department record DepTest8 should be deleted