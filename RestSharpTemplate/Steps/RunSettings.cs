using System;

namespace RestSharpTemplate.Steps
{
    public class RunSettings
    {
        public string AdminWebUrl { get; internal set; }
        public string CoreApiUrl { get; internal set; }
        public string EventsHostUserName { get; internal set; }
        public string EventsHostPassword { get; internal set; }
        public Guid EstateId { get; internal set; }
        public Guid CompanyId { get; internal set; }
        public Guid SiteId { get; internal set; }
    }
}