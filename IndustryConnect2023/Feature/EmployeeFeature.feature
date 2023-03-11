Feature: EmployeeFeature

As a TurnUo admin, I'd like to create,edit, delete new employee record

@tag1
Scenario: I create new employee record with valid datails
	Given I logged in TurnUp portal successfully
	When I navigate to employee page
	And I create a new employee record with valid details
	Then The new employee recoed should be created successfully

Scenario Outline:I edit an existing employee record with valid datails
    Given I logged in TurnUp portal successfully
	When  I navigate to employee page
	And  I update '<Name>','<Username>' on an existing employee record
	Then The record should have updated '<Name>','<Username>'

	Examples: 
	| Name  | Username |
	| Effie | EffieP   |
	| Chris | ChrisP   |
	| Zach  | ZachP    |