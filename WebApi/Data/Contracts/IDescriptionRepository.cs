using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Entities.Service;
using Entities.User;

namespace Data.Contracts
{
    public interface IDescriptionRepository : IRepository<Description>
    {
        Task<Description> GetDescription(Category category, CancellationToken cancellationToken);
        /*Task AddAsync(User user, string password, CancellationToken cancellationToken);
        Task UpdateSecurityStampAsync(User user, CancellationToken cancellationToken);
        Task UpdateLastLoginDateAsync(User user, CancellationToken cancellationToken);*/
    }
}
