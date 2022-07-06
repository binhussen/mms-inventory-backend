using Contracts.Interfaces;
using DataModel;
using DataModel.Models.Entities;
using DataModel.Parameters;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ReturnItemRepository : RepositoryBase<ReturnItem>, IReturnItem
    {
        public ReturnItemRepository(MMSDbContext repositoryContext) : base(repositoryContext)
        {

        }
        public void CreateReturnItemForReturnHeader(int returnHeaderId, ReturnItem returnItem)
        {
            returnItem.returnHeaderId = returnHeaderId;
            Create(returnItem);
        }

        public void DeleteReturnItem(ReturnItem returnItem)
        {
            Delete(returnItem);
        }

        public async Task<ReturnItem> GetReturnAsync(int id, bool trackChanges) =>

            await FindByCondition(e => e.id.Equals(id), trackChanges)
                           .SingleOrDefaultAsync();


        public async Task<ReturnItem> GetReturnItemAsync(int returnHeaderId, int id, bool trackChanges)
        {
            return await FindByCondition(e => e.returnHeaderId.Equals(returnHeaderId) && e.id.Equals(id), trackChanges)
              .SingleOrDefaultAsync();
        }

        public async Task<PagedList<ReturnItem>> GetReturnItemsAsync(int returnHeaderId, ReturnItemParameters returnItemParameters, bool trackChanges)
        {
            var returnItems = await FindByCondition(e => e.returnHeaderId.Equals(returnHeaderId), trackChanges)
                           .OrderBy(e => e.name)
                            // .Select(s => s.status == "P" ? "Pending" : s.status == "R" ? "Rejected" : s.status == "C" ? "Canceled" : "Approved")

                            .ToListAsync();
            return PagedList<ReturnItem>
                .ToPagedList(returnItems, returnItemParameters.PageNumber, returnItemParameters.PageSize);

        }
    }
}
