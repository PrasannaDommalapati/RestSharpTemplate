namespace RestSharpTemplate.DataModel
{
    public class OutputResponse
    {
        public string ReferenceId { get; set; }

        public string RequesterId { get; set; }

        public string NextId { get; set; }

        public string Templates { get; set; }

        public string Status { get; set; }

        public string StatusMessage { get; set; }

        public string DateCreated { get; set; }

        public string DateModified { get; set; }

        public ActionLogResponse[] Actions { get; set; }
    }
}
