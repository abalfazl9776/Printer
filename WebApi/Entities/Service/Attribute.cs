using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using Entities.Common;
using Entities.Order;

namespace Entities.Service
{
    public class Attribute : BaseEntity
    {
        public int SizeId { get; set; }

        public int ColorId { get; set; }

        public int QuantityId { get; set; }

        public bool RoundedCorners { get; set; }
    }

    public class Size : BaseEntity
    {
        public string DefaultSize { get; set; }
    }

    public class Color : BaseEntity
    {
        public string DefaultColor { get; set; }
    }

    public class Quantity : BaseEntity
    {
        public int DefaultQuantity { get; set; }
    }

}
