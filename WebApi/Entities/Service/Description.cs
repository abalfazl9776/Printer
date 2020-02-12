using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Service
{
    public class Description : BaseEntity
    {
        public string DescriptionText { get; set; }
        
        public ICollection<ImageUrl> ImageUrls { get; set; }

        [ForeignKey("CategoryId")]
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
        public string Url { get; set; }
    }

    public class ImagesUrlsConfiguration : IEntityTypeConfiguration<ImageUrl>
    {
        public void Configure(EntityTypeBuilder<ImageUrl> builder)
        {
            builder.Property(p => p.Url).IsRequired().HasMaxLength(150);
        }
    }
}
