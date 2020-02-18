using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entities.Service
{
    public class Price : BaseEntity
    {
        public int QuantityBasePriceId { get; set; }
        public int ColorBasePriceId { get; set; }
        public int SizeBasePriceId { get; set; }
        public int RoundedCornerBasePriceId { get; set; }
        public int CategoryBasePriceId { get; set; }

        public QuantityBasePrice QuantityBasePrice { get; set; }
        public ColorBasePrice ColorBasePrice { get; set; }
        public SizeBasePrice SizeBasePrice { get; set; }
        public RoundedCornerBasePrice RoundedCornerBasePrice { get; set; }
        public CategoryBasePrice CategoryBasePrice { get; set; }

        public int CategoryId { get; set; }
        public int PrintingHouseId { get; set; }

        public PrintingHouse.PrintingHouse PrintingHouse { get; set; }
    }

    public class QuantityBasePrice : BaseEntity
    {
        public int QuantityId { get; set; }

        public double QuantityPer { get; set; }

        public int PrintingHouseId { get; set; }
    }

    public class ColorBasePrice : BaseEntity
    {
        public int ColorId { get; set; }

        public double ColorPer { get; set; }

        public int PrintingHouseId { get; set; }
    }
    
    public class SizeBasePrice : BaseEntity
    {
        public int SizeId { get; set; }

        public double SizePer { get; set; }

        public int PrintingHouseId { get; set; }
    }

    public class RoundedCornerBasePrice : BaseEntity
    {
        public bool RoundedCorner { get; set; }

        public double RoundedCornerPer { get; set; }

        public int PrintingHouseId { get; set; }
    }
    
    public class CategoryBasePrice : IEntity
    {
        public int CategoryId { get; set; }

        public double CategoryPrice { get; set; }
        
        public int PrintingHouseId { get; set; }
    }

    public class CategoryBasePriceConfiguration : IEntityTypeConfiguration<CategoryBasePrice>
    {
        public void Configure(EntityTypeBuilder<CategoryBasePrice> builder)
        {
            builder.HasKey(t => new {t.CategoryId, t.PrintingHouseId});
        }
    }
}
