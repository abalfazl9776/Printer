using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Client;
using Entities.Common;

namespace Entities.Customer
{
    public class Customer : Client.Client
    {
        public int  test { get; set; }

        public string Discriminator { get; set; }

    }
    
}
