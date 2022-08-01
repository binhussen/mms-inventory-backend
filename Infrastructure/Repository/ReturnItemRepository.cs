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
            if (returnHeaderId != null)
            {
                var returing = (from hr in RepositoryContext.Hrs
                                join rh in RepositoryContext.ReturnHeaders on hr.id equals rh.hrId
                                where rh.hrId == hr.id
                                select rh).FirstOrDefault();
                if (returing != null)
                {
                    RepositoryContext.ReturnHeaders.Add(returing);
                }


                var findquantity = (from rh in RepositoryContext.ReturnHeaders
                                    join ri in RepositoryContext.ReturnItems on rh.id equals ri.returnHeaderId
                                    where rh.id == ri.returnHeaderId
                                    select new ReturnItem
                                    {

                                        Quantity = ri.Quantity
                                    }).FirstOrDefault();
                var x = findquantity.Quantity;
                if (findquantity != null)
                {

                    var backtostore = (from ap in RepositoryContext.Approves
                                       join si in RepositoryContext.StoreItems on ap.storeItemId equals si.id
                                       where si.id == ap.storeItemId
                                       select new Approve
                                       {
                                           approvedQuantity = ap.approvedQuantity
                                       }).FirstOrDefault();
                    var y = backtostore.approvedQuantity;
                    if (x == y)
                    {
                        //we also need to increase the quantity
                        var finalQuantity = (from sh in RepositoryContext.StoreHeaders
                                             join si in RepositoryContext.StoreItems on sh.id equals si.storeHeaderId
                                             where sh.id == si.storeHeaderId
                                             select new StoreItem
                                             {
                                                 quantity = x + y
                                             }).FirstOrDefault();

                    }
                }
                returnItem.returnHeaderId = returnHeaderId;
                Create(returnItem);
            }

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
                            .ToListAsync();
            return PagedList<ReturnItem>
                .ToPagedList(returnItems, returnItemParameters.PageNumber, returnItemParameters.PageSize);

        }
    }
}
