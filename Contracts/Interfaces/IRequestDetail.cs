using System;
using System.Linq;
using System.Text;
using DataModel.Parameters;
using System.Threading.Tasks;
using DataModel.Models.Entities;
using System.Collections.Generic;

namespace Contracts.Interfaces
{
    public interface IRequestItem
    {
        Task<PagedList<RequestItem>> GetRequestItemsAsync(int requestHeaderId, RequestItemParameters requestItemParameters, bool trackChanges);
        Task<RequestItem> GetRequestItemAsync(int requestHeaderId, int id, bool trackChanges);
        void CreateRequestItemForRequestHeader(int requestHeaderId, RequestItem requestItem);
        void DeleteRequestItem(RequestItem requestItem);
    }
}
