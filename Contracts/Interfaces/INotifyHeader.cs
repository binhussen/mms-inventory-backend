using DataModel.Models.Entities;

namespace Contracts.Interfaces
{
    public interface INotifyHeader
    {
        Task<IEnumerable<NotifyHeader>> GetAllNotifyHeadersAsync(bool trackChanges);
        Task<NotifyHeader> GetNotifyHeaderAsync(int HeaderId, bool trackChanges);
        void CreateNotifyHeader(NotifyHeader Header);
        void DeleteNotifyHeader(NotifyHeader Header);
    }
}
