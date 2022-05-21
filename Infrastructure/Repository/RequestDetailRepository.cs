using System;
using DataModel;
using System.Linq;
using System.Text;
using Contracts.Interfaces;
using System.Threading.Tasks;
using DataModel.Models.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class RequestDetailRepository : RepositoryBase<RequestItem>, IRequestItem
    {
        public RequestDetailRepository(MMSDbContext repositoryContext) : base(repositoryContext)
        {

        }
        public void CreateRequestItemForRequestHeader(int requestHeaderId, RequestItem requestItem)
        {
            requestItem.requestHeaderId = requestHeaderId;
            Create(requestItem);
        }

        public void DeleteRequestItem(RequestItem requestItem)
        {
            Delete(requestItem);
        }

        public async Task<RequestItem> GetRequestItemAsync(int requestHeaderId, int id, bool trackChanges)
        {
            return await FindByCondition(e => e.requestHeaderId.Equals(requestHeaderId) && e.id.Equals(id), trackChanges)
              .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<RequestItem>> GetRequestItemsAsync(int requestHeaderId, bool trackChanges)
        {
            return await FindByCondition(e => e.requestHeaderId.Equals(requestHeaderId), trackChanges)
            .OrderBy(e => e.weaponName)
            .ToListAsync();
        }
    }
}
