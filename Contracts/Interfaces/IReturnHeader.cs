using DataModel.Models.Entities;
using DataModel.Parameters;

namespace Contracts.Interfaces
{
    public interface IReturnHeader
    {

        Task<PagedList<ReturnHeader>> GetAllReturnHeadersAsync(ReturnHeaderParameters returnHeaderParameters, bool trackChanges);
        Task<ReturnHeader> GetReturnHeaderAsync(int returnHeaderId, bool trackChanges);
        void CreateReturnHeader(ReturnHeader returnHeader);
        void DeleteReturnHeader(ReturnHeader returnHeader);
    }
}
