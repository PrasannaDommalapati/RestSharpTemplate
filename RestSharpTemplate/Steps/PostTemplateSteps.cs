using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace RestSharpTemplate.Steps
{
    [Binding]
    public class PostTemplateSteps
    {
        private readonly IRestClient Client;
        private IRestRequest Request;
        private IRestResponse<Guid> response;
        public TestContext TestContext { get; set; }

        private string RequestType { get; set; }
        private string RequestsCount { get; set; }
        private string User { get; set; }
        private string BusinessApplication { get; set; }
        private string BusinessUnit { get; set; }
        private string Entity { get; set; }
        private string[] Templates { get; set; }
        private Dictionary<string, string> Metadata { get; set; }

        public PostTemplateSteps(IRestClient client, TestContext context)
        {
            Client = client;
            TestContext = context;
        }

        [When("I request outputs with '(.*)'")]
        public void WhenIRequestOutputsWith(string fileName)
        {
            Request = Helper.SetUpRequest("requests", Method.POST, TestContext);

            RequestsCount = TestContext.Properties[$"{nameof(RequestsCount)}"].ToString();
            _ = int.TryParse(RequestsCount, out int count);

            string base64Data = fileName.GetBase64Template();

            if (base64Data == null)
                throw new ArgumentNullException(nameof(fileName));

            RequestType = TestContext.Properties[$"{nameof(RequestType)}"].ToString();
            User = TestContext.Properties[$"{RequestType}:{nameof(User)}"].ToString();
            BusinessApplication = TestContext.Properties[$"{RequestType}:{nameof(BusinessApplication)}"].ToString();
            BusinessUnit = TestContext.Properties[$"{RequestType}:{nameof(BusinessUnit)}"].ToString();
            Entity = TestContext.Properties[$"{RequestType}:{nameof(Entity)}"].ToString();
            Templates = new string[] { TestContext.Properties[$"{RequestType}:{nameof(Templates)}"].ToString() };

            Request.AddJsonBody(new
                {
                    requesterId = fileName,
                    data = base64Data,
                    user = User,
                    businessApplication = BusinessApplication,
                    entity = Entity,
                    businessUnit = BusinessUnit,
                    metadata = new
                    {
                        requester = fileName,
                        type = "auto"
                    },
                    templates = Templates
                });
           

            for (int i = 0; i < count; i++)
            {
                response = Client.Execute<Guid>(Request);
            }
        }

        [When(@"I request outputs with json Format '(.*)'")]
        public void WhenIRequestOutputsWithJsonFormat(string fileName)
        {
            var requestList = fileName.RequestList();

            foreach (var request in requestList)
            {
                Request = Helper.SetUpRequest("requests", Method.POST, TestContext);
                dynamic body = JObject.Parse(request);
                string data = body.data;
                string requesterId = body.requesterId;
                Request.AddJsonBody(new
                {
                    requesterId,
                    data
                });
                response = Client.Execute<Guid>(Request);
            }

        }

        [Then("I should receive status code '(.*)'")]
        public void ThenIShouldReceiveStatusCode(string statusCode)
        {
            Assert.AreEqual(statusCode, response.StatusCode.ToString());

            Assert.IsTrue(Guid.TryParse(
                response.Data.ToString(),
                out Guid guid), $"Expected Guid actual value:'{response.Data}'");
        }
    }
}
