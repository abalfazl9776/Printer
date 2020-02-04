using System;
using System.Collections.Generic;
using System.Text;
using Entities.Common;

namespace Entities.Customer.AdvertisingCompany
{
    public class AdvertisingCompany : Customer<AdvertisingCompany>, IEntity
    {
        public String Name { get; set; }

        public long LicenseNumber { get; set; }
    }
}
