Feature: Location
	

Scenario: Get all  locations	
	Given I login as an API user
	When I retrieve all locations
	Then I expect status code to be "200"

Scenario: Get location for an Id	
	Given I login as an API user
	When I retrieve a  location for Id "1"
	Then I expect status code to be "200"
	And I expect the location name to be "Location001"

Scenario: Add a new location	
	Given I login as an API user
	When I add a new location "Location004"
	And I retrieve a  location for Id "4"
	Then I expect status code to be "200"
	And I expect the location name to be "Location004"

Scenario: Update a location	for a given Id
	Given I login as an API user
	When I update a location to "Location005" for Id "4"
	And I retrieve a  location for Id "4"
	Then I expect status code to be "200"
	And I expect the location name to be "Location005"

## This is not implemented as there is some issue with deleting data
#Scenario: Delete a location	for a given Id
	#Given I login as an API user
	#When I delete a location for Id "4"	
	#Then I expect status code to be "200"
	