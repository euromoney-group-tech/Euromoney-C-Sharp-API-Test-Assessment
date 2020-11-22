using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EuromoneyAPITest.Models
{
    public class User
    {
       public string Email { get; set; }
       public string Password { get; set; }
        public User()
        {
            Email = "techie@email.com";
            Password = "techie";
        }

    }

    public class Location
    {
        public int id { get; set; }
        public string name { get; set; }
    }
   
}
