using System;
using System.Collections.Generic;
using System.Text;
using Entities.Common;
using Entities.Service;
using Attribute = System.Attribute;

namespace Entities.Order
{
    public class OrderLine : BaseEntity
    {
        public long Price { get; set; }

        public int CategoryId { get; set; }
        public int AttributeId { get; set; }
        public int OrderId { get; set; }

        public Category Category { get; set; }

        public Service.Attribute Attribute { get; set; }
    }
}
