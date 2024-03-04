using RestSharp;
using RestSharpTemplate._00_Setup;
using RestSharpTemplate.DataModel;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RestSharpTemplate.Steps
{
    [Binding]
    public class CancelBookingSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly RestClient _restClient;
        public RunSettings _runSettings;

        public CancelBookingSteps(RestClient restClient, RunSettings runSettings, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _restClient = restClient;
            _runSettings = runSettings;
        }
        [Given(@"I have a booking with deposit requirement")]
        public async Task GivenIHaveABookingWithDepositRequirement()
        {
            await new CleanOccassions(_scenarioContext, _runSettings).Action(_restClient);
            //var test = new EventRequest().Create()
            //                             .WithAdultCovers(2)
            //                             .WithChildCovers(1)
            //                             .WithOccassion(Guid.NewGuid())
            //                             .WithArea(Guid.NewGuid());
        }

        [When(@"I Cancel the Booking from event host")]
        public void WhenICancelTheBookingFromEventHost()
        {
            throw new PendingStepException();
        }

        [Then(@"I should see the booking is cancelled")]
        public void ThenIShouldSeeTheBookingIsCancelled()
        {
            throw new PendingStepException();
        }
    }
}
