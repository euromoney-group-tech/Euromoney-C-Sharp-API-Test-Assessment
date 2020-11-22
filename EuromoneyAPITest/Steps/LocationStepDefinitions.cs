using EuromoneyAPITest.Models;
using EuromoneyAPITest.Utils;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace EuromoneyAPITest.Steps
{
    [Binding]
    public sealed class LocationStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private string token;

        public LocationStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I login as an API user")]
        public void GivenILoginAsAAPIUser()
        {
            // auth/login not returning the expected token for techie@email.com but instead auth/register is used
            var path = "auth/register";
            var data = new User();
            string payload = JsonHelpers.ConvertObjToJson(data);
            var response = APIHelpers.PostRequest(path,payload);
            token = JsonHelpers.GetJsonKeyValue(response.Content, "access_token");
        }

        [When(@"I retrieve all locations")]
        public void WhenIRetrieveAllLocations()
        {
            var path = "locations";
            var response = APIHelpers.GetRequest<List<Location>>(path,token);
            _scenarioContext["Response"] = response;
        }

        [When(@"I retrieve a  location for Id ""(.*)""")]
        public void WhenIRetrieveALocationForId(string id)
        {
            var path = string.Format("locations/{0}",id);
            var response = APIHelpers.GetRequest<Location>(path, token);
            _scenarioContext["Response"] = response;
        }

        [When(@"I add a new location ""(.*)""")]      
        public void WhenIAddANewLocation(string location)
        {
            var path = "locations";
            var data = new Location()
            {
                name = location
            };
            string payload = JsonHelpers.ConvertObjToJson(data);       
            APIHelpers.PostRequest(path, payload,token);
        }

        [When(@"I update a location to ""(.*)"" for Id ""(.*)""")]
        public void WhenIUpdateALocationToForId(string location, string Id)
        {
            var path = string.Format("locations/{0}", Id);
            var data = new Location()
            {
                name = location
            };
            string payload = JsonHelpers.ConvertObjToJson(data);
            APIHelpers.PutRequest(path, payload, token);
        }


        [Then(@"I expect status code to be ""(.*)""")]
        public void ThenIExpectStatusCodeToBe(int responseCode)
        {
            Assert.AreEqual(responseCode, (int)((IRestResponse)_scenarioContext["Response"]).StatusCode);
        }

        [Then(@"I expect the location name to be ""(.*)""")]
        public void ThenIExpectTheLocationNameToBe(string locationName)
        {
            Assert.AreEqual (locationName,((IRestResponse<Location>)_scenarioContext["Response"]).Data.name);            
        }


    }
}
