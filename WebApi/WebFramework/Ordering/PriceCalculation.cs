using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Data.Contracts;
using Entities.Service;
using Microsoft.EntityFrameworkCore;
using Attribute = Entities.Service.Attribute;

namespace WebFramework.Ordering
{
    public class PriceCalculation : IPriceCalculation, ITransientDependency
    {
        private readonly IRepository<CategoryBasePrice> _catbpRepository;
        private readonly IRepository<SizeBasePrice> _sbpRepository;
        private readonly IRepository<ColorBasePrice> _colbpRepository;
        private readonly IRepository<QuantityBasePrice> _qbpRepository;
        private readonly IRepository<RoundedCornerBasePrice> _rbpRepository;
        private readonly IRepository<ServiceMapping> _smRepository;

        public PriceCalculation(IRepository<CategoryBasePrice> catbpRepository,
            IRepository<SizeBasePrice> sbpRepository, IRepository<ColorBasePrice> colbpRepository,
            IRepository<QuantityBasePrice> qbpRepository, IRepository<RoundedCornerBasePrice> rbpRepository,
            IRepository<ServiceMapping> smRepository)
        {
            _catbpRepository = catbpRepository;
            _sbpRepository = sbpRepository;
            _colbpRepository = colbpRepository;
            _qbpRepository = qbpRepository;
            _rbpRepository = rbpRepository;
            _smRepository = smRepository;
        }

        public async Task<List<PriceSelectDto>> CalculatePrice(Attribute attribute, int categoryId, CancellationToken cancellationToken)
        {
            var categoryPers = await _catbpRepository.TableNoTracking
                .Where(cbp => cbp.CategoryId == categoryId)
                .ToListAsync(cancellationToken);
            var sizePers = await _sbpRepository.TableNoTracking
                .Where(sbp => sbp.SizeId == attribute.SizeId)
                .ToListAsync(cancellationToken);
            var colorPers = await _colbpRepository.TableNoTracking
                .Where(cbp => cbp.ColorId == attribute.ColorId)
                .ToListAsync(cancellationToken);
            var quantityPers = await _qbpRepository.TableNoTracking
                .Where(qbp => qbp.QuantityId == attribute.QuantityId)
                .ToListAsync(cancellationToken);
            var roundedCornerPers = await _rbpRepository.TableNoTracking
                .Where(rcbp => rcbp.RoundedCorner.Equals(attribute.RoundedCorners))
                .ToListAsync(cancellationToken);

            var printingHouses = await _smRepository.TableNoTracking
                .Where(sm => sm.CategoryId == categoryId)
                .Include(sm => sm.PrintingHouse)
                .ToListAsync(cancellationToken);

            var resultDto = new List<PriceSelectDto>();

            foreach (var ph in printingHouses)
            {
                var catPer = categoryPers.Find(price => price.PrintingHouseId == ph.PrintingHouseId).CategoryPrice;
                var sizePer = sizePers.Find(size => size.PrintingHouseId == ph.PrintingHouseId).SizePer;
                var colorPer = colorPers.Find(color => color.PrintingHouseId == ph.PrintingHouseId).ColorPer;
                var quantityPer = quantityPers.Find(quantity => quantity.PrintingHouseId == ph.PrintingHouseId).QuantityPer;
                var rcPer = roundedCornerPers.Find(rounded => rounded.PrintingHouseId == ph.PrintingHouseId).RoundedCornerPer;

                double calculatedPrice = catPer * sizePer * colorPer * quantityPer * rcPer ;

                var priceSelectDto = new PriceSelectDto
                {
                    PrintingHouseId = ph.PrintingHouseId,
                    CategoryId = categoryId,
                    Price = calculatedPrice,
                    PrintingHouseName = ph.PrintingHouse.Name
                };
                resultDto.Add(priceSelectDto);
            }

            return resultDto;
        }

    }
}
