using System;
using System.Collections.Generic;
using System.Text;
using Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Service
{
    public class ServiceMapping : IEntity
    {
        public int PrintingHouseId { get; set; }

        public int CategoryId { get; set; }
    }
    

    public class ServiceMappingConfiguration : IEntityTypeConfiguration<ServiceMapping>
    {
        public void Configure(EntityTypeBuilder<ServiceMapping> builder)
        {
            builder.HasKey(t => new {t.CategoryId, t.PrintingHouseId});
        }
    }
}
