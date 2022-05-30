using DataModel.Models.Entities;
using DataModel.Parameters;

namespace Contracts.Interfaces
{
    public interface IRequestHeader
    {
        Task<PagedList<RequestHeader>> GetAllRequestHeadersAsync(RequestHeaderParameters requestHeaderParameters, bool trackChanges);
        Task<RequestHeader> GetRequestHeaderAsync(int requestHeaderId, bool trackChanges);
        void CreateRequestHeader(RequestHeader requestHeader);
        void DeleteRequestHeader(RequestHeader requestHeader);
    }
}
