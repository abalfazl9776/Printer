using Entities.Common;

namespace Entities.Client
{
    public class Address : BaseEntity
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string MainStreet { get; set; }
        public string SubStreet { get; set; }
        public string HouseNumber { get; set; }
        public string BuildingName { get; set; }
        public string Unit { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }

        public User.User User { get; set; }
    }
}