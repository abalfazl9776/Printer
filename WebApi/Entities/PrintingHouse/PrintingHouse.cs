using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Common;

namespace Entities.PrintingHouse
{
    public class PrintingHouse : Client.Client
    {
        public string Name { get; set; }

        public string DocumentsUrl { get; set; }

        public int PrintingHouseWalletId { get; set; }

        public PrintingHouseWallet Wallet { get; set; }

    }
}
