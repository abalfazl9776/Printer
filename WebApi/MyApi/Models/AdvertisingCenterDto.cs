//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;
//using Entities.Customer;
//using Entities.PrintingHouse;
//using WebFramework.Api;

//namespace MyApi.Models
//{
//    public class AdvertisingCenterDto : BaseDto<AdvertisingCenterDto, AdvertisingCenter>
//    {
//        [Required]
//        public UserDto UserDto { get; set; }

//        public int UserId { get; set; }

//        public string Name { get; set; }

//        public long LicenseNumber { get; set; }

//    }

//    public class AdvertisingCenterSelectDto : BaseDto<AdvertisingCenterSelectDto, AdvertisingCenter>
//    {
//        public UserSelectDto UserSelectDto { get; set; }
        
//        public int UserId { get; set; }
        
//        public string Name { get; set; }

//        public long LicenseNumber { get; set; }

//    }
//}
