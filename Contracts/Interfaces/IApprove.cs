using DataModel.Models.Entities;
using DataModel.Parameters;

namespace Contracts.Interfaces
{
    public interface IApprove
    {
        Task<PagedList<Approve>> GetAllApprovesAsync(ApproveParameters approveParameters, bool trackChanges);
        Task<PagedList<Approve>> GetAllApprovesAsync(int requestId, ApproveParameters approveParameters, bool trackChanges);
        Task<Approve> GetApproveByIdAsync(int id, bool trackChanges);
        void CreateApprove(Approve approve);
        void DeleteApprove(Approve approve);
    }
}
