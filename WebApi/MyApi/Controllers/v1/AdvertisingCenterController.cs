//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using AutoMapper;
//using AutoMapper.QueryableExtensions;
//using Data.Contracts;
//using Entities.Customer;
//using Entities.User;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using MyApi.Models;
//using WebFramework.Api;

//namespace MyApi.Controllers.v1
//{
//    [ApiVersion("1")]
//    public class AdvertisingCenterController : BaseController
//    {
//        private readonly IUserRepository _userRepository;
//        private readonly UserManager<User> _userManager;
//        private readonly IRepository<AdvertisingCenter> _repository;
//        private readonly IMapper _mapper;

//        public AdvertisingCenterController(IRepository<AdvertisingCenter> repository, IUserRepository userRepository,
//            UserManager<User> userManager, IMapper mapper)
//        {
//            _mapper = mapper;
//            _repository = repository;
//            _userManager = userManager;
//            _userRepository = userRepository;
//        }

//        [HttpGet("{id}")]
//        public async Task<ApiResult<AdvertisingCenterSelectDto>> Get(int id, CancellationToken cancellationToken)
//        {
//            var dto = await _repository.TableNoTracking.ProjectTo<AdvertisingCenterSelectDto>(_mapper.ConfigurationProvider)
//                .SingleOrDefaultAsync(p => p.Id.Equals(id), cancellationToken);

//            if (dto == null)
//                return NotFound();

//            var user = await _userRepository.GetByIdAsync(cancellationToken, dto.UserId);
//            var userSelectDto = await _userRepository.TableNoTracking.ProjectTo<UserSelectDto>(_mapper.ConfigurationProvider)
//                .SingleOrDefaultAsync(p => p.Id.Equals(user.Id), cancellationToken);
//            dto.UserSelectDto = userSelectDto;

//            return dto;
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        public async Task<ApiResult<AdvertisingCenterSelectDto>> Create(AdvertisingCenterDto dto, CancellationToken cancellationToken)
//        {
//            dto.UserDto.PhoneNumber = dto.UserDto.UserName;
//            dto.UserDto.Email = "ac"+dto.UserDto.PhoneNumber+"@printer.ir";
//            var user = dto.UserDto.ToEntity(_mapper);
//            var addUser = await _userManager.CreateAsync(user, dto.UserDto.Password);

//            user = await _userManager.FindByNameAsync(user.UserName);
//            var addToRole = await _userManager.AddToRoleAsync(user, PredefinedRoles.AdvertisingCenter.ToString());
            
//            var userSelectDto = await _userRepository.TableNoTracking.ProjectTo<UserSelectDto>(_mapper.ConfigurationProvider)
//                .SingleOrDefaultAsync(p => p.Id.Equals(user.Id), cancellationToken);

//            var advertisingCenter = dto.ToEntity(_mapper);
//            advertisingCenter.User = user;
//            await _repository.AddAsync(advertisingCenter, cancellationToken);

//            var resultDto = await _repository.TableNoTracking.ProjectTo<AdvertisingCenterSelectDto>(_mapper.ConfigurationProvider).
//                SingleOrDefaultAsync(p => p.Id.Equals(advertisingCenter.Id), cancellationToken);

//            resultDto.UserSelectDto = userSelectDto;
//            return resultDto;
//        }
//        /*
//        [HttpGet]
//        public virtual async Task<ActionResult<List<AdvertisingCenterSelectDto>>> Get(CancellationToken cancellationToken)
//        {
//            var list = await Repository.TableNoTracking.ProjectTo<AdvertisingCenterSelectDto>(Mapper.ConfigurationProvider)
//                .ToListAsync(cancellationToken);

//            return Ok(list);
//        }
//        */

//        [HttpPut("{id}")]
//        public async Task<ApiResult<AdvertisingCenterSelectDto>> Update(int id, AdvertisingCenterDto dto, 
//            CancellationToken cancellationToken)
//        {
//            var advertisingCenter = await _repository.GetByIdAsync(cancellationToken, id);
//            var user = await _userRepository.GetByIdAsync(cancellationToken, advertisingCenter.UserId);

//            user = dto.UserDto.ToEntity(_mapper, user);
//            user.Id = advertisingCenter.UserId;
//            advertisingCenter = dto.ToEntity(_mapper, advertisingCenter);
//            advertisingCenter.Id = id;
//            advertisingCenter.UserId = user.Id;

//            await _userRepository.UpdateAsync(user, cancellationToken);
//            await _repository.UpdateAsync(advertisingCenter, cancellationToken);

//            var userSelectDto = await _userRepository.TableNoTracking.ProjectTo<UserSelectDto>(_mapper.ConfigurationProvider)
//                .SingleOrDefaultAsync(p => p.Id.Equals(user.Id), cancellationToken);

//            var resultDto = await _repository.TableNoTracking.ProjectTo<AdvertisingCenterSelectDto>(_mapper.ConfigurationProvider)
//                .SingleOrDefaultAsync(p => p.Id.Equals(advertisingCenter.Id), cancellationToken);

//            resultDto.UserSelectDto = userSelectDto;
//            return resultDto;
//        }
//        /*
//        [HttpDelete("{id:guid}")]
//        public virtual async Task<ApiResult> Delete(TKey id, CancellationToken cancellationToken)
//        {
//            var model = await Repository.GetByIdAsync(cancellationToken, id);

//            await Repository.DeleteAsync(model, cancellationToken);

//            return Ok();
//        }
//        */
//    }
//}
