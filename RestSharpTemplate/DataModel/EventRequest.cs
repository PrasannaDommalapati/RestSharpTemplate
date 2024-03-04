using Bogus;
using System;

namespace RestSharpTemplate.DataModel
{
    public class EventRequest
    {
        private Faker _faker = new();

        public Guid? OccasionId { get; set; }
        public Guid? AreaId { get; set; }
        public Guid? MenuId { get; set; }
        public string EventPlanName { get; set; }
        public string CompanyName { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public DateTime DateTime { get; set; }
        public int AdultCovers { get; set; }
        public int ChildCovers { get; set; }
        public string Session { get; set; }
        public string CustomerNotes { get; set; }
        public string BookingNotes { get; set; }
        public string SpecialRequest { get; set; }
        public RequestBookingStatus? Status { get; set; }
        public Consent Consent { get; set; }


        public EventRequest Create()
        {
            Firstname = _faker.Person.FirstName;
            Surname = _faker.Person.LastName;
            Email = _faker.Person.Email;
            DateTime = _faker.Date.SoonDateOnly(5).ToDateTime(TimeOnly.MinValue);
            MenuId = Guid.NewGuid();
            OccasionId = Guid.NewGuid();
            AreaId = Guid.NewGuid();
            Status = RequestBookingStatus.Provisional;

            return this;
        }

        public EventRequest WithAdultCovers(int adultCount)
        {
            AdultCovers = adultCount;
            return this;
        }

        public EventRequest WithChildCovers(int childCount)
        {
            ChildCovers = childCount;
            return this;
        }

        public EventRequest WithArea(Guid areaId)
        {
            AreaId = areaId;
            return this;
        }

        public EventRequest WithOccassion(Guid occassionId)
        {
            OccasionId = occassionId;
            return this;
        }

        public EventRequest WithTelephone()
        {
            Telephone = _faker.Phone.PhoneNumber();
            return this;
        }
    }
}