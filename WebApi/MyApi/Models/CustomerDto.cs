using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Entities.Client;
using Entities.Customer;
using Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebFramework.Api;

namespace MyApi.Models
{
    public class CustomerDto : BaseDto<CustomerDto, Customer>
    {
        [Required]
        public UserDto UserDto { get; set; }

        public string AcName { get; set; }

        public long AcLicenseNumber { get; set; }

        [Required]
        public PredefinedRoles DiscriminatorRole { get; set; }

    }

    public class CustomerSelectDto : BaseDto<CustomerSelectDto, Customer>
    {
        public UserSelectDto User { get; set; }
        
        public int UserId { get; set; }

        public string AcName { get; set; }

        public long AcLicenseNumber { get; set; }

        public PredefinedRoles DiscriminatorRole { get; set; }

    }
}
