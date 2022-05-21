using System;
using DataModel;
using System.Linq;
using System.Text;
using Contracts.Interfaces;
using System.Threading.Tasks;
using DataModel.Models.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class StoreHeaderRepository : RepositoryBase<StoreHeader>, IStoreHeader
    {
        public StoreHeaderRepository(MMSDbContext repositoryContext) : base(repositoryContext)
        {

        }
        public void CreateStoreHeader(StoreHeader storeHeader) => Create(storeHeader);

        public void DeleteStoreHeader(StoreHeader storeHeader) => Delete(storeHeader);

        public async Task<IEnumerable<StoreHeader>> GetAllStoreHeadersAsync(bool trackChanges)=>
            await FindAll(trackChanges)
                       .OrderBy(c => c.itemNoInExpenditureRegister)
                       .ToListAsync();

        public async Task<StoreHeader> GetStoreHeaderAsync(int storeHeaderId, bool trackChanges) =>
         await FindByCondition(c => c.id.Equals(storeHeaderId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
