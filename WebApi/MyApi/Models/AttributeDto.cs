using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFramework.Api;

namespace MyApi.Models
{
    public class AttributeDto : BaseDto<AttributeDto, Entities.Service.Attribute>
    {
        public string Size { get; set; }

        public string Color { get; set; }

        public int Quantity { get; set; }

        public bool RoundedCorners { get; set; }
    }

    public class AttributeSelectDto : BaseDto<AttributeSelectDto, Entities.Service.Attribute>
    {
    }
}
