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
        INotifyDetail NotifyDetail { get; }
        Task SaveAsync();
    }
}
