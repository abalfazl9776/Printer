using System;
using System.Collections.Generic;
using System.Text;
using Entities.Common;
using Entities.Service;

namespace Entities.Order
{
    public class OrderLine : BaseEntity
    {
        public int CategoryId { get; set; }
        public int PrintingHouseId { get; set; }
        public int AttributeId { get; set; }
        public int OrderId { get; set; }


        public Category Category { get; set; }
        public PrintingHouse.PrintingHouse PrintingHouse { get; set; }
        public Order Order { get; set; }

        public Service.Attribute Attribute { get; set; }
    }
}
