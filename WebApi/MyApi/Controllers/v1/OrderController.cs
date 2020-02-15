using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common;
using Data.Contracts;
using Entities.Customer;
using Entities.Order;
using Entities.User;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using Microsoft.VisualBasic.CompilerServices;
using MyApi.Models;
using WebFramework.Api;
using Attribute = Entities.Service.Attribute;

namespace MyApi.Controllers.v1
{
    [ApiVersion("1")]
    public class OrderController : CrudController<OrderDto, OrderSelectDto, Order>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IRepository<OrderLine> _orderLineRepository;
        private readonly IRepository<Attribute> _attributeRepository;

        public OrderController(IRepository<Order> repository, ICustomerRepository customerRepository, 
            IRepository<Payment> paymentRepository, IRepository<Attribute> attributeRepository,
            IRepository<OrderLine> orderLineRepository, IMapper mapper)
            : base(repository, mapper)
        {
            _customerRepository = customerRepository;
            _paymentRepository = paymentRepository;
            _orderLineRepository = orderLineRepository;
            _attributeRepository = attributeRepository;
        }
        /*
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
        }*/

        [HttpPost]
        [Authorize(Roles = "NaturalPerson, AdvertisingCenter")]
        public override async Task<ApiResult<OrderSelectDto>> Create(OrderDto orderDto, CancellationToken cancellationToken)
        {
            #region working with claims
            //var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
            //var userId = User.Identity.GetUserId();
            #endregion
            
            var userId = User.Identity.GetUserId();

            //Create Order => Create Payment => Create OrderLines
            //Create Payment
            var payment = new Payment
            {
                IsPayed = false
            };
            await _paymentRepository.AddAsync(payment, cancellationToken);

            //Create Order
            var customer = await _customerRepository.GetCustomerByUserId(int.Parse(userId), cancellationToken);
            var order = orderDto.ToEntity(Mapper);
            order.DateTime = DateTime.Now;
            order.CustomerId = customer.Id;
            order.PaymentId = payment.Id;
            await Repository.AddAsync(order, cancellationToken);

            //Create OrderLines
            var orderLineDtos = orderDto.OrderLineDtos;
            foreach (var orderLineDto in orderLineDtos)
            {
                var attribute = orderLineDto.AttributeDto.ToEntity(Mapper);
                await _attributeRepository.AddAsync(attribute, cancellationToken);

                orderLineDto.AttributeId = attribute.Id;
                orderLineDto.OrderId = order.Id;

                await _orderLineRepository.AddAsync(orderLineDto.ToEntity(Mapper), cancellationToken);
            }

            var resultDto = await Repository.TableNoTracking.Include(o => o.OrderLines)
                .ProjectTo<OrderSelectDto>(Mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id.Equals(order.Id), cancellationToken);

            return resultDto;
        }
    }
}
