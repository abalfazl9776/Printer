﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Data.Contracts;
using Entities.Service;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    class DescriptionRepository : Repository<Description>, IDescriptionRepository
    {
        public DescriptionRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
        }

        public Task<Description> GetDescription(Service service, Category category, CancellationToken cancellationToken)
        {
            return Table.Where(p => p.Service.Id.Equals(service.Id) && p.Category.Id.Equals(category.Id))
                .SingleOrDefaultAsync(cancellationToken);
        }

    }
}