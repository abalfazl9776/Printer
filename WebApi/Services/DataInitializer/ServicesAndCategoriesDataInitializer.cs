using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Contracts;
using Entities.Service;
using Microsoft.EntityFrameworkCore;

namespace Services.DataInitializer
{
    public class ServicesAndCategoriesDataInitializer : IDataInitializer
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Service> _serviceRepository;

        public ServicesAndCategoriesDataInitializer(IRepository<Category> categoryRepository
            , IRepository<Service> serviceRepository)
        {
            this._categoryRepository = categoryRepository;
            this._serviceRepository = serviceRepository;
        }

        public void InitializeData()
        {
            InitializeServices();
            InitializeCategories();
        }

        private void InitializeServices()
        {
            if (!_serviceRepository.TableNoTracking.Any(p => p.Name == "Banner"))
            {
                _serviceRepository.Add(new Service
                {
                    Name = "Banner"
                });
            }
            if (!_serviceRepository.TableNoTracking.Any(p => p.Name == "VisitCard"))
            {
                _serviceRepository.Add(new Service
                {
                    Name = "VisitCard"
                });
            }
            if (!_serviceRepository.TableNoTracking.Any(p => p.Name == "Flag"))
            {
                _serviceRepository.Add(new Service
                {
                    Name = "Flag"
                });
            }
        }

        private void InitializeCategories()
        {
            Service service = _serviceRepository.Table.SingleOrDefault(p => p.Name.Equals("VisitCard"));

            if (!_categoryRepository.TableNoTracking.Any(p => p.Name == "Mini"))
            {
                _categoryRepository.Add(new Category
                {
                    Name = "Mini",
                    Service = service
                });
            }
            if (!_categoryRepository.TableNoTracking.Any(p => p.Name == "Standard"))
            {
                _categoryRepository.Add(new Category
                {
                    Name = "Standard",
                    Service = service
                });
            }
            if (!_categoryRepository.TableNoTracking.Any(p => p.Name == "Square"))
            {
                _categoryRepository.Add(new Category
                {
                    Name = "Square",
                    Service = service
                });
            }
            if (!_categoryRepository.TableNoTracking.Any(p => p.Name == "Metallic"))
            {
                _categoryRepository.Add(new Category
                {
                    Name = "Metallic",
                    Service = service
                });
            }
            if (!_categoryRepository.TableNoTracking.Any(p => p.Name == "PaintedEdge"))
            {
                _categoryRepository.Add(new Category
                {
                    Name = "PaintedEdge",
                    Service = service
                });
            }
            if (!_categoryRepository.TableNoTracking.Any(p => p.Name == "Silk"))
            {
                _categoryRepository.Add(new Category
                {
                    Name = "Silk",
                    Service = service
                });
            }
            if (!_categoryRepository.TableNoTracking.Any(p => p.Name == "Magnet"))
            {
                _categoryRepository.Add(new Category
                {
                    Name = "Magnet",
                    Service = service
                });
            }
        }
    }
}
