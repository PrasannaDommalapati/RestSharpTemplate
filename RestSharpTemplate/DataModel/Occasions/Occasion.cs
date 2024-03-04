using System.Collections.Generic;

namespace RestSharpTemplate.DataModel.Occassions
{
    public class Occasion
    {
        public string id { get; set; }
        public string estateId { get; set; }
        public string displayName { get; set; }
        public string internalName { get; set; }
        public string description { get; set; }
        public int? minimumAllowableCovers { get; set; }
        public object maximumAllowableCovers { get; set; }
        public bool hostChannel { get; set; }
        public bool apiChannel { get; set; }
        public bool widgetChannel { get; set; }
        public bool tablesChannel { get; set; }
        public object minimumNoticeBooking { get; set; }
        public object maximumAdvanceBooking { get; set; }
        public object associatedOutlets { get; set; }
        public object schedule { get; set; }
        public List<object> imageLinks { get; set; }
        public object emailTemplate { get; set; }
        public int? turnTimeMinutes { get; set; }
        public object links { get; set; }
        public bool disableConfirmationMessages { get; set; }
    }
}
