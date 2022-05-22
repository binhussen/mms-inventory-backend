using System;
using DataModel;
using System.Linq;
using System.Text;
using Contracts.Interfaces;
using DataModel.Parameters;
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
       public async Task<PagedList<StoreItem>> GetAllStoreItemsAsync(StoreItemParameters storeItemParameters, bool trackChanges)
        {
            var storeItem = await FindAll(trackChanges)
                       .OrderBy(c => c.model)
                       .ToListAsync();
            return PagedList<StoreItem>
                .ToPagedList(storeItem, storeItemParameters.PageNumber, storeItemParameters.PageSize);
        }

        public async Task<StoreItem> GetStoreItemAsync(int storeHeaderId, int id, bool trackChanges) =>
            await FindByCondition(e => e.storeHeaderId.Equals(storeHeaderId) && e.id.Equals(id), trackChanges)
             .SingleOrDefaultAsync();

        public async Task<PagedList<StoreItem>> GetStoreItemsAsync(int storeHeaderId, StoreItemParameters storeItemParameters, bool trackChanges)
        {
            var storeItems = await FindByCondition(e => e.storeHeaderId.Equals(storeHeaderId), trackChanges)
             .OrderBy(e => e.model)
             .ToListAsync();
            return PagedList<StoreItem>
             .ToPagedList(storeItems, storeItemParameters.PageNumber, storeItemParameters.PageSize);
        }
    }
}
