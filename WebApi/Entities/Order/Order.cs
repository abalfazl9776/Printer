using System;
using System.Collections.Generic;
using System.Text;
using Entities.Common;

namespace Entities.Order
{
    public class Order : BaseEntity
    {
        public Customer.Customer Customer { get; set; }

        public PrintingHouse.PrintingHouse PrintingHouse { get; set; }

        public Payment Payment { get; set; }

        public List<OrderLine> OrderLines { get; set; }
    }
}
