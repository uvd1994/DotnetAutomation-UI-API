using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using TestFramework.API;
using TestFramework.Core;
using TestFramework.Exceptions;
using TestFramework.Models;
using TestProject.UI_Tests;
using TestProject.Views;

namespace TestProject
{
    public class APITests : APIBaseTest
    {
        [Test]
        public void APIGetTestSchemaValidation()
        {
            var request = new RestRequest("https://bar.bagconsult.eu/api/Order");

            var response = APIHelper.ApiClient().ExecuteGet<List<ResponseModel>>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new AutomationException("get failed");
            }
            var respDataDeserialised = JsonConvert.DeserializeObject<List<ResponseModel>>(response.Content);

            foreach(var item in respDataDeserialised)
            {
                var resource = "https://bar.bagconsult.eu/api/Order" + "/" + item.Id;
                request = new RestRequest(resource);

                var itemResponse = APIHelper.ApiClient().ExecuteGet<ResponseModel>(request);
                if (itemResponse.StatusCode != HttpStatusCode.OK)
                {
                    throw new AutomationException("get failed");
                }

                //Schema Validation
                var path = AppDomain.CurrentDomain.BaseDirectory;
                string jsonSchemaPath = path.Replace("TestProject\\TestProject\\bin\\Debug\\net6.0\\", "TestProject\\TestFramework\\Models\\schemasampleresponseget.txt");
                var schema = File.ReadAllText(jsonSchemaPath);
                JSchema schemaJson = JSchema.Parse(schema);
                JToken jToken = JToken.Parse(itemResponse.Content);
                Assert.IsTrue(jToken.IsValid(schemaJson));

            }
        }

        [Test]
        public void APIPostTestWithSubSequentGetTest()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            string jsonPath = path.Replace("TestProject\\TestProject\\bin\\Debug\\net6.0\\", "TestProject\\TestFramework\\TestData\\inputjsonpostapi.json");
            var inputJson = File.ReadAllText(jsonPath);

            var request = new RestRequest("https://bar.bagconsult.eu/api/Order");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(inputJson);

            var response = APIHelper.ApiClient().ExecutePost<List<ResponseModel>>(request);
            if (response.StatusCode != HttpStatusCode.Created)
            {
                throw new AutomationException("post failed");
            }
            var respDataDeserialised = JsonConvert.DeserializeObject<ResponseModel>(response.Content);
            request = new RestRequest("https://bar.bagconsult.eu/api/Order"+"/"+ respDataDeserialised.Id);

            response = APIHelper.ApiClient().ExecuteGet<List<ResponseModel>>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new AutomationException("get failed after post creation API");
            }
        }

        [Test]
        public void APIPostTestWithSubSequentDeleteTest()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            string jsonPath = path.Replace("TestProject\\TestProject\\bin\\Debug\\net6.0\\", "TestProject\\TestFramework\\TestData\\inputjsonpostapi.json");
            var inputJson = File.ReadAllText(jsonPath);

            var request = new RestRequest("https://bar.bagconsult.eu/api/Order");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(inputJson);

            var response = APIHelper.ApiClient().ExecutePost<List<ResponseModel>>(request);
            if (response.StatusCode != HttpStatusCode.Created)
            {
                throw new AutomationException("post failed");
            }
            var respDataDeserialised = JsonConvert.DeserializeObject<ResponseModel>(response.Content);
            request = new RestRequest("https://bar.bagconsult.eu/api/Order" + "/" + respDataDeserialised.Id);

            var deleteResponse = APIHelper.ApiClient().ExecuteDelete<ResponseModel>(request);

            if (deleteResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new AutomationException("delete failed after post creation API because" + deleteResponse.StatusCode + " is received from delete api");
            }
        }

    }
}