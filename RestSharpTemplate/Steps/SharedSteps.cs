using RestSharp;
using RestSharpTemplate.DataModel;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RestSharpTemplate.Steps
{
    [Binding]
    public class SharedSteps
    {
        public readonly string _adminWebUrl;
        private readonly RestClient _restClient;
        private readonly RunSettings _runSettings;
        private readonly ScenarioContext _scenarioContext;


        public SharedSteps(RestClient restClient, RunSettings runSettings, ScenarioContext scenarioContext)
        {
            _restClient = restClient;
            _runSettings = runSettings;
            _scenarioContext = scenarioContext;
        }

        [Given(@"I have a valid authorization token")]
        public async Task GivenIHaveAValidAuthorizationToken()
        {
            var request = new RestRequest($"{_runSettings.AdminWebUrl}/api/authentication/token", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "text/plain");
            
            request.AddJsonBody(new AuthRequest
            {
                UserName = _runSettings.EventsHostUserName,
                Password = _runSettings.EventsHostPassword
            });
            RestResponse response = await _restClient.ExecuteAsync(request);

            JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
            {
                WriteIndented = true
            };

            if(response.StatusCode == HttpStatusCode.OK)
            {
                var authResponse = JsonSerializer.Deserialize<AuthResponse>(response.Content, options);
                _scenarioContext.Add(nameof(AuthResponse.AccessToken), authResponse.AccessToken);
            }
        }
    }
}
