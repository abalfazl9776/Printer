using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Service
{
    public class Service : BaseEntity
    {
        public String Name { get; set; }
    }

    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        }
    }

    /*[JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ServiceType
    {
        [EnumMember(Value = "Banner")]
        //[Display(Name = "خانم")]
        Banner = 0,
        
        [EnumMember(Value = "Visit Card")]
        //[Display(Name = "آقا")]
        VisitCard = 1,
        
        [EnumMember(Value = "Flag")]
        //[Display(Name = "آقا")]
        Flag = 2
    }*/

}
