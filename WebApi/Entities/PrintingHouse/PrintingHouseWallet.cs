using System.ComponentModel.DataAnnotations.Schema;
using Entities.Common;

namespace Entities.PrintingHouse
{
    public class PrintingHouseWallet : BaseEntity
    {
        public double Cash { get; set; }

        [ForeignKey(nameof(Entities.PrintingHouse.PrintingHouse)+nameof(Entities.PrintingHouse.PrintingHouse.Id))]
        public PrintingHouse PrintingHouse { get; set; }
    }
}
