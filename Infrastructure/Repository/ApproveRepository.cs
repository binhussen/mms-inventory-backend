using Contracts.Interfaces;
using DataModel;
using DataModel.Models.Entities;
using DataModel.Parameters;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ApproveRepository : RepositoryBase<Approve>, IApprove
    {
        public ApproveRepository(MMSDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateApprove(Approve approve)
        {
            Create(approve);
        }

        public void DeleteApprove(Approve approve)
        {
            Delete(approve);
        }

        public async Task<Approve> GetApproveByIdAsync(int id, bool trackChanges) =>
         await FindByCondition(e => e.id.Equals(id), trackChanges)
             .SingleOrDefaultAsync();

        public async Task<PagedList<Approve>> GetAllApprovesAsync(ApproveParameters approveParameters, bool trackChanges)
        {
            var approve = await FindAll(trackChanges)
                       .OrderBy(c => c.approvedQuantity)
                      .ToListAsync();
            return PagedList<Approve>
                .ToPagedList(approve, approveParameters.PageNumber, approveParameters.PageSize);

        }

        public async Task<PagedList<Approve>> GetAllApprovesAsync(int requestId, ApproveParameters approveParameters, bool trackChanges)
        {
            var approves = await FindByCondition(e => e.requestId.Equals(requestId), trackChanges)
                          .OrderBy(e => e.storeItemId)
                           // .Select(s => s.status == "P" ? "Pending" : s.status == "R" ? "Rejected" : s.status == "C" ? "Canceled" : "Approved")

                           .ToListAsync();
            return PagedList<Approve>
                .ToPagedList(approves, approveParameters.PageNumber, approveParameters.PageSize);
        }
    }
}



