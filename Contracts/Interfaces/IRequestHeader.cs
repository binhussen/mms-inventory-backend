using System;
using System.Linq;
using System.Text;
using DataModel.Parameters;
using System.Threading.Tasks;
using DataModel.Models.Entities;
using System.Collections.Generic;

namespace Contracts.Interfaces
{
    public interface IRequestHeader
    {
        Task<PagedList<RequestHeader>> GetAllRequestHeadersAsync(RequestHeaderParameters requestHeaderParameters,bool trackChanges);
        Task<RequestHeader> GetRequestHeaderAsync(int requestHeaderId, bool trackChanges);
        void CreateRequestHeader(RequestHeader requestHeader);
        void DeleteRequestHeader(RequestHeader requestHeader);
    }
}
