using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace EuromoneyAPITest.Utils
{
   public class APIHelpers
    {
        public static RestClient client;
        static APIHelpers()
        {
            string uri = "http://localhost:8000/";
            client = new RestClient(uri);
        }

        public static IRestResponse<T> GetRequest<T>(string path, string token)
        {
            var request = new RestRequest(path, Method.GET, DataFormat.Json);
            request.AddHeader("authorization", "Bearer " + token);
            var response = client.Execute<T>(request);
            return response;
        }

        public static IRestResponse PostRequest(string path, string payload, string token = "")
        {
            var request = new RestRequest(path, DataFormat.Json);
            if(!string.IsNullOrEmpty(token))
                request.AddHeader("authorization", "Bearer " + token);
            request.AddJsonBody(payload);
            var response = client.Post(request);
            return response;
        }

        public static IRestResponse PutRequest(string path, string payload, string token = "")
        {
            var request = new RestRequest(path, DataFormat.Json);
            if (!string.IsNullOrEmpty(token))
                request.AddHeader("authorization", "Bearer " + token);
            request.AddJsonBody(payload);
            var response = client.Put(request);
            return response;
        }
    }
}
