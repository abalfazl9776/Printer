using System;
using System.Collections.Generic;
using System.Text;
using Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Order
{
    public class Order : BaseEntity
    {
        public DateTime DateTime { get; set; }

        public double TotalPrice { get; set; }

        public int CustomerId { get; set; }
        public int PaymentId { get; set; }


        public Customer.Customer Customer { get; set; }
        public Payment Payment { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; }
    }

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            /*builder.Property(p => p.UserName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.FullName).HasMaxLength(100);*/
        }
    }
}
