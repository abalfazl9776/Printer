
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Common;

namespace Entities.Client
{
    public abstract class Client : BaseEntity
    {
        public User.User User { get; set; }
        public int UserId { get; set; }
    }
}
