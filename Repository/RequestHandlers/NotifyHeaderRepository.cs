using DataModel;
using Contracts.Interfaces;
using DataModel.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.RequestHandlers
{
    public class NotifyHeaderRepository : RepositoryBase<NotifyHeader>, INotifyHeader
    {
        public NotifyHeaderRepository(MMSDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateNotifyHeader(NotifyHeader notifyHeader) => Create(notifyHeader);
        public void DeleteNotifyHeader(NotifyHeader notifyHeader) => Delete(notifyHeader);

        public async Task<IEnumerable<NotifyHeader>> GetAllNotifyHeadersAsync(bool trackChanges) =>
           await FindAll(trackChanges)
           .OrderBy(c => c.id)
           .ToListAsync();

        public async Task<NotifyHeader> GetNotifyHeaderAsync(int notifyHeaderId, bool trackChanges) =>
            await FindByCondition(c => c.id.Equals(notifyHeaderId), trackChanges)
            .SingleOrDefaultAsync();
    }
}