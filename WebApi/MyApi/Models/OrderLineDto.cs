using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Order;
using WebFramework.Api;

namespace MyApi.Models
{
    public class OrderLineDto : BaseDto<OrderLineDto, OrderLine>
    {
        public int CategoryId { get; set; }
        public int PrintingHouseId { get; set; }
        public int AttributeId { get; set; }
        public int OrderId { get; set; }

        public AttributeDto AttributeDto { get; set; }
    }

    public class OrderLineSelectDto : BaseDto<OrderLineSelectDto, OrderLine>
    {
    }
}
