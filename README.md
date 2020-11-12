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

    - Required Nuget Packages: Specflow for the BDD Feature file. To make HTTP Requests you can choose either RestSharp or HTTP Client (using System.Net.Http). 

    - For the Test Runner choose either Nunit or Xunit. 

    - Any other packages you would like to use feel free to use them.

    - Test that you can login to the API with Email: “techie@email.com” and Password: “techie”

    - Test GET all Locations. Assert “OK” or “200” status.
	
    - Test GET a Location where “id” is “1”. Then assert that “id” is “1”, “name” is “Location001” and assert “OK” or “200” status.

    - Test POST a Location where “id” is "4" and “name” is "Location004". Then perform GET “locations/4”, assert “id” is “4”, “name” is “Locations004”, and Assert “OK” or “200” status.
    
    - Test PUT for "locations/4" where “id” is "4" and “name” is "Location005". Then GET operation for "locations/4", assert "id" is "4", "name" is "Location005" and Assert “OK” or “200” status.
    
    - Test DELETE operation for "locations/4" and Assert “OK” or “200” status.

## Further Notes

    - We recommend you distil the above Acceptance Criteria into Specflow BDD Gherkin format with a value statement: As, I, So

    - It is up to you how you write the Scenarios, we do recommend that you follow the above in order so you should end up with the “locations” endpoint the same as before, so you can re-run the test as many times as you like.

    - Please complete your project to a standard that you would consider complete for a production system.

    - Include a Readme with clear instructions on how to build and run your tests.

    - You do not need to include the Fake JSON Server project in your submission. 

    - Please do not include any binary files in your submission.

    - Once complete, zip up your project and upload it to a Google Drive folder, then email us the link. 

    - Include your full name in the zip file i.e. “<your-name>.euromoney.api.tests.zip”. 

    - If your tests are on Github or another repository, please set it to Private 




