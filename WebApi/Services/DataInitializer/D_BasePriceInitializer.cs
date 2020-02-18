using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Contracts;
using Entities.Service;
using Entities.User;

namespace Services.DataInitializer
{
    public class D_BasePriceInitializer : IDataInitializer
    {
        private readonly IRepository<CategoryBasePrice> _catbpRepository;
        private readonly IRepository<SizeBasePrice> _sbpRepository;
        private readonly IRepository<ColorBasePrice> _colbpRepository;
        private readonly IRepository<QuantityBasePrice> _qbpRepository;
        private readonly IRepository<RoundedCornerBasePrice> _rbpRepository;

        public D_BasePriceInitializer(IRepository<CategoryBasePrice> catbpRepository, 
            IRepository<SizeBasePrice> sbpRepository, IRepository<ColorBasePrice> colbpRepository,
            IRepository<QuantityBasePrice> qbpRepository, IRepository<RoundedCornerBasePrice> rbpRepository)
        {
            _catbpRepository = catbpRepository;
            _sbpRepository = sbpRepository;
            _colbpRepository = colbpRepository;
            _qbpRepository = qbpRepository;
            _rbpRepository = rbpRepository;
        }

        public void InitializeData()
        {
            #region Categories
            //PH 1
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 1 && cbp.CategoryId == 1))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 20000, PrintingHouseId = 1, CategoryId = 1 });
            }
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 1 && cbp.CategoryId == 2))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 22000, PrintingHouseId = 1, CategoryId = 2 });
            }
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 1 && cbp.CategoryId == 3))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 25000, PrintingHouseId = 1, CategoryId = 3 });
            }
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 1 && cbp.CategoryId == 5))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 40000, PrintingHouseId = 1, CategoryId = 5 });
            }
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 1 && cbp.CategoryId == 6))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 30000, PrintingHouseId = 1, CategoryId = 6 });
            }
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 1 && cbp.CategoryId == 7))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 32000, PrintingHouseId = 1, CategoryId = 7 });
            }

            //PH 2
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 2 && cbp.CategoryId == 2))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 27000, PrintingHouseId = 2, CategoryId = 2 });
            }
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 2 && cbp.CategoryId == 3))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 22000, PrintingHouseId = 2, CategoryId = 3 });
            }
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 2 && cbp.CategoryId == 4))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 21000, PrintingHouseId = 2, CategoryId = 4 });
            }
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 2 && cbp.CategoryId == 5))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 37000, PrintingHouseId = 2, CategoryId = 5 });
            }
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 2 && cbp.CategoryId == 6))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 32000, PrintingHouseId = 2, CategoryId = 6 });
            }
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 2 && cbp.CategoryId == 8))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 33000, PrintingHouseId = 2, CategoryId = 8 });
            }

            //PH 3
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 3 && cbp.CategoryId == 1))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 20000, PrintingHouseId = 3, CategoryId = 1 });
            }
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 3 && cbp.CategoryId == 2))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 18000, PrintingHouseId = 3, CategoryId = 2 });
            }
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 3 && cbp.CategoryId == 3))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 24000, PrintingHouseId = 3, CategoryId = 3 });
            }
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 3 && cbp.CategoryId == 4))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 35000, PrintingHouseId = 3, CategoryId = 4 });
            }
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 3 && cbp.CategoryId == 5))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 41000, PrintingHouseId = 3, CategoryId = 5 });
            }
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 3 && cbp.CategoryId == 7))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 33000, PrintingHouseId = 3, CategoryId = 7 });
            }
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 3 && cbp.CategoryId == 8))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 31000, PrintingHouseId = 3, CategoryId = 8 });
            }
            
            //PH 4
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 4 && cbp.CategoryId == 1))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 19000, PrintingHouseId = 4, CategoryId = 1 });
            }
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 4 && cbp.CategoryId == 3))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 26000, PrintingHouseId = 4, CategoryId = 3 });
            }
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 4 && cbp.CategoryId == 4))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 23000, PrintingHouseId = 4, CategoryId = 4 });
            }
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 4 && cbp.CategoryId == 5))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 41000, PrintingHouseId = 4, CategoryId = 5 });
            }
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 4 && cbp.CategoryId == 6))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 31000, PrintingHouseId = 4, CategoryId = 6 });
            }
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 4 && cbp.CategoryId == 7))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 28000, PrintingHouseId = 4, CategoryId = 7 });
            }
            if (!_catbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 4 && cbp.CategoryId == 7))
            {
                _catbpRepository.Add(new CategoryBasePrice { CategoryPrice = 31000, PrintingHouseId = 4, CategoryId = 7 });
            }
            #endregion

            #region Sizes
            //PH 1
            if (!_sbpRepository.TableNoTracking.Any(sbp => sbp.PrintingHouseId == 1 && sbp.SizeId == 1))
            {
                _sbpRepository.Add(new SizeBasePrice { SizePer = 1, PrintingHouseId = 1, SizeId = 1});
            }
            if (!_sbpRepository.TableNoTracking.Any(sbp => sbp.PrintingHouseId == 1 && sbp.SizeId == 2))
            {
                _sbpRepository.Add(new SizeBasePrice { SizePer = 1.2, PrintingHouseId = 1, SizeId = 2});
            }
            if (!_sbpRepository.TableNoTracking.Any(sbp => sbp.PrintingHouseId == 1 && sbp.SizeId == 3))
            {
                _sbpRepository.Add(new SizeBasePrice { SizePer = 1.4, PrintingHouseId = 1, SizeId = 3});
            }
            if (!_sbpRepository.TableNoTracking.Any(sbp => sbp.PrintingHouseId == 1 && sbp.SizeId == 4))
            {
                _sbpRepository.Add(new SizeBasePrice { SizePer = 1.2, PrintingHouseId = 1, SizeId = 4});
            }
            if (!_sbpRepository.TableNoTracking.Any(sbp => sbp.PrintingHouseId == 1 && sbp.SizeId == 5))
            {
                _sbpRepository.Add(new SizeBasePrice { SizePer = 1.3, PrintingHouseId = 1, SizeId = 5});
            }

            //PH 2
            if (!_sbpRepository.TableNoTracking.Any(sbp => sbp.PrintingHouseId == 2 && sbp.SizeId == 1))
            {
                _sbpRepository.Add(new SizeBasePrice { SizePer = 1, PrintingHouseId = 2, SizeId = 1});
            }
            if (!_sbpRepository.TableNoTracking.Any(sbp => sbp.PrintingHouseId == 2 && sbp.SizeId == 2))
            {
                _sbpRepository.Add(new SizeBasePrice { SizePer = 1.21, PrintingHouseId = 2, SizeId = 2});
            }
            if (!_sbpRepository.TableNoTracking.Any(sbp => sbp.PrintingHouseId == 2 && sbp.SizeId == 3))
            {
                _sbpRepository.Add(new SizeBasePrice { SizePer = 1.41, PrintingHouseId = 2, SizeId = 3});
            }
            if (!_sbpRepository.TableNoTracking.Any(sbp => sbp.PrintingHouseId == 2 && sbp.SizeId == 4))
            {
                _sbpRepository.Add(new SizeBasePrice { SizePer = 1.18, PrintingHouseId = 2, SizeId = 4});
            }
            if (!_sbpRepository.TableNoTracking.Any(sbp => sbp.PrintingHouseId == 2 && sbp.SizeId == 5))
            {
                _sbpRepository.Add(new SizeBasePrice { SizePer = 1.35, PrintingHouseId = 2, SizeId = 5});
            }

            //PH 3
            if (!_sbpRepository.TableNoTracking.Any(sbp => sbp.PrintingHouseId == 3 && sbp.SizeId == 1))
            {
                _sbpRepository.Add(new SizeBasePrice { SizePer = 1, PrintingHouseId = 3, SizeId = 1});
            }
            if (!_sbpRepository.TableNoTracking.Any(sbp => sbp.PrintingHouseId == 3 && sbp.SizeId == 2))
            {
                _sbpRepository.Add(new SizeBasePrice { SizePer = 1.17, PrintingHouseId = 3, SizeId = 2});
            }
            if (!_sbpRepository.TableNoTracking.Any(sbp => sbp.PrintingHouseId == 3 && sbp.SizeId == 3))
            {
                _sbpRepository.Add(new SizeBasePrice { SizePer = 1.09, PrintingHouseId = 3, SizeId = 3});
            }
            if (!_sbpRepository.TableNoTracking.Any(sbp => sbp.PrintingHouseId == 3 && sbp.SizeId == 4))
            {
                _sbpRepository.Add(new SizeBasePrice { SizePer = 1.22, PrintingHouseId = 3, SizeId = 4});
            }
            if (!_sbpRepository.TableNoTracking.Any(sbp => sbp.PrintingHouseId == 3 && sbp.SizeId == 5))
            {
                _sbpRepository.Add(new SizeBasePrice { SizePer = 1.32, PrintingHouseId = 3, SizeId = 5});
            }

            //PH 4
            if (!_sbpRepository.TableNoTracking.Any(sbp => sbp.PrintingHouseId == 4 && sbp.SizeId == 1))
            {
                _sbpRepository.Add(new SizeBasePrice { SizePer = 1, PrintingHouseId = 4, SizeId = 1});
            }
            if (!_sbpRepository.TableNoTracking.Any(sbp => sbp.PrintingHouseId == 4 && sbp.SizeId == 2))
            {
                _sbpRepository.Add(new SizeBasePrice { SizePer = 1.14, PrintingHouseId = 4, SizeId = 2});
            }
            if (!_sbpRepository.TableNoTracking.Any(sbp => sbp.PrintingHouseId == 4 && sbp.SizeId == 3))
            {
                _sbpRepository.Add(new SizeBasePrice { SizePer = 1.17, PrintingHouseId = 4, SizeId = 3});
            }
            if (!_sbpRepository.TableNoTracking.Any(sbp => sbp.PrintingHouseId == 4 && sbp.SizeId == 4))
            {
                _sbpRepository.Add(new SizeBasePrice { SizePer = 1.15, PrintingHouseId = 4, SizeId = 4});
            }
            if (!_sbpRepository.TableNoTracking.Any(sbp => sbp.PrintingHouseId == 4 && sbp.SizeId == 5))
            {
                _sbpRepository.Add(new SizeBasePrice { SizePer = 1.12, PrintingHouseId = 4, SizeId = 5});
            }
            #endregion

            #region Colors
            //PH 1
            if (!_colbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 1 && cbp.ColorId == 1))
            {
                _colbpRepository.Add(new ColorBasePrice { ColorPer = 1, PrintingHouseId = 1, ColorId = 1 });
            }
            if (!_colbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 1 && cbp.ColorId == 2))
            {
                _colbpRepository.Add(new ColorBasePrice { ColorPer = 1.3, PrintingHouseId = 1, ColorId = 2 });
            }
            if (!_colbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 1 && cbp.ColorId == 3))
            {
                _colbpRepository.Add(new ColorBasePrice { ColorPer = 1.15, PrintingHouseId = 1, ColorId = 3 });
            }
            if (!_colbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 1 && cbp.ColorId == 4))
            {
                _colbpRepository.Add(new ColorBasePrice { ColorPer = 1.12, PrintingHouseId = 1, ColorId = 4 });
            }
            if (!_colbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 1 && cbp.ColorId == 5))
            {
                _colbpRepository.Add(new ColorBasePrice { ColorPer = 1.2, PrintingHouseId = 1, ColorId = 5 });
            }

            //PH 2
            if (!_colbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 2 && cbp.ColorId == 1))
            {
                _colbpRepository.Add(new ColorBasePrice { ColorPer = 1, PrintingHouseId = 2, ColorId = 1 });
            }
            if (!_colbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 2 && cbp.ColorId == 2))
            {
                _colbpRepository.Add(new ColorBasePrice { ColorPer = 1.3, PrintingHouseId = 2, ColorId = 2 });
            }
            if (!_colbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 2 && cbp.ColorId == 3))
            {
                _colbpRepository.Add(new ColorBasePrice { ColorPer = 1.2, PrintingHouseId = 2, ColorId = 3 });
            }
            if (!_colbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 2 && cbp.ColorId == 4))
            {
                _colbpRepository.Add(new ColorBasePrice { ColorPer = 1.1, PrintingHouseId = 2, ColorId = 4 });
            }
            if (!_colbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 2 && cbp.ColorId == 5))
            {
                _colbpRepository.Add(new ColorBasePrice { ColorPer = 1.25, PrintingHouseId = 2, ColorId = 5 });
            }

            //PH 3
            if (!_colbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 3 && cbp.ColorId == 1))
            {
                _colbpRepository.Add(new ColorBasePrice { ColorPer = 1, PrintingHouseId = 3, ColorId = 1 });
            }
            if (!_colbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 3 && cbp.ColorId == 2))
            {
                _colbpRepository.Add(new ColorBasePrice { ColorPer = 1.27, PrintingHouseId = 3, ColorId = 2 });
            }
            if (!_colbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 3 && cbp.ColorId == 3))
            {
                _colbpRepository.Add(new ColorBasePrice { ColorPer = 1.18, PrintingHouseId = 3, ColorId = 3 });
            }
            if (!_colbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 3 && cbp.ColorId == 4))
            {
                _colbpRepository.Add(new ColorBasePrice { ColorPer = 1.2, PrintingHouseId = 3, ColorId = 4 });
            }
            if (!_colbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 3 && cbp.ColorId == 5))
            {
                _colbpRepository.Add(new ColorBasePrice { ColorPer = 1.12, PrintingHouseId = 3, ColorId = 5 });
            }

            //PH 4
            if (!_colbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 4 && cbp.ColorId == 1))
            {
                _colbpRepository.Add(new ColorBasePrice { ColorPer = 1, PrintingHouseId = 4, ColorId = 1 });
            }
            if (!_colbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 4 && cbp.ColorId == 2))
            {
                _colbpRepository.Add(new ColorBasePrice { ColorPer = 1.32, PrintingHouseId = 4, ColorId = 2 });
            }
            if (!_colbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 4 && cbp.ColorId == 3))
            {
                _colbpRepository.Add(new ColorBasePrice { ColorPer = 1.26, PrintingHouseId = 4, ColorId = 3 });
            }
            if (!_colbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 4 && cbp.ColorId == 4))
            {
                _colbpRepository.Add(new ColorBasePrice { ColorPer = 1.16, PrintingHouseId = 4, ColorId = 4 });
            }
            if (!_colbpRepository.TableNoTracking.Any(cbp => cbp.PrintingHouseId == 4 && cbp.ColorId == 5))
            {
                _colbpRepository.Add(new ColorBasePrice { ColorPer = 1.21, PrintingHouseId = 4, ColorId = 5 });
            }
            #endregion

            #region Quantities
            //PH 1
            if (!_qbpRepository.TableNoTracking.Any(qbp => qbp.PrintingHouseId == 1 && qbp.QuantityId == 1))
            {
                _qbpRepository.Add(new QuantityBasePrice { QuantityPer = 1, PrintingHouseId = 1, QuantityId = 1 });
            }
            if (!_qbpRepository.TableNoTracking.Any(qbp => qbp.PrintingHouseId == 1 && qbp.QuantityId == 2))
            {
                _qbpRepository.Add(new QuantityBasePrice { QuantityPer = 1.32, PrintingHouseId = 1, QuantityId = 2 });
            }
            if (!_qbpRepository.TableNoTracking.Any(qbp => qbp.PrintingHouseId == 1 && qbp.QuantityId == 3))
            {
                _qbpRepository.Add(new QuantityBasePrice { QuantityPer = 1.81, PrintingHouseId = 1, QuantityId = 3 });
            }
            if (!_qbpRepository.TableNoTracking.Any(qbp => qbp.PrintingHouseId == 1 && qbp.QuantityId == 4))
            {
                _qbpRepository.Add(new QuantityBasePrice { QuantityPer = 2.22, PrintingHouseId = 1, QuantityId = 4 });
            }
            if (!_qbpRepository.TableNoTracking.Any(qbp => qbp.PrintingHouseId == 1 && qbp.QuantityId == 5))
            {
                _qbpRepository.Add(new QuantityBasePrice { QuantityPer = 3.20, PrintingHouseId = 1, QuantityId = 5 });
            }

            //PH 2
            if (!_qbpRepository.TableNoTracking.Any(qbp => qbp.PrintingHouseId == 2 && qbp.QuantityId == 1))
            {
                _qbpRepository.Add(new QuantityBasePrice { QuantityPer = 1, PrintingHouseId = 2, QuantityId = 1 });
            }
            if (!_qbpRepository.TableNoTracking.Any(qbp => qbp.PrintingHouseId == 2 && qbp.QuantityId == 2))
            {
                _qbpRepository.Add(new QuantityBasePrice { QuantityPer = 1.5, PrintingHouseId = 2, QuantityId = 2 });
            }
            if (!_qbpRepository.TableNoTracking.Any(qbp => qbp.PrintingHouseId == 2 && qbp.QuantityId == 3))
            {
                _qbpRepository.Add(new QuantityBasePrice { QuantityPer = 1.96, PrintingHouseId = 2, QuantityId = 3 });
            }
            if (!_qbpRepository.TableNoTracking.Any(qbp => qbp.PrintingHouseId == 2 && qbp.QuantityId == 4))
            {
                _qbpRepository.Add(new QuantityBasePrice { QuantityPer = 2.64, PrintingHouseId = 2, QuantityId = 4 });
            }
            if (!_qbpRepository.TableNoTracking.Any(qbp => qbp.PrintingHouseId == 2 && qbp.QuantityId == 5))
            {
                _qbpRepository.Add(new QuantityBasePrice { QuantityPer = 3.26, PrintingHouseId = 2, QuantityId = 5 });
            }

            //PH 3
            if (!_qbpRepository.TableNoTracking.Any(qbp => qbp.PrintingHouseId == 3 && qbp.QuantityId == 1))
            {
                _qbpRepository.Add(new QuantityBasePrice { QuantityPer = 1, PrintingHouseId = 3, QuantityId = 1 });
            }
            if (!_qbpRepository.TableNoTracking.Any(qbp => qbp.PrintingHouseId == 3 && qbp.QuantityId == 2))
            {
                _qbpRepository.Add(new QuantityBasePrice { QuantityPer = 1.7, PrintingHouseId = 3, QuantityId = 2 });
            }
            if (!_qbpRepository.TableNoTracking.Any(qbp => qbp.PrintingHouseId == 3 && qbp.QuantityId == 3))
            {
                _qbpRepository.Add(new QuantityBasePrice { QuantityPer = 2.2, PrintingHouseId = 3, QuantityId = 3 });
            }
            if (!_qbpRepository.TableNoTracking.Any(qbp => qbp.PrintingHouseId == 3 && qbp.QuantityId == 4))
            {
                _qbpRepository.Add(new QuantityBasePrice { QuantityPer = 3, PrintingHouseId = 3, QuantityId = 4 });
            }
            if (!_qbpRepository.TableNoTracking.Any(qbp => qbp.PrintingHouseId == 3 && qbp.QuantityId == 5))
            {
                _qbpRepository.Add(new QuantityBasePrice { QuantityPer = 3.9, PrintingHouseId = 3, QuantityId = 5 });
            }

            //PH 4
            if (!_qbpRepository.TableNoTracking.Any(qbp => qbp.PrintingHouseId == 4 && qbp.QuantityId == 1))
            {
                _qbpRepository.Add(new QuantityBasePrice { QuantityPer = 1, PrintingHouseId = 4, QuantityId = 1 });
            }
            if (!_qbpRepository.TableNoTracking.Any(qbp => qbp.PrintingHouseId == 4 && qbp.QuantityId == 2))
            {
                _qbpRepository.Add(new QuantityBasePrice { QuantityPer = 1.97, PrintingHouseId = 4, QuantityId = 2 });
            }
            if (!_qbpRepository.TableNoTracking.Any(qbp => qbp.PrintingHouseId == 4 && qbp.QuantityId == 3))
            {
                _qbpRepository.Add(new QuantityBasePrice { QuantityPer = 2.5, PrintingHouseId = 4, QuantityId = 3 });
            }
            if (!_qbpRepository.TableNoTracking.Any(qbp => qbp.PrintingHouseId == 4 && qbp.QuantityId == 4))
            {
                _qbpRepository.Add(new QuantityBasePrice { QuantityPer = 3.1, PrintingHouseId = 4, QuantityId = 4 });
            }
            if (!_qbpRepository.TableNoTracking.Any(qbp => qbp.PrintingHouseId == 4 && qbp.QuantityId == 5))
            {
                _qbpRepository.Add(new QuantityBasePrice { QuantityPer = 4, PrintingHouseId = 4, QuantityId = 5 });
            }
            #endregion

            #region RoundedCorners
            //PH 1
            if (!_rbpRepository.TableNoTracking.Any(rbp => rbp.PrintingHouseId == 1 && rbp.RoundedCorner.Equals(false)))
            {
                _rbpRepository.Add(new RoundedCornerBasePrice { RoundedCornerPer = 1, PrintingHouseId = 1, RoundedCorner = false });
            }
            if (!_rbpRepository.TableNoTracking.Any(rbp => rbp.PrintingHouseId == 1 && rbp.RoundedCorner.Equals(true)))
            {
                _rbpRepository.Add(new RoundedCornerBasePrice { RoundedCornerPer = 1.2, PrintingHouseId = 1, RoundedCorner = true });
            }

            //PH 2
            if (!_rbpRepository.TableNoTracking.Any(rbp => rbp.PrintingHouseId == 2 && rbp.RoundedCorner.Equals(false)))
            {
                _rbpRepository.Add(new RoundedCornerBasePrice { RoundedCornerPer = 1, PrintingHouseId = 2, RoundedCorner = false });
            }
            if (!_rbpRepository.TableNoTracking.Any(rbp => rbp.PrintingHouseId == 2 && rbp.RoundedCorner.Equals(true)))
            {
                _rbpRepository.Add(new RoundedCornerBasePrice { RoundedCornerPer = 1.3, PrintingHouseId = 2, RoundedCorner = true });
            }

            //PH 3
            if (!_rbpRepository.TableNoTracking.Any(rbp => rbp.PrintingHouseId == 3 && rbp.RoundedCorner.Equals(false)))
            {
                _rbpRepository.Add(new RoundedCornerBasePrice { RoundedCornerPer = 1, PrintingHouseId = 3, RoundedCorner = false });
            }
            if (!_rbpRepository.TableNoTracking.Any(rbp => rbp.PrintingHouseId == 3 && rbp.RoundedCorner.Equals(true)))
            {
                _rbpRepository.Add(new RoundedCornerBasePrice { RoundedCornerPer = 1.23, PrintingHouseId = 3, RoundedCorner = true });
            }

            //PH 4
            if (!_rbpRepository.TableNoTracking.Any(rbp => rbp.PrintingHouseId == 4 && rbp.RoundedCorner.Equals(false)))
            {
                _rbpRepository.Add(new RoundedCornerBasePrice { RoundedCornerPer = 1, PrintingHouseId = 4, RoundedCorner = false });
            }
            if (!_rbpRepository.TableNoTracking.Any(rbp => rbp.PrintingHouseId == 4 && rbp.RoundedCorner.Equals(true)))
            {
                _rbpRepository.Add(new RoundedCornerBasePrice { RoundedCornerPer = 1.25, PrintingHouseId = 4, RoundedCorner = true });
            }
            #endregion
        }
    }
}
