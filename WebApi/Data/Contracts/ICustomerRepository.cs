using System.Threading;
using System.Threading.Tasks;
using Entities.Customer;

namespace Data.Contracts
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetCustomerByUserId(int userId, CancellationToken cancellationToken);
    }
}