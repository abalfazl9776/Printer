using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using Entities.Client;
using Entities.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Entities.User
{
    public class User : IdentityUser<int>, IEntity
    {
        public User()
        {
            IsActive = true;
        }

        /*[Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }*/

        /*public GenderType Gender { get; set; }*/
        public bool IsActive { get; set; }
        public DateTimeOffset LastLoginDate { get; set; }

        public ICollection<Address> Addresses { get; set; }

    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.UserName).IsRequired().HasMaxLength(50);
            /*builder.Property(p => p.FullName).HasMaxLength(100);*/
        }
    }

    /*[JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GenderType
    {
        [EnumMember(Value = "Female")]
        //[Display(Name = "خانم")]
        Female = 0,

        [EnumMember(Value = "Male")]
        //[Display(Name = "آقا")]
        Male = 1
    }*/
}
