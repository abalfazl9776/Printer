using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Entities.User;

namespace Services.DataInitializer
{
    public class UserDataInitializer : IDataInitializer
    {
        private readonly UserManager<User> _userManager;

        public UserDataInitializer(UserManager<User> userManager)
        {
            this._userManager = userManager;
        }

        public void InitializeData()
        {
            if (!_userManager.Users.AsNoTracking().Any(p => p.UserName == "admin"))
            {
                var user = new User
                {
                    FullName = "abolfazl vayani",
                    Gender = GenderType.Male,
                    UserName = "admin",
                    Email = "admin@site.com"
                };
                var result = _userManager.CreateAsync(user, "123123").GetAwaiter().GetResult();
            }
        }
    }
}