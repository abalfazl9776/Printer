using System;
using System.Collections.Generic;
using System.Text;
using Entities.Common;

namespace Entities.Order
{
    public class Payment : BaseEntity
    {
        public bool IsPayed { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}
