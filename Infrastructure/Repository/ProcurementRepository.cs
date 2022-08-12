using Contracts.Interfaces;
using DataModel;
using DataModel.Models.Entities;
using DataModel.Parameters;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ProcurementRepository : RepositoryBase<Procurement>, IProcurement
    {
        public ProcurementRepository(MMSDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public void CreateProcurement(Procurement procurement) => Create(procurement);

        public void DeleteProcurement(Procurement procurement) => Delete(procurement);

        public async Task<PagedList<Procurement>> GetAllProcurementsAsync(ProcurementParameters procurementParameters, bool trackChanges)
        {
            var procurement = await FindAll(trackChanges)
                    .OrderBy(c => c.refNo)
                    .ToListAsync();
            return PagedList<Procurement>
                .ToPagedList(procurement, procurementParameters.PageNumber, procurementParameters.PageSize);
        }

        public async Task<Procurement> GetProcurementAsync(int procurementId, bool trackChanges) =>
            await FindByCondition(c => c.id.Equals(procurementId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
