using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Common
{
    public class Address<TEntity> : BaseEntity
    {
        public String Country { get; set; }
        public String State { get; set; }
        public String City { get; set; }
        public String District { get; set; }
        public String MainStreet { get; set; }
        public String SubStreet { get; set; }
        public String HouseNumber { get; set; }
        public String BuildingName { get; set; }
        public String Unit { get; set; }
        public String Zip { get; set; }
        public String Phone { get; set; }

        public TEntity UserEntity { get; set; }

    }
}
