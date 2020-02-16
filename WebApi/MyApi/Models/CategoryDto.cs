using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Customer;
using Entities.Service;
using Entities.User;
using WebFramework.Api;

namespace MyApi.Models
{
    public class CategoryDto : BaseDto<CategoryDto, Category>
    {
        public string Name { get; set; }
    }

    public class CategorySelectDto : BaseDto<CategorySelectDto, Category>
    {
        public string Name { get; set; }

        public string ServiceName { get; set; }

        public string DescriptionText { get; set; }

        public ICollection<ImageUrl> ImageUrls { get; set; }
        
        public override void CustomMappings(IMappingExpression<Category, CategorySelectDto> mapping)
        {
            mapping.ForMember(
                dest => dest.ServiceName,
                config => config.MapFrom(src => src.Service.Name));
        }
    }
}
