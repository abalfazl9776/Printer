﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Contracts;
using Entities.PrintingHouse;
using Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;
using Services.Services.JWT;
using WebFramework.Api;

namespace MyApi.Controllers.v1
{
    [ApiVersion("1")]
    public class PrintingHouseController : CrudController<PrintingHouseDto, PrintingHouseSelectDto, PrintingHouse>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly IRepository<PrintingHouseWallet> _phWalletRepository;
        private readonly IJwtService _jwtService;

        public PrintingHouseController(IRepository<PrintingHouse> repository, IUserRepository userRepository,
            UserManager<User> userManager, IRepository<PrintingHouseWallet> phWalletRepository, 
            IJwtService jwtService, IMapper mapper) 
            : base(repository, mapper)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _phWalletRepository = phWalletRepository;
            _jwtService = jwtService;
        }

        [HttpGet]
        [AllowAnonymous]
        public override async Task<ApiResult<List<PrintingHouseSelectDto>>> Get(CancellationToken cancellationToken)
        {
            var printingHousesList = await Repository.TableNoTracking
                .ProjectTo<PrintingHouseSelectDto>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            
            return Ok(printingHousesList);
        }

        [HttpGet("{id}")]
        public override async Task<ApiResult<PrintingHouseSelectDto>> Get(int id, CancellationToken cancellationToken)
        {
            var dto = await Repository.TableNoTracking.Include(ph => ph.User)
                .ProjectTo<PrintingHouseSelectDto>(Mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id.Equals(id), cancellationToken);

            if (dto == null)
                return NotFound();

            //var user = await _userRepository.GetByIdAsync(cancellationToken, dto.UserId);
            //var userSelectDto = await _userRepository.TableNoTracking.ProjectTo<UserSelectDto>(Mapper.ConfigurationProvider)
            //    .SingleOrDefaultAsync(p => p.Id.Equals(user.Id), cancellationToken);
            //dto.UserSelectDto = userSelectDto;

            return dto;
        }

        [HttpPost]
        [AllowAnonymous]
        public override async Task<ApiResult<PrintingHouseSelectDto>> Create(PrintingHouseDto dto, CancellationToken cancellationToken)
        {
            dto.UserDto.PhoneNumber = dto.UserDto.UserName;
            var user = dto.UserDto.ToEntity(Mapper);
            var addUser = await _userManager.CreateAsync(user, dto.UserDto.Password);

            user = await _userManager.FindByNameAsync(user.UserName);
            var addToRole = await _userManager.AddToRoleAsync(user, PredefinedRoles.PrintingHouse.ToString());
            
            //var userSelectDto = await _userRepository.TableNoTracking.ProjectTo<UserSelectDto>(Mapper.ConfigurationProvider)
            //    .SingleOrDefaultAsync(p => p.Id.Equals(user.Id), cancellationToken);
            
            var printingHouseWallet = new PrintingHouseWallet
            {
                Iban = dto.Iban,
                Cash = 0
            };
            await _phWalletRepository.AddAsync(printingHouseWallet, cancellationToken);

            var printingHouse = dto.ToEntity(Mapper);
            printingHouse.PrintingHouseWalletId = printingHouseWallet.Id;
            printingHouse.User = user;
            printingHouse.Wallet = printingHouseWallet;
            await Repository.AddAsync(printingHouse, cancellationToken);

            var resultDto = await Repository.TableNoTracking
                .Include(ph => ph.User)
                .Include(ph => ph.Wallet)
                .ProjectTo<PrintingHouseSelectDto>(Mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id.Equals(printingHouse.Id), cancellationToken);
            
            //resultDto.UserSelectDto = userSelectDto;
            //return resultDto;

            var jwt = await _jwtService.GenerateAsync(user);
            var token = new TokenSelectRequest
            {
                access_token = jwt.access_token,
                expires_in = jwt.expires_in
            };

            resultDto.TokenSelectRequest = token;
            return resultDto;
        }
        /*
        [HttpGet]
        public virtual async Task<ActionResult<List<PrintingHouseSelectDto>>> Get(CancellationToken cancellationToken)
        {
            var list = await Repository.TableNoTracking.ProjectTo<PrintingHouseSelectDto>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return Ok(list);
        }
        */
        /*
        [HttpPost]
        [Authorize(Roles = "PrintingHouse")]
        public async Task<ApiResult<PrintingHouseSelectDto>> AddService(CategoryDto dto, CancellationToken cancellationToken)
        {
            dto.UserDto.PhoneNumber = dto.UserDto.UserName;
            dto.UserDto.Email = "ph"+dto.UserDto.PhoneNumber+"@printer.ir";
            var user = dto.UserDto.ToEntity(Mapper);
            var addUser = await _userManager.CreateAsync(user, dto.UserDto.Password);

            user = await _userManager.FindByNameAsync(user.UserName);
            var addToRole = await _userManager.AddToRoleAsync(user, PredefinedRoles.PrintingHouse.ToString());
            
            //var userSelectDto = await _userRepository.TableNoTracking.ProjectTo<UserSelectDto>(Mapper.ConfigurationProvider)
            //    .SingleOrDefaultAsync(p => p.Id.Equals(user.Id), cancellationToken);
            
            var printingHouseWallet = new PrintingHouseWallet
            {
                Iban = dto.Iban,
                Cash = 0
            };
            await _phWalletRepository.AddAsync(printingHouseWallet, cancellationToken);

            var printingHouse = dto.ToEntity(Mapper);
            printingHouse.PrintingHouseWalletId = printingHouseWallet.Id;
            printingHouse.User = user;
            await Repository.AddAsync(printingHouse, cancellationToken);

            var resultDto = await Repository.TableNoTracking.ProjectTo<PrintingHouseSelectDto>(Mapper.ConfigurationProvider)
                .Include(ph => ph.User)
                .Include(ph => ph.PrintingHouseWallet)
                .SingleOrDefaultAsync(p => p.Id.Equals(printingHouse.Id), cancellationToken);
            
            //resultDto.UserSelectDto = userSelectDto;
            return resultDto;
        }*/

        [HttpPut("{id}")]
        [Authorize(Roles = "PrintingHouse")]
        public override async Task<ApiResult<PrintingHouseSelectDto>> Update(int id, PrintingHouseDto dto, 
            CancellationToken cancellationToken)
        {
            var printingHouse = await Repository.TableNoTracking
                .Include(ph => ph.Wallet)
                .SingleOrDefaultAsync(ph => ph.Id.Equals(id), cancellationToken);
            var user = await _userRepository.GetByIdAsync(cancellationToken, printingHouse.UserId);

            user = dto.UserDto.ToEntity(Mapper, user);
            user.Id = printingHouse.UserId;
            printingHouse = dto.ToEntity(Mapper, printingHouse);
            printingHouse.Id = id;
            printingHouse.UserId = user.Id;
            printingHouse.Wallet.Iban = dto.Iban;
            printingHouse.Wallet.Cash = dto.Cash;

            await _phWalletRepository.UpdateAsync(printingHouse.Wallet, cancellationToken);

            await _userRepository.UpdateAsync(user, cancellationToken);
            await Repository.UpdateAsync(printingHouse, cancellationToken);

            //var userSelectDto = await _userRepository.TableNoTracking.ProjectTo<UserSelectDto>(Mapper.ConfigurationProvider)
            //    .SingleOrDefaultAsync(p => p.Id.Equals(user.Id), cancellationToken);

            var resultDto = await Repository.TableNoTracking.ProjectTo<PrintingHouseSelectDto>(Mapper.ConfigurationProvider)
                .Include(ph => ph.User)
                .Include(ph => ph.PrintingHouseWallet)
                .SingleOrDefaultAsync(p => p.Id.Equals(printingHouse.Id), cancellationToken);

            //resultDto.UserSelectDto = userSelectDto;
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
