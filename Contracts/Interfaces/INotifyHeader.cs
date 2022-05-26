using DataModel.Parameters;
using DataModel.Models.Entities;

namespace Contracts.Interfaces
{
    public interface INotifyHeader
    {
        Task<PagedList<NotifyHeader>>GetAllNotifyHeadersAsync(NotifyHeaderParameters notifyHeaderParameters, bool trackChanges);
        Task<NotifyHeader> GetNotifyHeaderAsync(int notifyHeaderId, bool trackChanges);
        void CreateNotifyHeader(NotifyHeader notifyHeader);
        void DeleteNotifyHeader(NotifyHeader notifyHeader);
    }
}



