using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Exceptions;
using Data.Contracts;
using Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyApi.Models;
using Services.Services;
using Services.Services.JWT;
using WebFramework.Api;
using WebFramework.Filters;

namespace MyApi.Controllers.v1
{
    [ApiVersion("1")]
    //[Authorize]
    public class UserController : BaseController
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;
        private readonly IJwtService _jwtService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger, IJwtService jwtService,
            UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _userRepository = userRepository;
            _logger = logger;
            _jwtService = jwtService;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ApiResult<List<UserSelectDto>>> Get(CancellationToken cancellationToken)
        {
            var usersList = await _userRepository.TableNoTracking.ProjectTo<UserSelectDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            
            return Ok(usersList);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<ApiResult<UserSelectDto>> Get(int id, CancellationToken cancellationToken)
        {
            var user = await _userRepository.TableNoTracking.ProjectTo<UserSelectDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id.Equals(id), cancellationToken);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public virtual async Task<ActionResult> Token([FromForm]TokenRequest tokenRequest, CancellationToken cancellationToken)
        {
            //if (!tokenRequest.grant_type.Equals("password", StringComparison.OrdinalIgnoreCase))
            //    throw new Exception("OAuth flow is not password.");

            var user = await _userManager.FindByNameAsync(tokenRequest.username);
            if (user == null)
                throw new BadRequestException("نام کاربری یا رمز عبور اشتباه است");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, tokenRequest.password);
            if (!isPasswordValid)
                throw new BadRequestException("نام کاربری یا رمز عبور اشتباه است");

            var jwt = await _jwtService.GenerateAsync(user);
            return new JsonResult(jwt);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ApiResult<UserSelectDto>> Create(UserDto userDto, CancellationToken cancellationToken)
        {
            _logger.LogDebug("متد Create فراخوانی شد");

            //var user = new User
            //{
            //    BirthDate = userDto.BirthDate.Date,
            //    FullName = userDto.FullName,
            //    Gender = userDto.Gender,
            //    UserName = userDto.UserName,
            //    Email = userDto.Email
            //};
            //await _userManager.CreateAsync(user, userDto.Password);

            //var result2 = await _roleManager.CreateAsync(new Role
            //{
            //    Name = "Admin",
            //    Description = "writer role"
            //});

            //return Ok(userDto);


            var user = userDto.ToEntity(_mapper);

            await _userManager.CreateAsync(user, userDto.Password);

            //user = await _userManager.FindByNameAsync(user.UserName);

            //var result3 = await _userManager.AddToRoleAsync(user, "Admin");

            var resultDto = await _userRepository.TableNoTracking.ProjectTo<UserSelectDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id.Equals(user.Id), cancellationToken);

            return resultDto;
        }

        [HttpPut]
        public async Task<ApiResult<UserSelectDto>> Update(int id, UserDto userDto, CancellationToken cancellationToken)
        {
            var updateUser = await _userRepository.GetByIdAsync(cancellationToken, id);

            updateUser = userDto.ToEntity(_mapper, updateUser);

            await _userRepository.UpdateAsync(updateUser, cancellationToken);

            var resultDto = await _userRepository.TableNoTracking.ProjectTo<UserSelectDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id.Equals(updateUser.Id), cancellationToken);

            return resultDto;
        }

        [HttpDelete("{id:int}")]
        public async Task<ApiResult> Delete(int id, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(cancellationToken, id);
            await _userRepository.DeleteAsync(user, cancellationToken);

            return Ok();
        }
    }
}
