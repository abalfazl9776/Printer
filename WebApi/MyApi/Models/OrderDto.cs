using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Order;
using WebFramework.Api;

namespace MyApi.Models
{
    public class OrderDto : BaseDto<OrderDto, Order>
    {
        public List<OrderLineDto> OrderLineDtos { get; set; }
    }

    public class OrderSelectDto : BaseDto<OrderSelectDto, Order>
    {
        public DateTime DateTime { get; set; }

        public double TotalPrice { get; set; }
    }
}
