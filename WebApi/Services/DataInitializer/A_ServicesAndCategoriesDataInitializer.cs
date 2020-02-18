using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Data.Contracts;
using Entities.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Services.DataInitializer
{
    public class A_ServicesAndCategoriesDataInitializer : IDataInitializer
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Service> _serviceRepository;
        private readonly string rootFolder = "cards_and_banners/";

        public A_ServicesAndCategoriesDataInitializer(IRepository<Category> categoryRepository
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
                    Service = service,
                    Description = new Description
                    {
                        DescriptionText = "کارت های کوچک",
                        ImageUrls = new List<ImageUrl> { new ImageUrl { Url = rootFolder + "mini.jpg"}}
                    }
                });
            }
            if (!_categoryRepository.TableNoTracking.Any(p => p.Name == "Standard"))
            {
                _categoryRepository.Add(new Category
                {
                    Name = "Standard",
                    Service = service,
                    Description = new Description
                    {
                        DescriptionText = "کارت معمولی",
                        ImageUrls = new List<ImageUrl> { new ImageUrl { Url = rootFolder + "standard.jpg"}}
                    }
                });
            }
            if (!_categoryRepository.TableNoTracking.Any(p => p.Name == "Square"))
            {
                _categoryRepository.Add(new Category
                {
                    Name = "Square",
                    Service = service,
                    Description = new Description
                    {
                        DescriptionText = "کارت مربعی شکل",
                        ImageUrls = new List<ImageUrl> { new ImageUrl { Url = rootFolder + "square.jpg"}}
                    }
                });
            }
            if (!_categoryRepository.TableNoTracking.Any(p => p.Name == "Metallic"))
            {
                _categoryRepository.Add(new Category
                {
                    Name = "Metallic",
                    Service = service,
                    Description = new Description
                    {
                        DescriptionText = "کارت بررراق",
                        ImageUrls = new List<ImageUrl> { new ImageUrl { Url = rootFolder + "metallic.jpg"}}
                    }
                });
            }
            if (!_categoryRepository.TableNoTracking.Any(p => p.Name == "PaintedEdge"))
            {
                _categoryRepository.Add(new Category
                {
                    Name = "PaintedEdge",
                    Service = service,
                    Description = new Description
                    {
                        DescriptionText = "کارت های لبه رنگی",
                        ImageUrls = new List<ImageUrl> { new ImageUrl { Url = rootFolder + "painted_edge.jpg"}}
                    }
                });
            }
            if (!_categoryRepository.TableNoTracking.Any(p => p.Name == "Silk"))
            {
                _categoryRepository.Add(new Category
                {
                    Name = "Silk",
                    Service = service,
                    Description = new Description
                    {
                        DescriptionText = "کارتی از جنس ابریشم",
                        ImageUrls = new List<ImageUrl> { new ImageUrl { Url = rootFolder + "silk.jpg"}}
                    }
                });
            }
            if (!_categoryRepository.TableNoTracking.Any(p => p.Name == "DieCut"))
            {
                _categoryRepository.Add(new Category
                {
                    Name = "DieCut",
                    Service = service,
                    Description = new Description
                    {
                        DescriptionText = "کارت هایی با برش های غیر معقول",
                        ImageUrls = new List<ImageUrl> { new ImageUrl { Url = rootFolder + "die_cut.jpg"}}
                    }
                });
            }
            if (!_categoryRepository.TableNoTracking.Any(p => p.Name == "Plastic"))
            {
                _categoryRepository.Add(new Category
                {
                    Name = "Plastic",
                    Service = service,
                    Description = new Description
                    {
                        DescriptionText = "کارت پلاستیکی خوشگل و قابل شستشو",
                        ImageUrls = new List<ImageUrl> { new ImageUrl { Url = rootFolder + "plastic.jpg"}}
                    }
                });
            }
        }
    }
}
