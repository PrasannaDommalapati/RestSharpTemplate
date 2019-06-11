using System;

namespace RestSharpTemplate.DataModel
{
    public class ActionLogResponse
    {
        public int Action { get; set; }

        public string ActionMessage { get; set; }

        public string Time { get; set; }

        public string Explanation { get; set; }
    }
}
