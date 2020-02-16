using System.ComponentModel.DataAnnotations.Schema;
using Entities.Common;

namespace Entities.PrintingHouse
{
    public class PrintingHouseWallet : BaseEntity
    {
        //International Bank Account Number (Sheba)
        public string Iban { get; set; }

        public double Cash { get; set; }
    }
}
