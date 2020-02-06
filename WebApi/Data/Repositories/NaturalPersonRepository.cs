using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Data.Contracts;
using Entities.Customer.NaturalPerson;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class NaturalPersonRepository : Repository<NaturalPerson>, INaturalPersonRepository
    { 
        public NaturalPersonRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
        }

        public Task<NaturalPerson> GetPersonByIdAsync(int naturalPersonId, CancellationToken cancellationToken)
        {
            return Table.Where(p => p.Id.Equals(naturalPersonId))
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
