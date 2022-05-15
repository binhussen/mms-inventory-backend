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
        public async Task<IEnumerable<NotifyHeader>> GetAllNotifyHeadersAsync(bool trackChanges) =>
               await FindAll(trackChanges)
                   .OrderBy(c => c.weaponDescription)
                   .ToListAsync();
        public async Task<NotifyHeader> GetNotifyHeaderAsync(int notifyHeaderId, bool trackChanges) =>
            await FindByCondition(c => c.id.Equals(notifyHeaderId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateNotifyHeader(NotifyHeader notifyHeader) => Create(notifyHeader);
        public void DeleteNotifyHeader(NotifyHeader notifyHeader) => Delete(notifyHeader);


    }
}






