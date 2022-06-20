using Contracts.Interfaces;
using DataModel;
using DataModel.Models.Entities;
using DataModel.Parameters;
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

        public async Task<RequestItem> GetRequestAsync(int id, bool trackChanges) =>
            await FindByCondition(e => e.id.Equals(id), trackChanges)
                           .SingleOrDefaultAsync();


        public async Task<PagedList<RequestItem>> GetRequestItemsAsync(int requestHeaderId, RequestItemParameters requestItemParameters, bool trackChanges)
        {
            var requestItems = await FindByCondition(e => e.requestHeaderId.Equals(requestHeaderId), trackChanges)
                           .OrderBy(e => e.name)
                            // .Select(s => s.status == "P" ? "Pending" : s.status == "R" ? "Rejected" : s.status == "C" ? "Canceled" : "Approved")

                            .ToListAsync();
            return PagedList<RequestItem>
                .ToPagedList(requestItems, requestItemParameters.PageNumber, requestItemParameters.PageSize);
        }
    }
}
