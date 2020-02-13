using System;
using System.Collections.Generic;
using System.Text;
using Entities.Common;

namespace Entities.Order
{
    public class Order : BaseEntity
    {
        public DateTime DateTime { get; set; }

        public long TotalPrice { get; set; }


        public int CustomerId { get; set; }
        public int PrintingHouseId { get; set; }
        public int PaymentId { get; set; }


        public Customer.Customer Customer { get; set; }

        public PrintingHouse.PrintingHouse PrintingHouse { get; set; }

        public Payment Payment { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; }
    }
}
