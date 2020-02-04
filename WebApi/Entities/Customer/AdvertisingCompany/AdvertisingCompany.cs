using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Customer.AdvertisingCompany
{
    public class AdvertisingCompany : Customer<AdvertisingCompany>
    {
        public String Name { get; set; }

        public long LicenseNumber { get; set; }
    }
}
