using Contracts.Interfaces;
using DataModel;
using DataModel.Models.Entities;
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

        public async Task<Approve> GetApproveAsync(int id, bool trackChanges) =>
         await FindByCondition(e => e.id.Equals(id), trackChanges)
             .SingleOrDefaultAsync();

        public async Task<IEnumerable<Approve>> GetApproveAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                        .OrderBy(c => c.approvedQuantity)
                       .ToListAsync();
    }
}



