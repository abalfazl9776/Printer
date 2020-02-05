using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Common;

namespace Entities.PrintingHouse
{
    public class PrintingHouse : Client.Client
    {
        public string Name { get; set; }

        public long LicenseNumber { get; set; }

        public PrintingHouseWallet Wallet { get; set; }

    }
}
