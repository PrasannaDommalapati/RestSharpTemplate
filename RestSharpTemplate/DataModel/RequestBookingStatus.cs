namespace RestSharpTemplate.DataModel
{
    public enum RequestBookingStatus
    {
        Confirmed = BookingStatus.Confirmed,
        Enquiry = BookingStatus.Enquiry,
        Provisional = BookingStatus.Provisional,
        Unknown = BookingStatus.Unknown,
        Temporary = BookingStatus.Temporary,
    }
}