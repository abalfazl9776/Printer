using System;
using System.Collections.Generic;
using System.Text;

namespace WebFramework.Ordering
{
    public class PriceSelectDto
    {
        public string PrintingHouseName { get; set; }

        public int PrintingHouseId { get; set; }

        public int CategoryId { get; set; }

        public double Price { get; set; }

    }
}
