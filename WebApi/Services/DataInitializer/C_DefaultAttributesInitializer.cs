using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Contracts;
using Entities.Service;
using Entities.User;

namespace Services.DataInitializer
{
    public class C_DefaultAttributesInitializer : IDataInitializer
    {
        private readonly IRepository<Size> _sizeRepository;
        private readonly IRepository<Color> _colorRepository;
        private readonly IRepository<Quantity> _quantityRepository;

        public C_DefaultAttributesInitializer(IRepository<Size> sizeRepository, IRepository<Color> colorRepository,
            IRepository<Quantity> quantityRepository)
        {
            _sizeRepository = sizeRepository;
            _colorRepository = colorRepository;
            _quantityRepository = quantityRepository;
        }

        public void InitializeData()
        {
            //Size
            if (!_sizeRepository.TableNoTracking.Any(s => s.DefaultSize == "4 * 8"))
            {
                _sizeRepository.Add(new Size { DefaultSize = "4 * 8"});
            }
            if (!_sizeRepository.TableNoTracking.Any(s => s.DefaultSize == "5 * 9"))
            {
                _sizeRepository.Add(new Size { DefaultSize = "5 * 9"});
            }
            if (!_sizeRepository.TableNoTracking.Any(s => s.DefaultSize == "5 * 10"))
            {
                _sizeRepository.Add(new Size { DefaultSize = "5 * 10"});
            }
            if (!_sizeRepository.TableNoTracking.Any(s => s.DefaultSize == "4 * 4"))
            {
                _sizeRepository.Add(new Size { DefaultSize = "4 * 4"});
            }
            if (!_sizeRepository.TableNoTracking.Any(s => s.DefaultSize == "5 * 5"))
            {
                _sizeRepository.Add(new Size { DefaultSize = "5 * 5"});
            }
            
            //Color
            if (!_colorRepository.TableNoTracking.Any(c => c.DefaultColor == "سفید"))
            {
                _colorRepository.Add(new Color { DefaultColor = "سفید"});
            }
            if (!_colorRepository.TableNoTracking.Any(c => c.DefaultColor == "قرمز"))
            {
                _colorRepository.Add(new Color { DefaultColor = "قرمز"});
            }
            if (!_colorRepository.TableNoTracking.Any(c => c.DefaultColor == "زرد"))
            {
                _colorRepository.Add(new Color { DefaultColor = "زرد"});
            }
            if (!_colorRepository.TableNoTracking.Any(c => c.DefaultColor == "مشکی"))
            {
                _colorRepository.Add(new Color { DefaultColor = "مشکی"});
            }
            if (!_colorRepository.TableNoTracking.Any(c => c.DefaultColor == "سبز"))
            {
                _colorRepository.Add(new Color { DefaultColor = "سبز"});
            }
            
            //Quantity
            if (!_quantityRepository.TableNoTracking.Any(q => q.DefaultQuantity == 25))
            {
                _quantityRepository.Add(new Quantity { DefaultQuantity = 25});
            }
            if (!_quantityRepository.TableNoTracking.Any(q => q.DefaultQuantity == 50))
            {
                _quantityRepository.Add(new Quantity { DefaultQuantity = 50});
            }
            if (!_quantityRepository.TableNoTracking.Any(q => q.DefaultQuantity == 100))
            {
                _quantityRepository.Add(new Quantity { DefaultQuantity = 100});
            }
            if (!_quantityRepository.TableNoTracking.Any(q => q.DefaultQuantity == 200))
            {
                _quantityRepository.Add(new Quantity { DefaultQuantity = 200});
            }
            if (!_quantityRepository.TableNoTracking.Any(q => q.DefaultQuantity == 500))
            {
                _quantityRepository.Add(new Quantity { DefaultQuantity = 500});
            }
        }
    }
}
