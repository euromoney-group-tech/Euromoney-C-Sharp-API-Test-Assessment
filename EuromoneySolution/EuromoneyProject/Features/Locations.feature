Feature: Locations
	test locations endpoint after logging in
	with GET/POST/PUT/DELETE HTTP methods
	

@locations
Scenario Outline: logging to api with correct credentials
	Given I am connecting to the api to login
	When I login using '<username>' and '<password>'
	Then I get a <status> status and a <token>

	Examples: 
	| username         | password | status | token |
	| techie@email.com | techie   | 200    | true  |
    | fail@fail.com    | fail     | 401    | false |


Scenario Outline: Get all locations and assert OK/200
	Given I am connecting to the api to login
	And I login using '<username>' and '<password>'
	And I get a <status> status and a <token>
	When I call the api with locations and '<id>' and a token
	Then I get a <status> from locations

	Examples: 
	| username         | password | status | token | numoflocations | id |
	| techie@email.com | techie   | 200    | true  | 3              |    |
	| techie@email.com | techie   | 200    | true  | 1              | 1  |


Scenario Outline: Get location by id and assert name,id and status as OK/200  
	Given I am connecting to the api to login
	And I login using '<username>' and '<password>'
	And I get a <status> status and a <token>
	When I call the api with locations and '<id>' and a token
	Then I get a <status> from locations
	And I expect <numoflocations> number of locations
	And I expect '<id>' and '<locationname>' 

	Examples: 
	| username         | password | status | token | numoflocations | id | locationname |
	| techie@email.com | techie   | 200    | true  | 1              | 1  | Location001  |


Scenario Outline: 01 POST a Location where “id” is "4" and “name” is "Location004". Then perform GET “locations/4”, assert “id” is “4”, “name” is “Locations004”, and Assert “OK” or “200” status.
	Given I am connecting to the api to login
	And I login using '<username>' and '<password>'
	And I get a <status> status and a <token>
	When I POST a location with <id> and name '<locationname>'
	When I call the api with locations and '<id>' and a token
	Then I get a <status> from locations
	And I expect <numoflocations> number of locations
	And I expect '<id>' and '<locationname>' 

	Examples: 
	| username         | password | status | token | numoflocations | id | locationname |
	| techie@email.com | techie   | 200    | true  | 1              | 4  | Location004  |


Scenario Outline: 02 PUT a Location where “id” is "4" and “name” is "Location05". Then perform GET “locations/4”, assert “id” is “4”, “name” is “Locations004”, and Assert “OK” or “200” status.
	Given I am connecting to the api to login
	And I login using '<username>' and '<password>'
	And I get a <status> status and a <token>
	When I PUT to <id> with name '<locationname>'
	When I call the api with locations and '<id>' and a token
	Then I get a <status> from locations
	And I expect <numoflocations> number of locations
	And I expect '<id>' and '<locationname>' 

	Examples: 
	| username         | password | status | token | numoflocations | id | locationname |
	| techie@email.com | techie   | 200    | true  | 1              | 4  | Location005  |


@login
Scenario Outline: 03 DELETE operation for "locations/4" and Assert “OK” or “200” status
	Given I am connecting to the api and I login using '<username>' and '<password>' and get <status>
	When I DELETE with id <id>
	Then I get status <status>

	Examples: 
	| username         | password | status  | id |
	| techie@email.com | techie   | 200		| 4  |