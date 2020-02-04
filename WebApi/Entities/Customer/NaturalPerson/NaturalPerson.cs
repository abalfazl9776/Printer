using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Customer.NaturalPerson
{
    public class NaturalPerson : Customer<NaturalPerson>
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }

    }
}
