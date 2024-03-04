using System;
using System.Collections.Generic;

namespace RestSharpTemplate.DataModel
{
    public class Consent
    {
        public List<ConsentItem> Items { get; set; }
    }

    public class ConsentItem
    {
        public string ConsentText { get; set; }
        public string ConsentUrl { get; set; }
        public bool? ConsentGiven { get; set; }

        public DateTime? ConsentDateTime { get; set; }
        public ConsentType? ConsentType { get; set; }
    }

    public enum ConsentType
    {
        Email = 0,
        Phone = 1,
        Sms = 2,
        Postal = 3,
        Push = 4,
        Profiling = 5,
        PrivacyStatement = 6,
        ConsentStatement = 7
    }
}