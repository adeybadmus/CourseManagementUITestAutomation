Feature: Department
	As a Course Management System user
	I should be able to Create, Modify, Delete and View 
	An instructor record

Background: 
	Given that CMS is loaded
	When a user clicks on Department link

Scenario Outline: Department_01_Verify that user cannot create Departmet Record with incorrect data
	When a user clicks on DepCreate New link
	And a user fills in Department page with <Name>, <Budget>, <StartDate>, <PersonId> fields
	And a user clicks on DepCreate button
	Then dept error message <ExpectedDeptErrorMessage> should be displayed
	Examples:
	| Name     | Budget | StartDate  | PersonId   | ExpectedDeptErrorMessage     |
	|          | 5000   | 02/04/2010 | YinkaTest7 | Department name is required. |
	| DepTest4 |        | 02/04/2010 | YinkaTes7  | Budget is required.          |
	| DepTest5 | 5000   |            | YinkaTest7 | Start is required.           |
	| DepTest6 | 5000   | 02/04/2010 | YinkaTest7 |                              |