using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpTemplate.DataModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Bogus;

namespace RestSharpTemplate
{
    public static class Helper
    {

        public static Authorisation Authorisation;
        public static RestRequest Request { get; set; }

        public static string Api_Subscription { get; set; }

        public static TestContext TestContext { get; set; }

        public static Authorisation Auth(TestContext context)
        {
            string env = context.Properties["Environment"].ToString();

            Authorisation = new Authorisation
            {
                Endpoint = context.Properties[$"{env}:Endpoint"].ToString(),
                Subscription = context.Properties[$"{env}:Subscription"].ToString()
            };

            return Authorisation;
        }

        public static Authorisation NoAuth(TestContext context)
        {
            string env = context.Properties["Environment"].ToString();

            Authorisation = new Authorisation
            {
                Endpoint = context.Properties[$"{env}:Endpoint"].ToString(),
                Subscription = context.Properties["NoSubscription"].ToString()
            };

            return Authorisation;
        }

        public static RestRequest SetUpRequest(string relativeUri, Method methodType, TestContext testContext)
        {
            Request = new RestRequest(relativeUri, methodType);
            Request.AddHeader("Ocp-Apim-Trace", "true");
            Request.AddHeader("Ocp-Apim-Subscription-Key", Auth(testContext).Subscription);
            Request.AddHeader("Content-Type", "application/json;");

            return Request;
        }

        public static async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.SendAsync(requestMessage, CancellationToken.None).ConfigureAwait(false);
            }
        }

        public static string GetRootDir()
        {
            var currentDir = Directory.GetCurrentDirectory();
            return currentDir.Split("bin")[0];
        }
    }
}
