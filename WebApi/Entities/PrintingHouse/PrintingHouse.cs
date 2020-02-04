using System;
using System.Collections.Generic;
using System.Text;
using Entities.Common;

namespace Entities.PrintingHouse
{
    public class PrintingHouse : BaseEntity
    {
        public User.User User { get; set; }

        public String Name { get; set; }

        public long LicenseNumber { get; set; }

        public Address<PrintingHouse> Address { get; set; }

    }
}
