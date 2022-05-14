using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Models.Common;
using DataModel.Models.Entities;
using System.Collections.Generic;
using Contracts.Models.RequestModels.NotifyRequest;
using Contracts.Models.ResponseModels.NotifyResponse;

namespace Contracts.Interfaces
{
    public interface INotifyDetail
    {
        Task<IEnumerable<NotifyDetail>> GetAllNotifyDetailsAsync(bool trackChanges);
        Task<NotifyDetail> GetNotifyDetailAsync(int detailId, bool trackChanges);
        void CreateNotifyDetail(int notifyDetailId, NotifyDetail detail);
        void DeleteNotifyDetail(NotifyDetail detail);
    }
}
