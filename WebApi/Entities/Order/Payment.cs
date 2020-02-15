using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Entities.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entities.Order
{
    public class Payment : BaseEntity
    {
        public bool IsPayed { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}
