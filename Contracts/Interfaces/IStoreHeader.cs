using System;
using System.Linq;
using System.Text;
using DataModel.Parameters;
using System.Threading.Tasks;
using DataModel.Models.Entities;
using System.Collections.Generic;

namespace Contracts.Interfaces
{
    public interface IStoreHeader
    {
        Task<PagedList<StoreHeader>> GetAllStoreHeadersAsync(StoreHeaderParameters storeHeaderParameters, bool trackChanges);
        Task<StoreHeader> GetStoreHeaderAsync(int storeHeaderId, bool trackChanges);
        void CreateStoreHeader(StoreHeader storeHeader);
        void DeleteStoreHeader(StoreHeader storeHeader);
    }
}
