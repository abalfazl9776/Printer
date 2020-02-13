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
        public string Size { get; set; }

        public string Color { get; set; }

        public int Quantity { get; set; }

        public bool RoundedCorners { get; set; }

    }

}
