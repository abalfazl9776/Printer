using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Client;
using Entities.Common;
using Entities.User;

namespace Entities.Customer
{
    public class Customer : Client.Client
    {
        public string AcName { get; set; }

        public long AcLicenseNumber { get; set; }

        public PredefinedRoles DiscriminatorRole { get; set; }
    }
    
}
