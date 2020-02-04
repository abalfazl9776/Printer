using System;
using System.Collections.Generic;
using System.Text;
using Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Service
{
    public class Description : BaseEntity
    {
        public List<ImageUrl> ImageUrlsList { get; set; }

        public String DescriptionText { get; set; }
        
        public Service Service { get; set; }

        public Category Category { get; set; }

    }

    public class DescriptionConfiguration : IEntityTypeConfiguration<Description>
    {
        public void Configure(EntityTypeBuilder<Description> builder)
        {
            builder.Property(p => p.DescriptionText).IsRequired().HasMaxLength(10000);
        }
    }

    public class ImageUrl : BaseEntity
    {
        public String Url { get; set; }
    }

    public class ImagesUrlsConfiguration : IEntityTypeConfiguration<ImageUrl>
    {
        public void Configure(EntityTypeBuilder<ImageUrl> builder)
        {
            builder.Property(p => p.Url).IsRequired().HasMaxLength(150);
        }
    }
}
