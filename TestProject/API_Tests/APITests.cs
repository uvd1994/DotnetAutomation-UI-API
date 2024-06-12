using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using System;
using System.Net;
using System.Threading;
using TestFramework.API;
using TestFramework.Core;
using TestFramework.Exceptions;
using TestProject.UI_Tests;
using TestProject.Views;

namespace TestProject
{
    public class APITests : BaseTest
    {
        [Test]
        public void APITest1()
        {
            var request = new RestRequest("https://bar.bagconsult.eu/api/Order");

            var response = APIHelper.ApiClient().ExecuteGet(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new AutomationException("test");
            }
            
        }
    
    }
}