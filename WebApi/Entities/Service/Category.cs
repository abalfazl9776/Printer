using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Service
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public int ServiceId { get; set; }

        public Service Service { get; set; }

        public Description Description { get; set; }

        public ICollection<CategoryBasePrice> CategoryBasePrice { get; set; }
    }

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            //builder.Property(p => p.Service).IsRequired();
            //builder.HasOne(p => p.Service).WithMany(c => c.Categories).HasForeignKey(p => p.Service.Id);
        }
    }

    //var values = Enum.GetValues(typeof(CardFormat)).Cast<CardFormat>();

    /*[JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CardFormat
    {
        [EnumMember(Value = "Mini")]
        //[Display(Name = "خانم")]
        Mini = 0,
        
        [EnumMember(Value = "Standard")]
        //[Display(Name = "آقا")]
        Standard = 1,
        
        [EnumMember(Value = "Square")]
        //[Display(Name = "آقا")]
        Square = 3,

        [EnumMember(Value = "Metallic")]
        //[Display(Name = "آقا")]
        Metallic = 4,

        [EnumMember(Value = "Painted Edge")]
        //[Display(Name = "آقا")]
        PaintedEdge = 5,

        [EnumMember(Value = "Silk")]
        //[Display(Name = "آقا")]
        Silk = 6,

        [EnumMember(Value = "Magnet")]
        //[Display(Name = "آقا")]
        Magnet = 7
    }*/
}
