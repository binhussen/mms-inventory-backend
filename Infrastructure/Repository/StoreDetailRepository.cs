using Contracts.Interfaces;
using DataModel;
using DataModel.Models.Entities;
using DataModel.Parameters;
using Infrastructure.Extensions;
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
               .FilterStoreItems(storeItemParameters.MinQuantity, storeItemParameters.MaxQuantity)
              .Search(storeItemParameters.SearchTerm)
             .OrderBy(e => e.model)
             .ToListAsync();
            return PagedList<StoreItem>
             .ToPagedList(storeItems, storeItemParameters.PageNumber, storeItemParameters.PageSize);
        }

        public async Task<IEnumerable<StoreItem>> GetStoreByQtyAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                        .OrderByDescending(c => c.availableQuantity)
                       .ToListAsync();
        public async Task<StoreItem> GetStoreByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(e => e.id.Equals(id), trackChanges)
             .SingleOrDefaultAsync();

        public async Task UpdateStoreAsync(StoreItem storeItem)
        {
            if (RepositoryContext.StoreItems.Any(x => x.id != storeItem.id &&
                                   x.model.ToLower() == storeItem.model.ToLower())) return;


            var inv = await this.RepositoryContext.StoreItems.FindAsync(storeItem.id);
            if (inv != null)
            {
                inv.model = storeItem.model;
                inv.storeNo = storeItem.storeNo;
                inv.quantity = storeItem.quantity;
                inv.type = storeItem.type;
                inv.availableQuantity = storeItem.availableQuantity;
                inv.availability = storeItem.availability;
                inv.serialNo = storeItem.serialNo;
                inv.storeHeaderId = storeItem.storeHeaderId;
                inv.shelfNo = storeItem.shelfNo;
                inv.itemDescription = storeItem.itemDescription;
                await RepositoryContext.SaveChangesAsync();
            }
        }
    }
}
