using DataModel;
using Contracts.Interfaces;
using DataModel.Parameters;
using DataModel.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class NotifyHeaderRepository : RepositoryBase<NotifyHeader>, INotifyHeader
    {
        public NotifyHeaderRepository(MMSDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task<NotifyHeader> GetNotifyHeaderAsync(int notifyHeaderId, bool trackChanges) =>
            await FindByCondition(c => c.id.Equals(notifyHeaderId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateNotifyHeader(NotifyHeader notifyHeader) => Create(notifyHeader);
        public void DeleteNotifyHeader(NotifyHeader notifyHeader) => Delete(notifyHeader);

        public async Task<PagedList<NotifyHeader>> GetAllNotifyHeadersAsync(NotifyHeaderParameters notifyHeaderParameters, bool trackChanges)
        {
           var notifyHeader= await FindAll(trackChanges)
                   .OrderBy(c => c.itemDescription)
                   .ToListAsync();
            return PagedList<NotifyHeader>
                .ToPagedList(notifyHeader,notifyHeaderParameters.PageNumber, notifyHeaderParameters.PageSize);
        }
    }
}






