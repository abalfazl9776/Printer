using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Contracts;
using Entities.Customer;
using Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;
using WebFramework.Api;
using WebFramework.Filters;

namespace MyApi.Controllers.v1
{
    [ApiVersion("1")]
    public class CustomerController : CrudController<CustomerDto, CustomerSelectDto, Customer>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public CustomerController(IRepository<Customer> repository, IUserRepository userRepository,
            UserManager<User> userManager, IMapper mapper) 
            : base(repository, mapper)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public override async Task<ApiResult<CustomerSelectDto>> Get(int id, CancellationToken cancellationToken)
        {
            var dto = await Repository.TableNoTracking.ProjectTo<CustomerSelectDto>(Mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id.Equals(id), cancellationToken);

            if (dto == null)
                return NotFound();

            var user = await _userRepository.GetByIdAsync(cancellationToken, dto.UserId);
            var userSelectDto = await _userRepository.TableNoTracking.ProjectTo<UserSelectDto>(Mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id.Equals(user.Id), cancellationToken);
            dto.UserSelectDto = userSelectDto;

            return dto;
        }

        [HttpPost]
        [AllowAnonymous]
        public override async Task<ApiResult<CustomerSelectDto>> Create(CustomerDto dto, CancellationToken cancellationToken)
        {
            dto.UserDto.PhoneNumber = dto.UserDto.UserName;
            dto.UserDto.Email = "np"+dto.UserDto.PhoneNumber+"@printer.ir";
            var user = dto.UserDto.ToEntity(Mapper);
            var addUser = await _userManager.CreateAsync(user, dto.UserDto.Password);

            user = await _userManager.FindByNameAsync(user.UserName);
            var addToRole = await _userManager.AddToRoleAsync(user, PredefinedRoles.NaturalPerson.ToString());
            
            var userSelectDto = await _userRepository.TableNoTracking.ProjectTo<UserSelectDto>(Mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id.Equals(user.Id), cancellationToken);

            var customer = dto.ToEntity(Mapper);
            customer.User = user;
            await Repository.AddAsync(customer, cancellationToken);

            var resultDto = await Repository.TableNoTracking.ProjectTo<CustomerSelectDto>(Mapper.ConfigurationProvider).
                SingleOrDefaultAsync(p => p.Id.Equals(customer.Id), cancellationToken);

            resultDto.UserSelectDto = userSelectDto;
            return resultDto;
        }
        /*
        [HttpGet]
        public virtual async Task<ActionResult<List<CustomerSelectDto>>> Get(CancellationToken cancellationToken)
        {
            var list = await Repository.TableNoTracking.ProjectTo<CustomerSelectDto>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return Ok(list);
        }
        */

        [HttpPut("{id}")]
        public override async Task<ApiResult<CustomerSelectDto>> Update(int id, CustomerDto dto, 
            CancellationToken cancellationToken)
        {
            var customer = await Repository.GetByIdAsync(cancellationToken, id);
            var user = await _userRepository.GetByIdAsync(cancellationToken, customer.UserId);

            user = dto.UserDto.ToEntity(Mapper, user);
            user.Id = customer.UserId;
            customer = dto.ToEntity(Mapper, customer);
            customer.Id = id;
            customer.UserId = user.Id;

            await _userRepository.UpdateAsync(user, cancellationToken);
            await Repository.UpdateAsync(customer, cancellationToken);

            var userSelectDto = await _userRepository.TableNoTracking.ProjectTo<UserSelectDto>(Mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id.Equals(user.Id), cancellationToken);

            var resultDto = await Repository.TableNoTracking.ProjectTo<CustomerSelectDto>(Mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id.Equals(customer.Id), cancellationToken);

            resultDto.UserSelectDto = userSelectDto;
            return resultDto;
        }
        /*
        [HttpDelete("{id:guid}")]
        public virtual async Task<ApiResult> Delete(TKey id, CancellationToken cancellationToken)
        {
            var model = await Repository.GetByIdAsync(cancellationToken, id);

            await Repository.DeleteAsync(model, cancellationToken);

            return Ok();
        }
        */
    }
}
