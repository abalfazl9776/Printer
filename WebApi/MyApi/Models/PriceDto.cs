using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Order;
using Entities.Service;
using WebFramework.Api;

namespace MyApi.Models
{
    public class PriceDto : BaseDto<PriceDto, Price>
    {
        public AttributeDto AttributeDto { get; set; }

        public int CategoryId { get; set; }

        public int PrintingHouseId { get; set; }
    }

    public class PriceSelectDto : BaseDto<PriceSelectDto, Price>
    {
        public double Price { get; set; }
    }
}
