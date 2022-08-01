using Contracts.Interfaces;
using DataModel;
using DataModel.Models.Entities;
using DataModel.Parameters;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ReturnHeaderRepository : RepositoryBase<ReturnHeader>, IReturnHeader
    {
        public ReturnHeaderRepository(MMSDbContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateReturnHeader(ReturnHeader returnHeader)
        {
            Create(returnHeader);
            if (returnHeader == null)
            {
                var returing = (from hr in RepositoryContext.Hrs
                                join rh in RepositoryContext.ReturnHeaders on hr.id equals rh.hrId
                                where rh.hrId == returnHeader.hrId && hr.id == returnHeader.hrId
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
                RepositoryContext.SaveChangesAsync();

                if (findquantity != null)
                {

                    var backtostore = (from ap in RepositoryContext.Approves
                                       join si in RepositoryContext.StoreItems on ap.storeItemId equals si.id
                                       where si.id == ap.storeItemId
                                       select new Approve
                                       {
                                           approvedQuantity = ap.approvedQuantity
                                       }).FirstOrDefault();
                    if (backtostore != null)
                    {
                        var x = findquantity.Quantity;
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
                            this.RepositoryContext.StoreItems.Update(new StoreItem
                            {
                                quantity = x + y,
                            });
                            this.RepositoryContext.SaveChangesAsync();
                        }
                    }
                }
            }
        }

        public void DeleteReturnHeader(ReturnHeader returnHeader)
        {
            Delete(returnHeader);
        }

        public async Task<PagedList<ReturnHeader>> GetAllReturnHeadersAsync(ReturnHeaderParameters returnHeaderParameters, bool trackChanges)
        {
            var returnHeader = await FindAll(trackChanges)
                  .OrderBy(c => c.id)
                  .ToListAsync();
            return PagedList<ReturnHeader>
                  .ToPagedList(returnHeader, returnHeaderParameters.PageNumber, returnHeaderParameters.PageSize);

        }

        public async Task<ReturnHeader> GetReturnHeaderAsync(int returnHeaderId, bool trackChanges) =>
             await FindByCondition(c => c.id.Equals(returnHeaderId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
