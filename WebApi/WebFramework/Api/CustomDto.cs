using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using WebFramework.CustomMapping;

namespace WebFramework.Api
{
    public abstract class CustomDto<TDto, TEntity, TKey> : IHaveCustomMapping
        where TDto : class, new()
        where TEntity : class, new()
    {
        public TKey Id { get; set; }

        public TEntity ToEntity()
        {
            return Mapper.Map<TEntity>(CastToDerivedClass(this));
        }

        public TEntity ToEntity(TEntity entity)
        {
            return Mapper.Map(CastToDerivedClass(this), entity);
        }

        public static TDto FromEntity(TEntity model)
        {
            return Mapper.Map<TDto>(model);
        }

        protected TDto CastToDerivedClass(CustomDto<TDto, TEntity, TKey> baseInstance)
        {
            return Mapper.Map<TDto>(baseInstance);
        }

        public void CreateMappings(Profile profile)
        {
            var mappingExpression = profile.CreateMap<TDto, TEntity>();

            var dtoType = typeof(TDto);
            var entityType = typeof(TEntity);
            //Ignore any property of source (like Post.Author) that dose not contains in destination 
            foreach (var property in entityType.GetProperties())
            {
                if (dtoType.GetProperty(property.Name) == null)
                    mappingExpression.ForMember(property.Name, opt => opt.Ignore());
            }

            CustomMappings(mappingExpression.ReverseMap());
        }

        public virtual void CustomMappings(IMappingExpression<TEntity, TDto> mapping)
        {
        }
    }

    public abstract class CustomDto<TDto, TEntity> : CustomDto<TDto, TEntity, int>
        where TDto : class, new()
        where TEntity : class, new()
    {

    }
}
