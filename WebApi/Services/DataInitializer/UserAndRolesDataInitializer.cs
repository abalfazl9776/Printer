using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Data.Contracts;
using Entities.PrintingHouse;
using Entities.User;

namespace Services.DataInitializer
{
    public class UserAndRolesDataInitializer : IDataInitializer
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IRepository<PrintingHouse> _printingHouseRepository;
        private readonly IRepository<PrintingHouseWallet> _phWalletRepository;

        public UserAndRolesDataInitializer(RoleManager<Role> roleManager, UserManager<User> userManager, 
            IRepository<PrintingHouse> printingHouseRepository, IRepository<PrintingHouseWallet> phWalletRepository)
        {
            this._roleManager = roleManager;
            this._userManager = userManager;
            _printingHouseRepository = printingHouseRepository;
            _phWalletRepository = phWalletRepository;
        }

        public void InitializeData()
        {
            InitializeRoles();
            InitializeUsers();
        }

        public void InitializeRoles()
        {
            if (!_roleManager.Roles.AsNoTracking().Any(p => p.Name.Equals(PredefinedRoles.Admin.ToString())))
            {
                var role = new Role
                {
                    Name = PredefinedRoles.Admin.ToString(),
                    Description = "Admin has access to anything."
                };
                var result = _roleManager.CreateAsync(role).GetAwaiter().GetResult();
            }
            if (!_roleManager.Roles.AsNoTracking().Any(p => p.Name.Equals(PredefinedRoles.NaturalPerson.ToString())))
            {
                var role = new Role
                {
                    Name = PredefinedRoles.NaturalPerson.ToString(),
                    Description = "Natural Person is a customer type (also a client)."
                };
                var result = _roleManager.CreateAsync(role).GetAwaiter().GetResult();
            }
            if (!_roleManager.Roles.AsNoTracking().Any(p => p.Name.Equals(PredefinedRoles.AdvertisingCenter.ToString())))
            {
                var role = new Role
                {
                    Name = PredefinedRoles.AdvertisingCenter.ToString(),
                    Description = "Advertising center is a customer type (also a client)."
                };
                var result = _roleManager.CreateAsync(role).GetAwaiter().GetResult();
            }
            if (!_roleManager.Roles.AsNoTracking().Any(p => p.Name.Equals(PredefinedRoles.PrintingHouse.ToString())))
            {
                var role = new Role
                {
                    Name = PredefinedRoles.PrintingHouse.ToString(),
                    Description = "Printing house is a client type."
                };
                var result = _roleManager.CreateAsync(role).GetAwaiter().GetResult();
            }
        }

        public async Task InitializeUsers()
        {
            if (!_userManager.Users.AsNoTracking().Any(p => p.UserName == "admin"))
            {
                var user = new User
                {
                    UserName = "admin",
                    Email = "admin@site.com",
                    IsActive = true
                    
                };
                var addUser = _userManager.CreateAsync(user, "123123").GetAwaiter().GetResult();
                if (addUser.Succeeded)
                {
                    User admin = _userManager.FindByNameAsync(user.UserName).GetAwaiter().GetResult();
                    var addToRole = _userManager.AddToRoleAsync(admin, PredefinedRoles.Admin.ToString()).GetAwaiter().GetResult();
                }
            }
            if (!_userManager.Users.AsNoTracking().Any(p => p.UserName == "1111"))
            {
                var user = new User
                {
                    UserName = "1111",
                    Email = "ph1111@printer.com",
                    IsActive = true
                    
                };
                var addUser = _userManager.CreateAsync(user, "123123").GetAwaiter().GetResult();
                if (addUser.Succeeded)
                {
                    User admin = _userManager.FindByNameAsync(user.UserName).GetAwaiter().GetResult();
                    var addToRole = _userManager.AddToRoleAsync(admin, PredefinedRoles.PrintingHouse.ToString()).GetAwaiter().GetResult();
                }
                
                var printingHouseWallet = new PrintingHouseWallet
                {
                    Iban = "111111111111",
                    Cash = 0
                };
                _phWalletRepository.Add(printingHouseWallet);

                var printingHouse = new PrintingHouse
                {
                    User = user,
                    Name = "کارخانه نقش الماس",
                    UserId = user.Id,
                    Wallet = printingHouseWallet,
                    PrintingHouseWalletId = printingHouseWallet.Id
                };

                _printingHouseRepository.Add(printingHouse);
            }
            if (!_userManager.Users.AsNoTracking().Any(p => p.UserName == "2222"))
            {
                var user = new User
                {
                    UserName = "2222",
                    Email = "ph2222@printer.com",
                    IsActive = true
                    
                };
                var addUser = _userManager.CreateAsync(user, "123123").GetAwaiter().GetResult();
                if (addUser.Succeeded)
                {
                    User admin = _userManager.FindByNameAsync(user.UserName).GetAwaiter().GetResult();
                    var addToRole = _userManager.AddToRoleAsync(admin, PredefinedRoles.PrintingHouse.ToString()).GetAwaiter().GetResult();
                }
                
                var printingHouseWallet = new PrintingHouseWallet
                {
                    Iban = "222222222222",
                    Cash = 0
                };
                _phWalletRepository.Add(printingHouseWallet);

                var printingHouse = new PrintingHouse
                {
                    User = user,
                    Name = "کارخانه ابلک و پسران",
                    UserId = user.Id,
                    Wallet = printingHouseWallet,
                    PrintingHouseWalletId = printingHouseWallet.Id
                };

                _printingHouseRepository.Add(printingHouse);
            }
            if (!_userManager.Users.AsNoTracking().Any(p => p.UserName == "3333"))
            {
                var user = new User
                {
                    UserName = "3333",
                    Email = "ph3333@printer.com",
                    IsActive = true
                    
                };
                var addUser = _userManager.CreateAsync(user, "123123").GetAwaiter().GetResult();
                if (addUser.Succeeded)
                {
                    User admin = _userManager.FindByNameAsync(user.UserName).GetAwaiter().GetResult();
                    var addToRole = _userManager.AddToRoleAsync(admin, PredefinedRoles.PrintingHouse.ToString()).GetAwaiter().GetResult();
                }
                
                var printingHouseWallet = new PrintingHouseWallet
                {
                    Iban = "333333333333",
                    Cash = 0
                };
                _phWalletRepository.Add(printingHouseWallet);

                var printingHouse = new PrintingHouse
                {
                    User = user,
                    Name = "کارخانه سید هاشم",
                    UserId = user.Id,
                    Wallet = printingHouseWallet,
                    PrintingHouseWalletId = printingHouseWallet.Id
                };

                _printingHouseRepository.Add(printingHouse);
            }
        }
    }
}