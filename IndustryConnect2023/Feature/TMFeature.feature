﻿Feature: TMFeature

As a TurnUp portal admin
I would like to create,edit and delete Time and Material records
so that I can manage employees' time and materials successfully

@tag1
Scenario: Create new TM record with valid details
	Given Logged in TurnUp portal successfully
	When Navigate to TM page
	And Create a new TM record
	Then The new TM record should be created successfully

Scenario Outline: Edit an existing TM record with valid details
    Given Logged in TurnUp portal successfully
	When Navigate to TM page
	And  I update '<Description>', '<Code>', '<Price>' on an existing TM record
	Then The record should have the updated '<Description>','<Code>','<Price>'

Examples:
 | Description | Code    | Price |
 | Airplane    | Product | 15    |
 | Material    | Service | 11    |
 | EditRecord  | Staff   | 6     |
	 
