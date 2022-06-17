using DataModel.Models.Entities;
using DataModel.Parameters;

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
