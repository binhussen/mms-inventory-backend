using DataModel.Models.Entities;
using DataModel.Parameters;

namespace Contracts.Interfaces
{
    public interface IReturnItem
    {
        Task<PagedList<ReturnItem>> GetReturnItemsAsync(int returnHeaderId, ReturnItemParameters returnItemParameters, bool trackChanges);
        Task<ReturnItem> GetReturnItemAsync(int returnHeaderId, int id, bool trackChanges);
        Task<ReturnItem> GetReturnAsync(int id, bool trackChanges);
        void CreateReturnItemForReturnHeader(int returnHeaderId, ReturnItem returnItem);
        void DeleteReturnItem(ReturnItem returnItem);
    }
}
