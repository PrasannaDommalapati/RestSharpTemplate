using BoDi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace RestSharpTemplate.Steps
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer ObjectContainer;
        private RestClient _restClient;
        public TestContext TestContext { get; set; }
        public RunSettings _runSettings { get; set; }


        public Hooks(IObjectContainer objectContainer, TestContext context)
        {
            TestContext = context;
            ObjectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _runSettings = new RunSettings
            {
                AdminWebUrl = TestContext.Properties[nameof(RunSettings.AdminWebUrl)].ToString(),
                CoreApiUrl = TestContext.Properties[nameof(RunSettings.CoreApiUrl)].ToString(),
                EventsHostUserName = TestContext.Properties[nameof(RunSettings.EventsHostUserName)].ToString(),
                EventsHostPassword = TestContext.Properties[nameof(RunSettings.EventsHostPassword)].ToString(),
                EstateId = Guid.Parse(TestContext.Properties[nameof(RunSettings.EstateId)].ToString()),
                CompanyId = Guid.Parse(TestContext.Properties[nameof(RunSettings.CompanyId)].ToString()),
                SiteId = Guid.Parse(TestContext.Properties[nameof(RunSettings.SiteId)].ToString()),
            };
            _restClient = new RestClient();
            ObjectContainer.RegisterInstanceAs(_restClient);
            ObjectContainer.RegisterInstanceAs(_runSettings);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("After scenario");
        }
    }
}
