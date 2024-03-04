using RestSharp;
using RestSharpTemplate.DataModel;
using RestSharpTemplate.DataModel.Occassions;
using RestSharpTemplate.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RestSharpTemplate._00_Setup
{
    public class CleanOccassions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly RunSettings _runSettings;

        public CleanOccassions(ScenarioContext scenarioContext, RunSettings runSettings)
        {
            _scenarioContext = scenarioContext;
            _runSettings = runSettings;
        }

        public async Task Action(RestClient restClient)
        {
            var accessToken = _scenarioContext.Get<string>(nameof(AuthResponse.AccessToken));
            var testOccassions = await GetAllTestOccassions(restClient, accessToken);

            if (testOccassions.Any())
            {
                DeleteOccasion(restClient,accessToken, testOccassions.ToList());
            }
        }

        public async Task<IEnumerable<Occasion>> GetAllTestOccassions(RestClient client, string accessToken)
        {
            var request = new RestRequest($"{_runSettings.CoreApiUrl}/api/v1/occasions/all", Method.Get);
            request.AddHeader("Accept", "text/plain");
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            var response = await client.ExecuteAsync(request);

            JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
            {
                WriteIndented = true
            };

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var occasionsResponse = JsonSerializer.Deserialize<OccasionResponse>(response.Content, options);
                return occasionsResponse.Items.FindAll(occ => occ.displayName.ToLower().Contains("test") || occ.description.ToLower().Contains("test"));
            }

            return Enumerable.Empty<Occasion>();
        }

        public void DeleteOccasion(RestClient client, string accessToken, List<Occasion> occassions)
        {
            occassions.ForEach( async occassion =>
            {
                var request = new RestRequest($"{_runSettings.CoreApiUrl}/estates/{_runSettings.EstateId}/occasions/{occassion.id}", Method.Delete);
                request.AddHeader("Accept", "text/plain");
                request.AddHeader("Authorization", $"Bearer {accessToken}");
                try
                {
                    var response = await client.ExecuteAsync(request);
                }
                catch (Exception ex)
                {

                    Console.Out.WriteLine($"{occassion.id} is deleted. with a message {ex.Message}");
                }

                //if (response.StatusCode == HttpStatusCode.NoContent)
                //{
                //    Console.Out.WriteLine($"{occassion.id} is deleted.");
                //}
            });
        }
    }
}
