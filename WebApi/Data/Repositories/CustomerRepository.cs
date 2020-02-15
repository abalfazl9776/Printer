using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Data.Contracts;
using Entities.Customer;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository, IScopedDependency
    {
        public CustomerRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
        }

        public Task<Customer> GetCustomerByUserId(int userId, CancellationToken cancellationToken)
        {
            return Table.Where(p => p.UserId.Equals(userId))
                /*.Include(a => a.Category)*/.SingleOrDefaultAsync(cancellationToken);
        }

    }
}
