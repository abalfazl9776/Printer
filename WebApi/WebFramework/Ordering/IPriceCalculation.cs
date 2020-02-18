using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Entities.Service;

namespace WebFramework.Ordering
{
    public interface IPriceCalculation
    {
        Task<List<PriceSelectDto>> CalculatePrice(Attribute attribute, int categoryId, CancellationToken cancellationToken);
    }
}