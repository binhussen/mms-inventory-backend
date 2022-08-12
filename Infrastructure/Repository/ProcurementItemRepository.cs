using Contracts.Interfaces;
using DataModel;
using DataModel.Models.Entities;
using DataModel.Parameters;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ProcurementItemRepository : RepositoryBase<ProcurementItem>, IProcurementItem
    {
        public ProcurementItemRepository(MMSDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public void CreateProcurementItemForProcurement(int procurementId, ProcurementItem procurementItem)
        {
            procurementItem.procurementId = procurementId;
            Create(procurementItem);
        }

        public void DeleteProcurementItem(ProcurementItem procurementItem)
        {
            Delete(procurementItem);
        }

        public async Task<ProcurementItem> GetProcurementItemAsync(int procurementId, int id, bool trackChanges) =>
         await FindByCondition(e => e.procurementId.Equals(procurementId) && e.id.Equals(id), trackChanges)
             .SingleOrDefaultAsync();

        public async Task<PagedList<ProcurementItem>> GetProcurementItemsAsync(int procurementId, ProcurementItemParameters procurementItemParameters, bool trackChanges)
        {
            var procurementItems = await FindByCondition(e => e.procurementId.Equals(procurementId), trackChanges)
             .OrderBy(e => e.name)
             .ToListAsync();
            return PagedList<ProcurementItem>
              .ToPagedList(procurementItems, procurementItemParameters.PageNumber, procurementItemParameters.PageSize);
        }
    }
}
