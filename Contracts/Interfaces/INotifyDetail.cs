using DataModel.Models.Entities;
using DataModel.Parameters;

namespace Contracts.Interfaces
{
    public interface INotifyItem
    {
        Task<PagedList<NotifyItem>> GetNotifyItemsAsync(int notifyHeaderId, NotifyItemParameters notifyItemParameters, bool trackChanges);
        Task<NotifyItem> GetNotifyItemAsync(int notifyHeaderId, int id, bool trackChanges);
        void CreateNotifyItemForNotifyHeader(int notifyHeaderId, NotifyItem notifyItem);
        void DeleteNotifyItem(NotifyItem notifyItem);
    }
}

