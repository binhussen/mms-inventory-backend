using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Models.Entities;
using System.Collections.Generic;

namespace Contracts.Interfaces
{
    public interface IStoreHeader
    {
        Task<IEnumerable<StoreHeader>> GetAllStoreHeadersAsync(bool trackChanges);
        Task<StoreHeader> GetStoreHeaderAsync(int storeHeaderId, bool trackChanges);
        void CreateStoreHeader(StoreHeader storeHeader);
        void DeleteStoreHeader(StoreHeader storeHeader);
    }
}
