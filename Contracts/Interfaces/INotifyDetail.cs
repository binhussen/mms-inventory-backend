using System;
using System.Linq;
using System.Text;
using DataModel.Parameters;
using System.Threading.Tasks;
using DataModel.Models.Common;
using DataModel.Models.Entities;
using System.Collections.Generic;

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

