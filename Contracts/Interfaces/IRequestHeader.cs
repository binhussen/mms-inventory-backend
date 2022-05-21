using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Models.Entities;
using System.Collections.Generic;

namespace Contracts.Interfaces
{
    public interface IRequestHeader
    {
        Task<IEnumerable<RequestHeader>> GetAllRequestHeadersAsync(bool trackChanges);
        Task<RequestHeader> GetRequestHeaderAsync(int requestHeaderId, bool trackChanges);
        void CreateRequestHeader(RequestHeader requestHeader);
        void DeleteRequestHeader(RequestHeader requestHeader);
    }
}
