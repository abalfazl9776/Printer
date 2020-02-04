using System;
using System.Collections.Generic;
using System.Text;
using Entities.Common;

namespace Entities.Customer
{
    public abstract class Customer<TEntity>
        where TEntity : class
    {
        public int Id { get; set; }

        public Address<TEntity> Address { get; set; }

        public User.User User { get; set; }
    }
}
