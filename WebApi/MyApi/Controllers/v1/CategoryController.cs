using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Contracts;
using Entities.Customer;
using Entities.Service;
using Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;
using WebFramework.Api;

namespace MyApi.Controllers.v1
{

    [ApiVersion("1")]
    public class CategoryController : CrudController<CategoryDto, CategorySelectDto, Category>
    {

        public CategoryController(IRepository<Category> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public override async Task<ApiResult<List<CategorySelectDto>>> Get(CancellationToken cancellationToken)
        {
            var categoriesList = await Repository.TableNoTracking
                .Include(c => c.Description)
                .Include(c => c.Description.ImageUrls)
                .Include(c => c.Service)
                .ProjectTo<CategorySelectDto>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return Ok(categoriesList);
        }

        [HttpGet("{id}")]
        public override async Task<ApiResult<CategorySelectDto>> Get(int id, CancellationToken cancellationToken)
        {
            var dto = await Repository.TableNoTracking
                .Include(c => c.Description.DescriptionText)
                .Include(c => c.Description.ImageUrls)
                .ProjectTo<CategorySelectDto>(Mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(c => c.Id.Equals(id), cancellationToken);

            if (dto == null)
                return NotFound();

            return dto;
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public override async Task<ApiResult<CategorySelectDto>> Create(CustomerDto dto,
        //    CancellationToken cancellationToken)
        //{
        //    dto.UserDto.PhoneNumber = dto.UserDto.UserName;
        //    dto.UserDto.Email = "np" + dto.UserDto.PhoneNumber + "@printer.ir";
        //    var user = dto.UserDto.ToEntity(Mapper);
        //    var addUser = await _userManager.CreateAsync(user, dto.UserDto.Password);

        //    user = await _userManager.FindByNameAsync(user.UserName);
        //    var addToRole = await _userManager.AddToRoleAsync(user, PredefinedRoles.NaturalPerson.ToString());

        //    var userSelectDto = await _userRepository.TableNoTracking
        //        .ProjectTo<UserSelectDto>(Mapper.ConfigurationProvider)
        //        .SingleOrDefaultAsync(p => p.Id.Equals(user.Id), cancellationToken);

        //    var customer = dto.ToEntity(Mapper);
        //    customer.User = user;
        //    await Repository.AddAsync(customer, cancellationToken);

        //    var resultDto = await Repository.TableNoTracking.Include(c => c.User)
        //        .ProjectTo<CustomerSelectDto>(Mapper.ConfigurationProvider)
        //        .SingleOrDefaultAsync(p => p.Id.Equals(customer.Id), cancellationToken);

        //    //resultDto.UserSelectDto = userSelectDto;
        //    return resultDto;
        //}

        /*
        [HttpGet]
        public virtual async Task<ActionResult<List<CustomerSelectDto>>> Get(CancellationToken cancellationToken)
        {
            var list = await Repository.TableNoTracking.ProjectTo<CustomerSelectDto>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return Ok(list);
        }
        */
    }
}
