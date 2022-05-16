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
    public interface INotifyDetail
    {
        Task<IEnumerable<NotifyDetail>> GetNotifyDetailsAsync(int notifyHeaderId, bool trackChanges);
        Task<NotifyDetail> GetNotifyDetailAsync(int notifyHeaderId, int id, bool trackChanges);
        void CreateNotifyDetailForNotifyHeader(int notifyHeaderId, NotifyDetail notifyDetail);
        void DeleteNotifyDetail(NotifyDetail notifyDetail);
    }
}

