using System;
using System.Linq;
using System.Text;
using DataModel.Parameters;
using System.Threading.Tasks;
using DataModel.Models.Entities;
using System.Collections.Generic;

namespace Contracts.Interfaces
{
    public interface IStoreItem
    {
        Task<PagedList<StoreItem>> GetAllStoreItemsAsync(StoreItemParameters storeItemParameters, bool trackChanges);
        Task<PagedList<StoreItem>> GetStoreItemsAsync(int storeHeaderId, StoreItemParameters storeItemParameters, bool trackChanges);
        Task<StoreItem> GetStoreItemAsync(int storeHeaderId, int id, bool trackChanges);
        void CreateStoreItemForStoreHeader(int storeHeaderId, StoreItem storeItem);
        void DeleteStoreItem(StoreItem storeItem);
    }
}
