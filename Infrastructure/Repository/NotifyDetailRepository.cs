using DataModel;
using Contracts.Interfaces;
using DataModel.Parameters;
using DataModel.Models.Common;
using DataModel.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class NotifyDetailRepository : RepositoryBase<NotifyDetail>, INotifyDetail
    {
        public NotifyDetailRepository(MMSDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task<PagedList<NotifyDetail>> GetNotifyDetailsAsync(int notifyHeaderId, NotifyDetailParameters NotifyDetailParameters, bool trackChanges)
        {
            var notifyDetails = await FindByCondition(e => e.notifyHeaderId.Equals(notifyHeaderId), trackChanges)
                .OrderBy(c => c.weaponType) //we can add search here later
                .ToListAsync();
            return PagedList<NotifyDetail>
                .ToPagedList(notifyDetails, NotifyDetailParameters.PageNumber, NotifyDetailParameters.PageSize);
        }
        public async Task<NotifyDetail> GetNotifyDetailAsync(int notifyHeaderId, int id, bool trackChanges)=>

            await FindByCondition(e => e.notifyHeaderId.Equals(notifyHeaderId) && e.id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateNotifyDetailForNotifyHeader(int notifyHeaderId, NotifyDetail notifyDetail)
        {
            notifyDetail.notifyHeaderId = notifyHeaderId;
            Create(notifyDetail);
        }
        public void DeleteNotifyDetail(NotifyDetail notifyDetail) => Delete(notifyDetail);

    }
}