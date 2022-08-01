using DataModel.Models.Entities;
using DataModel.Parameters;

namespace Contracts.Interfaces
{
    public interface IStoreItem
    {
        Task<PagedList<StoreItem>> GetAllStoreItemsAsync(StoreItemParameters storeItemParameters, bool trackChanges);
        Task<PagedList<StoreItem>> GetStoreItemsAsync(int storeHeaderId, StoreItemParameters storeItemParameters, bool trackChanges);
        Task<StoreItem> GetStoreItemAsync(int storeHeaderId, int id, bool trackChanges);
        Task<IEnumerable<StoreItem>> GetStoreByQtyAsync(bool trtrackChanges);
        void CreateStoreItemForStoreHeader(int storeHeaderId, StoreItem storeItem);
        void DeleteStoreItem(StoreItem storeItem);
        Task<StoreItem> GetStoreByIdAsync(int id, bool trackChanges);
        Task UpdateStoreAsync(StoreItem storeItem);

    }
}
