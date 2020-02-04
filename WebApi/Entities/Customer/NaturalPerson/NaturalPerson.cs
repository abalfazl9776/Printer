using System;
using System.Collections.Generic;
using System.Text;
using Entities.Common;

namespace Entities.Customer.NaturalPerson
{
    public class NaturalPerson : Customer<NaturalPerson>, IEntity
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }

    }
}
