using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using Entities.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json.Converters;

namespace Entities.User
{
    public class User : IdentityUser<int>, IEntity
    {
        public User()
        {
            IsActive = true;
        }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        public GenderType Gender { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset LastLoginDate { get; set; }

    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.UserName).IsRequired().HasMaxLength(100);
        }
    }
    
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GenderType
    {
        [EnumMember(Value = "FEMALE")]
        //[Display(Name = "خانم")]
        Female = 0,

        [EnumMember(Value = "MALE")]
        //[Display(Name = "آقا")]
        Male = 1
    }
}
