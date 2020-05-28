using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RestSharpTemplate.Steps.HttpClient
{
    [Binding]
    public sealed class PostRequestSteps
    {
        public string BaseAddress { get; set; }

        private HttpResponseMessage ResponseMessage { get; set; }

        public PostRequestSteps(TestContext testContext)
        {
            BaseAddress = testContext.Properties["api.address"].ToString();
        }

        [When("I post the request")]
        public async Task WhenIPostTheRequest()
        {
            var data = JsonSerializer.Serialize(new { });
            var uri = new Uri($"{BaseAddress}/api/users");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = uri,
                Content = new StringContent(data, Encoding.UTF8, MediaTypeNames.Application.Json)
            };

            ResponseMessage = await Helper.SendAsync(request).ConfigureAwait(false);
        }

        [Then("I hould get the status code '(.*)'")]
        public void ThenIHouldGetTheStatusCode(string statusCode)
        {
            Assert.AreEqual(statusCode, ResponseMessage.StatusCode);
        }
    }
}
