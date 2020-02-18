using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Common;
using Entities.Service;

namespace Entities.PrintingHouse
{
    public class PrintingHouse : Client.Client
    {
        public string Name { get; set; }

        public double Star { get; set; }

        public string DocumentsUrl { get; set; }

        public int PrintingHouseWalletId { get; set; }

        public PrintingHouseWallet Wallet { get; set; }

        public ICollection<ServiceMapping> ServiceMappings{ get; set; }
    }
}
