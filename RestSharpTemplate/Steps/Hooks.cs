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
        private IRestClient Client;
        public TestContext TestContext { get; set; }


        public Hooks(IObjectContainer objectContainer,TestContext context)
        {
            TestContext = context;
            ObjectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            string env = TestContext.Properties["Environment"].ToString();
            Client = new RestClient(TestContext.Properties[$"{env}:Endpoint"].ToString());
            ObjectContainer.RegisterInstanceAs<IRestClient>(Client);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("After scenario");
        }
    }
}
