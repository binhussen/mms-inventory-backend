using DataModel.Models.Entities;

namespace Contracts.Interfaces
{
    public interface IApprove
    {
        Task<IEnumerable<Approve>> GetApproveAsync(bool trackChanges);
        Task<Approve> GetApproveAsync(int id, bool trackChanges);
        void CreateApprove(Approve approve);
        void DeleteApprove(Approve approve);
    }
}
