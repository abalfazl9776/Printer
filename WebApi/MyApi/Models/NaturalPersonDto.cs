using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Entities.Client;
using Entities.Customer.NaturalPerson;
using Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebFramework.Api;

namespace MyApi.Models
{
    public class NaturalPersonDto : BaseDto<NaturalPersonDto, NaturalPerson>
    {
        [Required]
        public UserDto UserDto { get; set; }
    }

    public class NaturalPersonSelectDto : BaseDto<NaturalPersonSelectDto, NaturalPerson>
    {
        public UserSelectDto UserSelectDto { get; set; }

    }
}
