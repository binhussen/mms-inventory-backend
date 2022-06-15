using DataModel.Models.Entities;
using DataModel.Parameters;

namespace Contracts.Interfaces
{
    public interface IRequestItem
    {
        Task<PagedList<RequestItem>> GetRequestItemsAsync(int requestHeaderId, RequestItemParameters requestItemParameters, bool trackChanges);
        Task<RequestItem> GetRequestItemAsync(int requestHeaderId, int id, bool trackChanges);
        Task<RequestItem> GetRequestAsync(int id, bool trackChanges);
        void CreateRequestItemForRequestHeader(int requestHeaderId, RequestItem requestItem);
        void DeleteRequestItem(RequestItem requestItem);
    }
}
