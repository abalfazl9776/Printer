using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Service;
using WebFramework.Api;

namespace MyApi.Models
{
    public class AttributeDto : BaseDto<AttributeDto, Entities.Service.Attribute>
    {
        public int CategoryId { get; set; }

        public int SizeId { get; set; }

        public int ColorId { get; set; }

        public int QuantityId { get; set; }

        public bool RoundedCorners { get; set; }
    }

    public class AttributeSelectDto : BaseDto<AttributeSelectDto, Entities.Service.Attribute>
    {
        public List<Size> Sizes { get; set; }
        public List<Color> Colors { get; set; }
        public List<Quantity> Quantities { get; set; }

    }
}
