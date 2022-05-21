using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Contracts.Interfaces
{
    public interface IRepositoryManager
    {
        INotifyHeader NotifyHeader { get; }
        INotifyItem NotifyItem { get; }
        IStoreHeader StoreHeader { get; }
        IStoreItem StoreItem { get; }
        IRequestHeader RequestHeader { get; }
        IRequestItem RequestItem { get; }
        Task SaveAsync();
    }
}
