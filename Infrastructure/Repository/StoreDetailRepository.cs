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
    public class StoreItemRepository : RepositoryBase<StoreItem>, IStoreItem
    {
        public StoreItemRepository(MMSDbContext repositoryContext) : base(repositoryContext)
        {

        }
        public void CreateStoreItemForStoreHeader(int storeHeaderId, StoreItem storeItem)
        {
            storeItem.storeHeaderId = storeHeaderId;
            Create(storeItem);
        }

        public void DeleteStoreItem(StoreItem storeItem)
        {
              Delete(storeItem);
        }

        public async Task<IEnumerable<StoreItem>> GetAllStoreItemsAsync(bool trackChanges)
        {
           return await FindAll(trackChanges)
                       .OrderBy(c => c.model)
                       .ToListAsync();
        }

        public async Task<StoreItem> GetStoreItemAsync(int storeHeaderId, int id, bool trackChanges) =>
            await FindByCondition(e => e.storeHeaderId.Equals(storeHeaderId) && e.id.Equals(id), trackChanges)
             .SingleOrDefaultAsync();

        public async Task<IEnumerable<StoreItem>> GetStoreItemsAsync(int storeHeaderId, bool trackChanges) =>
            await FindByCondition(e => e.storeHeaderId.Equals(storeHeaderId), trackChanges)
            .OrderBy(e => e.type)
            .ToListAsync();
    }
}
