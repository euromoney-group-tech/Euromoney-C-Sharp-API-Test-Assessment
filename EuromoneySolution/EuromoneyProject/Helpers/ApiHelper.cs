using System.Net;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;


namespace EuromoneyProject.Helpers
{

        public class ApiHelper
        {


            public RestClient restClient;
            public RestRequest restRequest;


            public T DeserialiseResponse<T>(IRestResponse response)
            {
                var deserialiser = new JsonDeserializer();
                return deserialiser.Deserialize<T>(response);
            }

            public void CheckHttpCodeResponse(HttpStatusCode expectedCode, HttpStatusCode actualCode)
            {

                Assert.AreEqual(expectedCode, actualCode);
            }

        }
    

}
