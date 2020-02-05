using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Common;

namespace Entities.Client
{
    public abstract class Client : BaseEntity
    {
        public User.User User { get; set; }
    }
}