using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Models.Entities;
using System.Collections.Generic;

namespace Contracts.Interfaces
{
    public interface IStoreItem
    {
        Task<IEnumerable<StoreItem>> GetAllStoreItemsAsync(bool trackChanges);
        Task<IEnumerable<StoreItem>> GetStoreItemsAsync(int storeHeaderId, bool trackChanges);
        Task<StoreItem> GetStoreItemAsync(int storeHeaderId, int id, bool trackChanges);
        void CreateStoreItemForStoreHeader(int storeHeaderId, StoreItem storeItem);
        void DeleteStoreItem(StoreItem storeItem);
    }
}
