using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Contracts;
using Entities.Customer.NaturalPerson;
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
    public class NaturalPersonController : CrudController<NaturalPersonDto, NaturalPersonSelectDto, NaturalPerson>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public NaturalPersonController(IRepository<NaturalPerson> repository, IUserRepository userRepository,
            UserManager<User> userManager, IMapper mapper) 
            : base(repository, mapper)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public override async Task<ApiResult<NaturalPersonSelectDto>> Get(int id, CancellationToken cancellationToken)
        {
            var dto = await Repository.TableNoTracking.ProjectTo<NaturalPersonSelectDto>(Mapper.ConfigurationProvider)
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
        public override async Task<ApiResult<NaturalPersonSelectDto>> Create(NaturalPersonDto dto, CancellationToken cancellationToken)
        {
            dto.UserDto.PhoneNumber = dto.UserDto.UserName;
            dto.UserDto.Email = "np"+dto.UserDto.PhoneNumber+"@printer.ir";
            var user = dto.UserDto.ToEntity(Mapper);
            var addUser = await _userManager.CreateAsync(user, dto.UserDto.Password);

            user = await _userManager.FindByNameAsync(user.UserName);
            var addToRole = await _userManager.AddToRoleAsync(user, PredefinedRoles.NaturalPerson.ToString());
            
            var userSelectDto = await _userRepository.TableNoTracking.ProjectTo<UserSelectDto>(Mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id.Equals(user.Id), cancellationToken);

            var naturalPerson = dto.ToEntity(Mapper);
            naturalPerson.User = user;
            await Repository.AddAsync(naturalPerson, cancellationToken);

            var resultDto = await Repository.TableNoTracking.ProjectTo<NaturalPersonSelectDto>(Mapper.ConfigurationProvider).
                SingleOrDefaultAsync(p => p.Id.Equals(naturalPerson.Id), cancellationToken);

            resultDto.UserSelectDto = userSelectDto;
            return resultDto;
        }
        /*
        [HttpGet]
        public virtual async Task<ActionResult<List<NaturalPersonSelectDto>>> Get(CancellationToken cancellationToken)
        {
            var list = await Repository.TableNoTracking.ProjectTo<NaturalPersonSelectDto>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return Ok(list);
        }
        */

        [HttpPut("{id}")]
        public override async Task<ApiResult<NaturalPersonSelectDto>> Update(int id, NaturalPersonDto dto, 
            CancellationToken cancellationToken)
        {
            var naturalPerson = await Repository.GetByIdAsync(cancellationToken, id);
            var user = await _userRepository.GetByIdAsync(cancellationToken, naturalPerson.UserId);

            user = dto.UserDto.ToEntity(Mapper, user);
            user.Id = naturalPerson.UserId;
            naturalPerson = dto.ToEntity(Mapper, naturalPerson);
            naturalPerson.Id = id;
            naturalPerson.UserId = user.Id;

            await _userRepository.UpdateAsync(user, cancellationToken);
            await Repository.UpdateAsync(naturalPerson, cancellationToken);

            var userSelectDto = await _userRepository.TableNoTracking.ProjectTo<UserSelectDto>(Mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id.Equals(user.Id), cancellationToken);

            var resultDto = await Repository.TableNoTracking.ProjectTo<NaturalPersonSelectDto>(Mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id.Equals(naturalPerson.Id), cancellationToken);

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
