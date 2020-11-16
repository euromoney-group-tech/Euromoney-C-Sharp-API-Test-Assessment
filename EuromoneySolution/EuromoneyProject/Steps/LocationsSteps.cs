using System.Net;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System;
using EuromoneyProject.Helpers;

namespace EuromoneyProject
{
    [Binding]
    public partial class LocationsSteps
    {
        private IRestClient _restClient;
        private IRestRequest _request;
        IRestResponse response;

        //context sharing through lightweight dependency injection/creating objects and using them in each method below
        private Login _responseLogin;
        private List<Locations> _responseLocations;
        private string _url;
        string url = "http://localhost:8000";
        string loginEndpoint = "/auth/login";
        ApiHelper helper = new ApiHelper();


        //context sharing through scenario context object
        private readonly ScenarioContext _scenarioContext;


        public LocationsSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
        }

        [Given(@"I am connecting to the api and I login using '(.*)' and '(.*)' and get (.*)")]
        public void GivenIamConnectingToTheApiAndILoginUsing(string username, string password, int statusExpected)
        {
            //create request
            _url = url + loginEndpoint;
            _restClient = new RestClient(_url);
            _request = new RestRequest(Method.POST);
            _request.AddParameter("email", username);
            _request.AddParameter("password", password);

            //execute request
            IRestResponse response = _restClient.Execute(_request);

            //deserialise and get response
            _responseLogin = helper.DeserialiseResponse<Login>(response);

            //asserts on response content
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var statusActual = (int)response.StatusCode;
            Assert.AreEqual(statusExpected, statusActual);
            Assert.NotNull(_responseLogin.access_token);
            _scenarioContext["token"] = _responseLogin.access_token;
            Console.WriteLine(_scenarioContext["token"]);

        }

        [Given(@"I am connecting to the api to login")]
        public void GivenIAmConnectingToHttpLocalhostToLoginToAuthLogin()
        {
            _url = url + loginEndpoint;
            _restClient = new RestClient(_url);
            _request = new RestRequest(Method.POST);
        }
        
        [When(@"I login using '(.*)' and '(.*)'")]
        [Given(@"I login using '(.*)' and '(.*)'")]

        public void WhenILoginUsingTechieEmail_ComAndTechie(string username, string password)
        {
            _request.AddParameter("email", username);
            _request.AddParameter("password", password);

        }

        [Then(@"I get a (.*) status and a (.*)")]
        [Given(@"I get a (.*) status and a (.*)")]
        public void ThenIGetAStatusAndAToken(int statusExpected, bool token)
        {
            IRestResponse response = _restClient.Execute(_request);
            var deserialiser = new JsonDeserializer();
            _responseLogin = deserialiser.Deserialize<Login>(response);


            if(token)
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                var statusActual = (int)response.StatusCode;
                Assert.AreEqual(statusExpected, statusActual);
                Assert.NotNull(_responseLogin.access_token);
            }
            else
            {
                Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
                var statusActual = (int)response.StatusCode;
                Assert.AreEqual(statusExpected, statusActual);

            }


        }



        [When(@"I call the api with locations and '(.*)' and a token")]
        public void WhenICallAllLocationsWithAndAToken(string id)
        {
            _url = "http://localhost:8000/locations/"+id;
            _restClient = new RestClient(_url);
            _request = new RestRequest(Method.GET);
            _restClient.AddDefaultHeader("Authorization", string.Format("Bearer {0}", _responseLogin.access_token));
            _request.AddHeader("Accept", "application/json");

        }


        [Then(@"I get a (.*) from locations")]
        public void ThenIGetAFromLocations(int statusExpected)
        {
            IRestResponse response = _restClient.Execute(_request);
            var deserialiser = new JsonDeserializer();
            _responseLocations = deserialiser.Deserialize<List<Locations>>(response);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var statusActual = (int)response.StatusCode;
            Assert.AreEqual(statusExpected, statusActual);
        }

        [Then(@"I expect (.*) number of locations")]
        public void ThenIExpectNumberOfLocations(int numOfLocations)
        {
            
            Assert.AreEqual(numOfLocations, _responseLocations.Count);


        }


        [Then(@"I expect '(.*)' and '(.*)'")]
        public void ThenIExpectAnd(int id, string name)
        {
            Assert.AreEqual(id, _responseLocations[0].id);
            Assert.AreEqual(name, _responseLocations[0].name);
        }


        [When(@"I POST a location with (.*) and name '(.*)'"), Order(1)]
        public void WhenIPOSTALocationWithAndName(int idToSend, string nameToSend)
        {
            _url = "http://localhost:8000/locations/";
            _restClient = new RestClient(_url);
            _request = new RestRequest(Method.POST);
            _restClient.AddDefaultHeader("Authorization", string.Format("Bearer {0}", _responseLogin.access_token));
            var body = new
            {
                id = idToSend,
                name = nameToSend
            };

            _request.AddJsonBody(body);

            IRestResponse response = _restClient.Execute(_request);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [When(@"I PUT to (.*) with name '(.*)'"), Order(2)]
        public void WhenIPUTtoWithName(int idToSend, string nameToSend)
        {
            _url = "http://localhost:8000/locations/" + idToSend;
            _restClient = new RestClient(_url);
            _request = new RestRequest(Method.PUT);
            _restClient.AddDefaultHeader("Authorization", string.Format("Bearer {0}", _responseLogin.access_token));

            var body = new
            {
                name = nameToSend
            };
            _request.AddJsonBody(body);

            IRestResponse response = _restClient.Execute(_request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }


        [When(@"I DELETE with id (.*)")]
        [Then(@"I DELETE with id (.*)")]
        public void WhenIDeleteWithId(int idToSend)
        {
            _url = "http://localhost:8000/locations/" + idToSend;
            _restClient = new RestClient(_url);
            _request = new RestRequest(Method.DELETE);
            _restClient.AddDefaultHeader("Authorization", string.Format("Bearer {0}", _responseLogin.access_token));

            response = _restClient.Execute(_request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Then(@"I get status (.*)")]
        public void ThenIGetStatus(int statusExpected)
        {
            var statusActual = (int)response.StatusCode;
            Assert.AreEqual(statusExpected, statusActual);

        }

        [Given(@"I have location (.*) '(.*)' available in the API")]
        public void IHaveLocationAvailableInTheApi(int id, string name)
        {
            WhenIPOSTALocationWithAndName(id, name);

        }


    }
}
