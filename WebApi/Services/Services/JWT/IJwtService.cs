using System.Threading.Tasks;
using Entities.User;

namespace Services.Services.JWT
{
    public interface IJwtService
    {
        Task<AccessToken> GenerateAsync(User user);
    }
}