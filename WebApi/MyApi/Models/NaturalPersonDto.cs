using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Customer.NaturalPerson;
using WebFramework.Api;

namespace MyApi.Models
{
    public class NaturalPersonDto : BaseDto<NaturalPersonDto, NaturalPerson>
    {
        /*public UserDto UserDto { get; set; }*/

        public string FirstName { get; set; }

        public string LastName { get; set; }


    }

    public class NaturalPersonSelectDto : BaseDto<NaturalPersonSelectDto, NaturalPerson>
    {
        /*public UserDto UserDto { get; set; }*/

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
