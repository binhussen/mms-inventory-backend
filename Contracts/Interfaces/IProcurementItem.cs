using DataModel.Models.Entities;
using DataModel.Parameters;

namespace Contracts.Interfaces
{
    public interface IProcurementItem
    {
        Task<PagedList<ProcurementItem>> GetProcurementItemsAsync(int procurementId, ProcurementItemParameters procurementItemParameters, bool trackChanges);
        Task<ProcurementItem> GetProcurementItemAsync(int procurementItemId, int id, bool trackChanges);
        void CreateProcurementItemForProcurement(int procurementItemId, ProcurementItem procurementItem);
        void DeleteProcurementItem(ProcurementItem procurementItem);
    }
}
