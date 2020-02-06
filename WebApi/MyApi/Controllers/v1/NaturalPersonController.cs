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

        [HttpPost]
        [AllowAnonymous]
        public override async Task<ApiResult<NaturalPersonSelectDto>> Create(NaturalPersonDto dto, CancellationToken cancellationToken)
        {
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

    }
}
