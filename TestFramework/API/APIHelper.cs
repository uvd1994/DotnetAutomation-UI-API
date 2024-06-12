using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.API
{
    public class APIHelper
    {

        public static IRestClient ApiClient()
        {
            var client = new RestClient();
            return client;
        }
    }
}
