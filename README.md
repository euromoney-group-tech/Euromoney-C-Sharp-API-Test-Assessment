## Euromoney C# API Test Assessment

## Prerequisites 

    Setup a Fake JSON Server, see https://github.com/techiediaries/fake-api-jwt-json-server

    Follow the instructions to clone and start the Server on your local machine

## Assessment Task	

    We would like you to write a BDD Specflow API test in C# using Visual Studio IDE for the Endpoint “locations” which demonstrate CRUD: 
    
    - Create(POST) 
    
    - Read(GET) 
    
    - Update(PUT) 
    
    - Delete    
    

---

    "locations": [
            {
            "id": 1,
            "name": "Location001"
            },
            {
            "id": 2,
            "name": "Location002"
            },
            {
            "id": 3,
            "name": "Location003"
            }
        ],

---

## Acceptance Criteria

    - Test that you can login to the API with Email: “techie@email.com” and Password: “techie”

    - Test GET all Locations. Assert “OK” or “200” status.
	
    - Test GET a Location where “id” is “1”. Then assert that “id” is “1”, “name” is “Location001” and assert “OK” or “200” status.

    - Test POST a Location where “id” is "4" and “name” is "Location004". Then perform GET “locations/4”, assert “id” is “4”, “name” is “Locations004”, and Assert “OK” or “200” status.
    
    - Test PUT for "locations/4" where “id” is "4" and “name” is "Location005". Then GET operation for "locations/4", assert "id" is "4", "name" is "Location005" and Assert “OK” or “200” status.
    
    - Test DELETE operation for "locations/4" and Assert “OK” or “200” status.

## Further Notes

    - Please clone this repo, create a branch and then submit your effort as a pull request to this repo
    
    - Required Nuget Packages: Specflow for the BDD Feature file.  

    - For the test runner choose either Nunit or Xunit. 

    - Any other packages you would like to use feel free to use them.





