using DataModel;
using Contracts.Interfaces;
using DataModel.Models.Common;
using DataModel.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.RequestHandlers
{
    public class NotifyDetailRepository : RepositoryBase<NotifyDetail>, INotifyDetail
    {
        public NotifyDetailRepository(MMSDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateNotifyDetail(int notifyDetailId, NotifyDetail notifyDetail)
        {
            notifyDetail.id = notifyDetailId;
            Create(notifyDetail);
        }

        public void DeleteNotifyDetail(NotifyDetail notifyDetail) => Delete(notifyDetail);

        public async Task<IEnumerable<NotifyDetail>> GetAllNotifyDetailsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
               .OrderBy(c => c.id)
               .ToListAsync();

        public async Task<NotifyDetail> GetNotifyDetailAsync(int detailId, bool trackChanges) =>

            await FindByCondition(c => c.id.Equals(detailId), trackChanges)
           .SingleOrDefaultAsync();     
    }
}