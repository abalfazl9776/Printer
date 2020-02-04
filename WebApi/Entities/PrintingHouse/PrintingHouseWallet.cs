
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Common;

namespace Entities.PrintingHouse
{
    public class PrintingHouseWallet : BaseEntity
    {
        public Double Cash { get; set; }

        public PrintingHouse PrintingHouse { get; set; }
    }
}
