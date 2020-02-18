using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Entities.PrintingHouse;
using WebFramework.Api;

namespace MyApi.Models
{
    public class PrintingHouseDto : BaseDto<PrintingHouseDto, PrintingHouse>
    {
        [Required]
        public UserDto UserDto { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string DocumentsUrl { get; set; }
        
        public string Iban { get; set; }

        public double Cash { get; set; }

    }

    public class PrintingHouseSelectDto : BaseDto<PrintingHouseSelectDto, PrintingHouse>
    {
        public UserSelectDto User { get; set; }

        public PrintingHouseWallet  PrintingHouseWallet  { get; set; }
        
        public int UserId { get; set; }
        
        public string Name { get; set; }

        public string DocumentsUrl { get; set; }

        public TokenSelectRequest TokenSelectRequest { get; set; }

        public double Star { get; set; }
    }
}
