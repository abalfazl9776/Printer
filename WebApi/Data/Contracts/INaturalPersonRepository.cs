using System.Threading;
using System.Threading.Tasks;
using Entities.Customer.NaturalPerson;

namespace Data.Contracts
{
    public interface INaturalPersonRepository : IRepository<NaturalPerson>
    {
        Task<NaturalPerson> GetPersonByIdAsync(int naturalPersonId, CancellationToken cancellationToken);
    }
}