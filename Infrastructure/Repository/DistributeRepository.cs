using Contracts.Interfaces;
using DataModel;
using DataModel.Models.Entities;
using DataModel.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class DistributeRepository : RepositoryBase<Distribute>, IDistribute
    {
        public DistributeRepository(MMSDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateDistribute(Distribute distribute)
        {
            Create(distribute);
        }

        public void DeleteDistribute(Distribute distribute)
        {
            Delete(distribute);
        }

        public async Task<Distribute> GetDistributeAsync(int id, bool trackChanges) =>
         await FindByCondition(e => e.id.Equals(id), trackChanges)
             .SingleOrDefaultAsync();

        public async Task<IEnumerable<Distribute>> GetDistributesAsync(DistributeParameters distributeParameters,bool trackChanges){
            var distributes = await FindAll(trackChanges)
                       .ToListAsync();
            return PagedList<Distribute>
              .ToPagedList(distributes, distributeParameters.PageNumber, distributeParameters.PageSize);
              }
    }
}



