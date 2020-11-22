using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace EuromoneyAPITest.Utils
{
    public class JsonHelpers
    {
        public static string ConvertObjToJson(Object obj)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            return JsonSerializer.Serialize(obj, options);
        }
        
        public static string GetJsonKeyValue(string content, string key)
        {
            var jObject = JObject.Parse(content);
            //Extracting Node element using Getvalue method
           return jObject.GetValue(key).ToString();

        }

    }
}
