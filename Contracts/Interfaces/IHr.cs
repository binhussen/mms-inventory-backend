using DataModel.Models.Entities;
using DataModel.Parameters;

namespace Contracts.Interfaces
{
    public interface IHr
    {
        Task<PagedList<HR>> GetAllHrsAsync(HrParameters hrParameters, bool trackChanges);
        Task<HR> GetHrByIdAsync(int id, bool trackChanges);
        void CreateHr(HR hr);
        void DeleteHr(HR hr);
    }
}
