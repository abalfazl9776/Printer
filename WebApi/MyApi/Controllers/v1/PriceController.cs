using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Data.Contracts;
using Data.Repositories;
using Entities.Order;
using Entities.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;
using WebFramework.Api;
using WebFramework.Ordering;
using Attribute = System.Attribute;

namespace MyApi.Controllers.v1
{
    [ApiVersion("1")]
    public class PriceController : BaseController
    {
        private readonly IRepository<Size> _sizeRepository;
        private readonly IRepository<Color> _colorRepository;
        private readonly IRepository<Quantity> _quantityRepository;
        private readonly IPriceCalculation _priceCalculation;
        private readonly IMapper _mapper;

        public PriceController(IRepository<Size> sizeRepository, IRepository<Color> colorRepository,
            IRepository<Quantity> quantityRepository, IPriceCalculation priceCalculation, IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            _colorRepository = colorRepository;
            _quantityRepository = quantityRepository;
            _priceCalculation = priceCalculation;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ApiResult<AttributeSelectDto>> GetAttributes(CancellationToken cancellationToken)
        {
            var sizes = await _sizeRepository.TableNoTracking.ToListAsync(cancellationToken);
            var colors = await _colorRepository.TableNoTracking.ToListAsync(cancellationToken);
            var quantities = await _quantityRepository.TableNoTracking.ToListAsync(cancellationToken);

            var attributeSelectDto = new AttributeSelectDto
            {
                Sizes = sizes,
                Colors = colors,
                Quantities = quantities
            };

            return attributeSelectDto;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ApiResult<List<PriceSelectDto>>> CalculatePrice(AttributeDto dto, CancellationToken cancellationToken)
        {
            var attribute = dto.ToEntity(_mapper);

            var resultDto = await _priceCalculation.CalculatePrice(attribute, dto.CategoryId, cancellationToken);

            return resultDto;
        }
    }
}
