using DataModel.Models.Entities;
using DataModel.Parameters;

namespace Contracts.Interfaces
{
    public interface IProcurement
    {
        Task<PagedList<Procurement>> GetAllProcurementsAsync(ProcurementParameters procurementParameters, bool trackChanges);
        Task<Procurement> GetProcurementAsync(int procurementId, bool trackChanges);
        void CreateProcurement(Procurement procurement);
        void DeleteProcurement(Procurement procurement);
    }
}
